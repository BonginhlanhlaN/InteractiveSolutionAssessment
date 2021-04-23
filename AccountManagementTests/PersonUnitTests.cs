using InteractiveSolutionsAcountManagement.Controllers;
using InteractiveSolutionsAcountManagement.Repository.Models;
using InteractiveSolutionsAcountManagement.Repository.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManagementTests
{
    [TestClass]
    class PersonUnitTests
    {
        [TestMethod]
        public void TestGetAllPersons()
        {

            //Mock<IPersonRepository> mock = new Mock<IPersonRepository>();


            //mock.Setup(p => p.GetPersons(It.IsAny<int>())).Returns(Task<ActionResult<IEnumerable<Persons>>>() { });
            //PersonsController personsController = new PersonsController(mock.Object);

        }

    }
}
