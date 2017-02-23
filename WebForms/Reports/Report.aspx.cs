using DataAccess;
using Microsoft.Reporting.WebForms;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.App_Code;

namespace WebForms.Reports
{    
    public partial class Report : BasePage
    {
        protected static UnitOfWork _unit;
        public Report()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerifyUser();
                SetDataToEmailDropDown();
            }            
        }
        
        protected void SetDataToEmailDropDown()
        {
            EmailDropDown.DataTextField = "Text";
            EmailDropDown.DataValueField = "Value";
            EmailDropDown.DataSource = CustomerList();
            EmailDropDown.DataBind();
        }

        protected void SetDataToInvoiceDropDown()
        {
            InvoiceDropDown.DataTextField = "Text";
            InvoiceDropDown.DataValueField = "Value";
            InvoiceDropDown.DataSource = InvoiceList();
            InvoiceDropDown.DataBind();           
        }

        protected IEnumerable<ListItem> CustomerList()
        {
            var customerListItem = new List<ListItem>() ;
            var customerList = _unit.Customers.GetAll();
            foreach (var item in customerList)
            {
                customerListItem.Add(new ListItem(item.Email, item.CustomerId.ToString()));
            }
            return customerListItem;
        }
        protected IEnumerable<ListItem> InvoiceList()
        {
            var customerId = Convert.ToInt32(EmailDropDown.SelectedValue);
            var invoiceListItem = new List<ListItem>();
            var invoiceList = _unit.Invoices.GetAll().Where(x=> x.CustomerId== customerId);
            foreach (var item in invoiceList)
            {
                invoiceListItem.Add(new ListItem(item.InvoiceId.ToString(), item.InvoiceId.ToString()));
            }
            return invoiceListItem;
        }

        protected void EmailDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataToInvoiceDropDown();
        }

        protected void InvoiceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var email = EmailDropDown.SelectedItem.Text;
            var invoiceId = Convert.ToInt32(InvoiceDropDown.SelectedValue);
            RenderReport(email, invoiceId);
        }

        private void RenderReport(string email, int invoiceId)
        {
            InvoiceReportViewer.ProcessingMode = ProcessingMode.Local;
            InvoiceReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/ReportInvoice.rdlc");

            InvoiceReportViewer.LocalReport.DataSources.Clear();
            InvoiceReportViewer.LocalReport.DataSources.Add(new ReportDataSource("InvoiceReportSource", _unit.Customers.CustomerInvoice(email, invoiceId).ToList()));
        }
    }
}