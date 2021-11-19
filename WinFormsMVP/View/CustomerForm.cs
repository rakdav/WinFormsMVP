using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsMVP.Presenter;

namespace WinFormsMVP.View
{
    public partial class CustomerForm : Form,ICustomerView
    {
        private bool _isEditMode = false;
        public CustomerForm()
        {
            InitializeComponent();
        }

        public IList<string> CustomerList 
        {
            get { return (IList<string>)this.listBox1.DataSource; }
            set { this.listBox1.DataSource = value; }
        }
        public int SelectedCustomer 
        {
            get { return listBox1.SelectedIndex; }
            set { listBox1.SelectedIndex = value; }
        }
        public string CustomerName {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Address
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Phone
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public CustomerPresenter Presenter
        {
            private get;
            set;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = _isEditMode;
            textBox2.ReadOnly = _isEditMode;
            textBox3.ReadOnly = _isEditMode;
            _isEditMode = !_isEditMode;
            button1.Text = _isEditMode ? "Save" : "Edit";
            if(!_isEditMode)
            {
                Presenter.SaveCustomer();
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.UpdateCustomerListView(listBox1.SelectedIndex);
        }
    }
}
