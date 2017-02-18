using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Test
{
    
    public class CustomerRepositoryTest
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerRepositoryTest()
        {
            _unitOfWork = new UnitOfWork(new ChinookContext());
        }

        [Fact]
        public void Get_List_Of_Customer_Invoice()
        {
            var results = _unitOfWork.Customers.CustomerInvoice("leonekohler@surfeu.de", 1).ToList();
            results[0].Email.Should().Be("leonekohler@surfeu.de");
            results[1].Email.Should().Be("leonekohler@surfeu.de");
            results.Count().Should().BeGreaterThan(0);
        }
    }
}
