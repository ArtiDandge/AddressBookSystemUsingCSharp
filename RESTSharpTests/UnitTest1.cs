using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AddressBookSystemUsingCSharp;

namespace RESTSharpTests
{
    public class ContactList
    {
        public static List<Contacts> GetContactList()
        {
            List<Contacts> list = new List<Contacts>();
            list.Add(new Contacts("Shirin", "CHouksi", "Pune", "Pune", "MH", 400040, 755454533, "shirin@gmail.com"));
            list.Add(new Contacts("Neha", "Parkar", "Jaipur", "Jaipur", "MP", 344040, 6755454533, "neha@gmail.com"));
            list.Add(new Contacts("Damini", "Kasi", "Jodhpur", "Jodhpur", "MP", 430040, 8755454533, "damini@gmail.com"));
            list.Add(new Contacts("Reena", "Pal", "Mumbai", "Mumbai", "MH", 400001, 8855454533, "reena@gmail.com"));
            return list;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        public IRestResponse GetContactList()
        {
            //arrange
            RestRequest request = new RestRequest("/Contacts", Method.GET);

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// Test case to retrieve all Contacts using json server and match result by asserting
        /// </summary>
        [TestMethod]
        public void onCallingGETApi_ReturnContactList()
        {
            IRestResponse response = GetContactList();
            //assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Contacts> dataResponse = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(9, dataResponse.Count);
            foreach (Contacts contact in dataResponse)
            {
                System.Console.Write("\nFirst name: " + contact.first_name + " \nLast name: " + contact.last_name + " \nAddress: " + contact.address + " \nCity: " + contact.city + " \nState: "
                    + contact.state + " \nZip:" + contact.zip + " \nPhone Number:" + contact.phone_number + " \nEmail:" + contact.email);
            }
        }

        /// <summary>
        /// Test Case to add multiple new Contacts using JsonServer and RESTSharp
        /// </summary>
        [TestMethod]
        public void GivenMultipleContacts_OnPost_ShouldReturnMultipleAddedContacts()
        {
            List<Contacts> list = ContactList.GetContactList();
            foreach (Contacts contacts in list)
            {
                RestRequest request = new RestRequest("/Contacts", Method.POST);
                JObject jObjectbody = new JObject();
                jObjectbody.Add("first_name", contacts.first_name);
                jObjectbody.Add("last_name", contacts.last_name);
                jObjectbody.Add("address", contacts.address);
                jObjectbody.Add("city", contacts.city);
                jObjectbody.Add("state", contacts.state);
                jObjectbody.Add("zip", contacts.zip);
                jObjectbody.Add("phone_number", contacts.phone_number);
                jObjectbody.Add("email", contacts.email);
                request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
                client.Execute(request);
            }
            IRestResponse responses = GetContactList();
            Assert.AreEqual(responses.StatusCode, HttpStatusCode.OK);
            List<Contacts> dataResponse = JsonConvert.DeserializeObject<List<Contacts>>(responses.Content);
            Assert.AreEqual(9, dataResponse.Count);
            foreach (Contacts contact in dataResponse)
            {
                System.Console.Write("\nFirst name: " + contact.first_name + " \nLast name: " + contact.last_name + " \nAddress: " + contact.address + " \nCity: " + contact.city + " \nState: "
                    + contact.state + " \nZip:" + contact.zip + " \nPhone Number:" + contact.phone_number + " \nEmail:" + contact.email);
            }
        }

        /// <summary>
        /// Test Case to update Contacts using JsonServer and RESTSharp
        /// </summary>
        [TestMethod]
        public void GivenContact_OnPut_ShouldUpdateContact()
        {
            RestRequest request = new RestRequest("/Contacts/3", Method.PUT);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("first_name", "Renu");
            jObjectbody.Add("last_name", "Kumar");
            jObjectbody.Add("address", "Nashik");
            jObjectbody.Add("city", "Nashik");
            jObjectbody.Add("state", "MH");
            jObjectbody.Add("zip", 400032);
            jObjectbody.Add("phone_number", 8765432455);
            jObjectbody.Add("email", "renu@yahoo.com");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            client.Execute(request);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Contacts dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("Renu", dataResponse.first_name);
            Assert.AreEqual("Kumar", dataResponse.last_name);
            Assert.AreEqual("Nashik",dataResponse.address);
            Assert.AreEqual("Nashik", dataResponse.city);
            Assert.AreEqual("MH", dataResponse.state);
            Assert.AreEqual(400032, dataResponse.zip);
            Assert.AreEqual(8765432455, dataResponse.phone_number);
            Assert.AreEqual("renu@yahoo.com", dataResponse.email);
            System.Console.WriteLine(response.Content);
        }

        /// <summary>
        /// Test Case to Delete Contact Details using JsonServer and RESTSharp
        /// </summary>
        [TestMethod]
        public void GivenContactID_OnDelete_ShouldContactDetails()
        {
            RestRequest request = new RestRequest("/Contacts/5", Method.DELETE);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            IRestResponse responses = GetContactList();
            Assert.AreEqual(responses.StatusCode, HttpStatusCode.OK);
            List<Contacts> dataResponse = JsonConvert.DeserializeObject<List<Contacts>>(responses.Content);
            Assert.AreEqual(7, dataResponse.Count);
            foreach (Contacts contact in dataResponse)
            {
                System.Console.Write("\nFirst name: " + contact.first_name + " \nLast name: " + contact.last_name + " \nAddress: " + contact.address + " \nCity: " + contact.city + " \nState: "
                    + contact.state + " \nZip:" + contact.zip + " \nPhone Number:" + contact.phone_number + " \nEmail:" + contact.email);
            }
        }
    }
}
