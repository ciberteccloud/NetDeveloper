using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ChinookContext context) : base(context)
        {
        }
        public IEnumerable<CustomerInvoice> CustomerInvoice(string customerEmail, int invoiceCode)
        {
            var email = new SqlParameter("@email", customerEmail);
            var invoiceId = new SqlParameter("@invoiceId", invoiceCode);            
            return ChinookContext.Database.SqlQuery<CustomerInvoice>("dbo.CustomerInvoice @invoiceId, @email", invoiceId, email); 
        }
    }
}
