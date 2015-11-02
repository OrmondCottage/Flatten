using IntercomCode.Invite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Device.Location;

namespace InviteTest
{
    
    
    /// <summary>
    ///This is a test class for CustomerTest and is intended
    ///to contain all CustomerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ComponentModel.DataAnnotations.ValidationException))]
        public void IdTest()
        {
            int id = -1; 
            Customer target = new Customer(); 
            target.Id = id;

            int expected = 0; 
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
        }

       

        /// <summary>
        ///A test for CustomerLocation
        ///</summary>
        [TestMethod()]
        public void CustomerLocationTest()
        {
            int id = 1; 
            string customerName = string.Empty; 
            double latitude = 0F; 
            double longitude = 0F; 
            Customer target = new Customer(id, customerName, latitude, longitude); 
            GeoCoordinate actual = new GeoCoordinate(0.0,0.0);
            actual = target.CustomerLocation;
           
        }

        /// <summary>
        ///A test for Latitude
        ///</summary>
        [TestMethod()]
        public void LatitudeTest()
        {
            int id = 1; 
            string customerName = string.Empty; 
            double latitude = 0F; 
            double longitude = 0F; 
            Customer target = new Customer(id, customerName, latitude, longitude); 
            double expected = 0F; 
            double actual;
            target.Latitude = expected;
            actual = target.Latitude;
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for Longitude
        ///</summary>
        [TestMethod()]
        public void LongitudeTest()
        {
            int id = 1; 
            string customerName = string.Empty; 
            double latitude = 0F; 
            double longitude = 0F; 
            Customer target = new Customer(id, customerName, latitude, longitude); 
            double expected = 0F; 
            double actual;
            target.Longitude = expected;
            actual = target.Longitude;
            Assert.AreEqual(expected, actual);
           
        }
    }
}
