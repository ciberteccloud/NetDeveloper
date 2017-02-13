using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ChinookContext context) : base(context)
        {
        }
        public IEnumerable<CustomerInvoice> CustomerInvoice(string customerEmail, int invoiceCode)
        {
            return ChinookContext.Database.SqlQuery<CustomerInvoice>("dbo.CustomerInvoice");
        }
    }
}
