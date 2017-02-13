using System.Collections.Generic;
using Models;
using DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceService
{
    public class InvoiceService : IInvoiceService
    {  
        public IEnumerable<CustomerInvoice> GetInvoice(string email, int invoiceCode)
        {
            using (var unitOfWork = new UnitOfWork(new ChinookContext()))
            {                
                return unitOfWork.Customers.CustomerInvoice(email, invoiceCode).ToList();
            }
        }
        public async Task<IEnumerable<CustomerInvoice>> AsyncGetInvoice(string email, int invoiceCode)
        {
            return await Task<IEnumerable<CustomerInvoice>>.Factory.StartNew(() =>
            {
                using (var unitOfWork = new UnitOfWork(new ChinookContext()))
                {
                    return unitOfWork.Customers.CustomerInvoice(email, invoiceCode).ToList();
                }
            });
        }
    }
}
