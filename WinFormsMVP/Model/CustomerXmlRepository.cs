using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormsMVP.Model
{
    internal class CustomerXmlRepository:ICustomerRepository
    {
        private readonly string _xmlFilePath;
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Customer>));
        private readonly Lazy<List<Customer>> _customers;

        public CustomerXmlRepository(string fullPath)
        {
            _xmlFilePath = fullPath + @"\customers.xml";
            if (!File.Exists(_xmlFilePath)) CreateCustomerXmlStub();
            _customers = new Lazy<List<Customer>>(
                () =>
                {
                    using (var reader = new StreamReader(_xmlFilePath))
                    {
                        return (List<Customer>)_serializer.Deserialize(reader);
                    }
                });
        }
        public void CreateCustomerXmlStub()
        {
            var list = new List<Customer>
            {
                new Customer {Name="Joe",Address="Moscow",Phone="+7899433232"},
                new Customer {Name="Tom",Address="NewYork",Phone="+7899345435"},
                new Customer {Name="John",Address="London",Phone="+784353453453"}
            };
            SaveCustomerList(list);
        }

        public IEnumerable<Customer> getAllCustomers()
        {
            return _customers.Value;
        }

        public Customer GetCustomer(int id)
        {
            return _customers.Value[id];
        }

        public void SaveCustomer(int id, Customer customer)
        {
            _customers.Value[id] = customer;
            SaveCustomerList(_customers.Value);
        }

        public void SaveCustomerList(List<Customer> customers)
        {
            using (var writer = new StreamWriter(_xmlFilePath,false))
            {
                _serializer.Serialize(writer,customers);
            }
        }

    }
}
