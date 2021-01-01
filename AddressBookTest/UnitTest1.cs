using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystemUsingCSharp;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Retrieve Contacts from database and match number of counts of rows
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenRetrieve_ShouldReturnNumberOfRowsRetrieved()
        {
            int expectedResult = 3; 
            AddressBookDatabase database = new AddressBookDatabase();
            int result = database.GetPersonDetailsfromDatabase();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
