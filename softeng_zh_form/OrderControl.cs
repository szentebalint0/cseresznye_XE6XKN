using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using softeng_zh_form.PcShopModels;

namespace softeng_zh_form
{
    public partial class OrderControl : UserControl
    {
        PcShopContext context;

        public OrderControl()
        {
            InitializeComponent();

        }
        private void OrderControl_Load(object sender, EventArgs e)
        {
            context = new();

            customerBindingSource.DataSource = context.Customers.ToList();
            orderHeaderBindingSource.DataSource = context.OrderHeaders.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = from x in context.Customers
                        where x.Name.Contains(textBox1.Text)
                        select x;

            customerBindingSource.DataSource = query.ToList();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var current = customerBindingSource.Current as Customer;

            if (current == null) return;

            var query = from x in context.OrderHeaders
                        where x.CustomerId == current.CustomerId
                        select x;

            orderHeaderBindingSource.DataSource = query.ToList();
        }
    }
}
