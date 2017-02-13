using Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace InvoiceService
{
    [ServiceContract]
    public interface IInvoiceService
    {

        [OperationContract]
        IEnumerable<CustomerInvoice> GetInvoice(string email, int invoiceCode);
        [OperationContract]
        Task<IEnumerable<CustomerInvoice>> AsyncGetInvoice(string email, int invoiceCode);
    }    
}
