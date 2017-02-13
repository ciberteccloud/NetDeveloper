using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerRepositoryTest()
        {
            _unitOfWork = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void Get_List_Of_Customer_Invoice()
        {
            var results = _unitOfWork.Customers.CustomerInvoice("leonekohler@surfeu.de", 1).ToList();
            Assert.AreEqual(results[0].Email, "leonekohler@surfeu.de");
            Assert.AreEqual(results[1].Email, "leonekohler@surfeu.de");
            Assert.AreEqual(results.Count() > 0, true);
        }
    }
}
