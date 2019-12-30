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
    /// AddTimeCard.xaml 的交互逻辑
    /// </summary>
    public partial class AddTimeCard : Window
    {
        public AddTimeCard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBox1.Text);
            string name = TextBox2.Text;
            DateTime dateTime = DateTime.Now;
            double hours = float.Parse(TextBox3.Text);
            PayrollDatabase database = new FunctionPayrollDatabase();
            TimeCardTransaction timeCard = new TimeCardTransaction(dateTime,hours,id,database);
            timeCard.Execute();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
