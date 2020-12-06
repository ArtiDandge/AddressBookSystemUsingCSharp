
namespace AddressBookSystemUsingCSharp
{
    public class Contacts
    {
        public string first_name;
        public string last_name;
        public string address;
        public string city;
        public string state;
        public int zip;
        public long phone_number;
        public string email;

        public Contacts(string first_name, string last_name, string address, string city, string state, int zip, long phone_number, string email)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone_number = phone_number;
            this.email = email;
        }
        public string tostring()
        {

            return "Person Details: \tFirst name:" + this.first_name + " \tLast name:" + this.last_name + " \t Address:" + this.address + " \tCity:" + this.city + " \tState:"
                    + this.state + " \tZip:" + this.zip + " \tPhone Number:" + this.phone_number + " \tEmail:" + this.email;
        }
    }
}

