using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10102524_APPR6312_POE_PART_2.Controllers;
using ST10102524_APPR6312_POE_PART_2.Data;
using ST10102524_APPR6312_POE_PART_2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10102524_APPR6312_POE_PART_2.Tests.Controllers
{
    [TestClass]
    public class MoneyDonationsControllerTests
    {
        private MoneyDonationsController _controller;
        private ApplicationDbContext _mockContext;

        [TestInitialize]
        public void Setup()
        {
            // Set up an in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _mockContext = new ApplicationDbContext(options);
            _controller = new MoneyDonationsController(_mockContext);
        }

        [TestMethod]
        public async Task Index_Returns_ViewResult_With_MoneyDonations()
        {
            // Arrange
            _mockContext.MoneyDonation.Add(new MoneyDonation { MONEY_DONATION_ID = 1, AMOUNT = 100 });
            _mockContext.SaveChanges();

            // Act
            var result = await _controller.Index();

            // Assert
                          // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<MoneyDonation>;
        }

        [TestMethod]
        public async Task Create_ValidModel_Returns_RedirectToAction()
        {
            // Arrange
            var donation = new MoneyDonation
            {
                MONEY_DONATION_ID = 1,
                USERNAME = "testuser",
                DATE = DateTime.Now.Date,
                AMOUNT = 100,
                DONOR = "John Doe"
            };

            // Act
            var result = await _controller.Create(donation);

            // Assert
                        // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = result as RedirectToActionResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod]
        public async Task Edit_ValidModel_Returns_RedirectToAction()
        {
            // Arrange
            var donation = new MoneyDonation
            {
                MONEY_DONATION_ID = 1,
                USERNAME = "testuser",
                DATE = DateTime.Now.Date,
                AMOUNT = 100,
                DONOR = "John Doe"
            };
            _mockContext.MoneyDonation.Add(donation);
            _mockContext.SaveChanges();

            // Act
            donation.AMOUNT = 200;
            var result = await _controller.Edit(1, donation);

            // Assert
                        // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = result as RedirectToActionResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod]
        public async Task Delete_ValidId_Returns_RedirectToAction()
        {
            // Arrange
            var donation = new MoneyDonation
            {
                MONEY_DONATION_ID = 1,
                USERNAME = "testuser",
                DATE = DateTime.Now.Date,
                AMOUNT = 100,
                DONOR = "John Doe"
            };
            _mockContext.MoneyDonation.Add(donation);
            _mockContext.SaveChanges();

            // Act
            var result = await _controller.DeleteConfirmed(1);

            // Assert
                        // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = result as RedirectToActionResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}
