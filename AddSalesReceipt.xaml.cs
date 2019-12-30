using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Payroll;

namespace PayrollUi
{
    /// <summary>
    /// AddSalesReceipt.xaml 的交互逻辑
    /// </summary>
    public partial class AddSalesReceipt : Window
    {
        public AddSalesReceipt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBox1.Text);
            int amount = int.Parse(TextBox2.Text);
            DateTime time = DateTime.Now;
            PayrollDatabase database = new FunctionPayrollDatabase();
            SalesReceiptTransaction salesReceipt = new SalesReceiptTransaction(time, amount, id, database);
            salesReceipt.Execute();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
