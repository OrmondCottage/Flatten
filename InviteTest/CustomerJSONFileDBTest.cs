using IntercomCode.Invite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


using Newtonsoft.Json;

namespace InviteTest
{
    
    
    /// <summary>
    ///This is a test class for CustomerJSONFileDBTest and is intended
    ///to contain all CustomerJSONFileDBTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerJSONFileDBTest
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
        ///Test 1 - correctly formatted
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        public void DeserialiseCustomerFromStringTest()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor(); 
            string customerRecord = "{\"latitude\": \"52.3191841\", \"user_id\": 3, \"name\": \"Jack Enright\", \"longitude\": \"-8.5072391\"}"; // Valid string
            Customer expected = new Customer(3, "Jack Enright", Convert.ToDouble("52.3191841"), Convert.ToDouble("-8.5072391"));
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CustomerName, actual.CustomerName);
            Assert.AreEqual(expected.Latitude, actual.Latitude, 0.01);      // doubles are trouble!
            Assert.AreEqual(expected.Longitude, actual.Longitude, 0.01);


        }

        /// <summary>
        ///Test 2 - empty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        public void DeserialiseCustomerFromStringTest01()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor(); 
            string customerRecord = ""; // Empty
            Customer expected = null;
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Test 2.1 - badly formatted
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        [ExpectedException(typeof(JsonReaderException))]
        public void DeserialiseCustomerFromStringTest02()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor(); 
            string customerRecord = "{Gibberish}"; // Valid string
            Customer expected = null;
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Test 2.1 - Invalid Latitude - too big
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void DeserialiseCustomerFromStringTest03()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor(); 
            string customerRecord = "{\"latitude\": \"252.3191841\", \"user_id\": 3, \"name\": \"Jack Enright\", \"longitude\": \"-8.5072391\"}"; // Valid string
            Customer expected = null;
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected, actual);        
        }

        /// <summary>
        ///Test 2.1 - Invalid Latitude - not double
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void DeserialiseCustomerFromStringTest04()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor(); 
            string customerRecord = "{\"latitude\": \"not a latitude\", \"user_id\": 3, \"name\": \"Jack Enright\", \"longitude\": \"-8.5072391\"}"; // Valid string
            Customer expected = null;
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///Test 3 - Invalid Latitude - missing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void DeserialiseCustomerFromStringTest05()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor(); 
            string customerRecord = "{\"latitude\": , \"user_id\": 3, \"name\": \"Jack Enright\", \"longitude\": \"-8.5072391\"}"; // Valid string
            Customer expected = null;
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///Test 3 - Invalid  - badly formatted (2)
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        [ExpectedException(typeof(JsonReaderException))]
        public void DeserialiseCustomerFromStringTest06()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor(); 
            string customerRecord = "{\"latitude\" ,, ,,,\"}"; // Valid string
            Customer expected = null;
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Test 3 - Invalid ID - out of range
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Invite.exe")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void DeserialiseCustomerFromStringTest07()
        {
            CustomerJSONFileDB_Accessor target = new CustomerJSONFileDB_Accessor();
            string customerRecord = "{\"latitude\": \"52.3191841\", \"user_id\": -3, \"name\": \"Jack Enright\", \"longitude\": \"-8.5072391\"}"; // Valid string
            Customer expected = null;
            Customer actual;
            actual = target.DeserializeCustomerFromString(customerRecord);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// ReadCustomerList (Empty file)
        ///</summary>
        [TestMethod()]
        public void ReadCustomerListTest01()
        {
            CustomerJSONFileDB target = new CustomerJSONFileDB(); 
            string filename = "..\\data\\customerList - empty.txt";
            List<Customer> expected = new List<Customer>(); 
            List<Customer> actual = new List<Customer>();
            actual = target.ReadCustomerList(filename);
            //Assert.C(expected, actual);
            CollectionAssert.AreEqual(expected,actual);
        }

    }
}
