using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMVP.Model;
using WinFormsMVP.View;

namespace WinFormsMVP.Presenter
{
    public class CustomerPresenter
    {
        private readonly ICustomerView _view;
        private readonly ICustomerRepository _repository;

        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
        {
            _view = view;
            _repository = repository;
            view.Presenter = this;
            UpdateCustomerListView();
        }
        public void UpdateCustomerListView()
        {
            var customerNames = from customer in _repository.getAllCustomers()
                                select customer.Name;
            int selectedCustomer = _view.SelectedCustomer >= 0 ? _view.SelectedCustomer : 0;
            _view.CustomerList = customerNames.ToList();
            _view.SelectedCustomer = selectedCustomer;
        }

        public void UpdateCustomerListView(int p)
        {
            Customer customer = _repository.GetCustomer(p);
            _view.CustomerName = customer.Name;
            _view.Address = customer.Address;
            _view.Phone = customer.Phone;
        }
        public void SaveCustomer()
        {
            Customer customer = new Customer { Name = _view.CustomerName, Address = _view.Address, Phone = _view.Phone };
            _repository.SaveCustomer(_view.SelectedCustomer,customer);
            UpdateCustomerListView();
        }
        public void AddCustomer()
        {
            Customer customer = new Customer { Name = _view.CustomerName, Address = _view.Address, Phone = _view.Phone };
            _repository.AddCustomer(customer);
            UpdateCustomerListView();
        }
    }
}
