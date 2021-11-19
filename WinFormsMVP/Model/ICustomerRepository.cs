using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMVP.Model
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> getAllCustomers();
        Customer GetCustomer(int id);
        void SaveCustomer(int id,Customer customer);
    }
}
