using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// HourlyEmployeeForm.xaml 的交互逻辑
    /// </summary>
    public partial class HourlyEmployeeForm : Window
    {
        public HourlyEmployeeForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //添加
        {
            int id = int.Parse(TextBox1.Text);
            string name = TextBox2.Text;
            string address = TextBox3.Text;
            double hourlyRate = float.Parse(TextBox4.Text);
            PayrollDatabase database = new FunctionPayrollDatabase();
            AddHourlyEmployee addHourlyEmployee = new AddHourlyEmployee(id, name, address, hourlyRate, database);
            addHourlyEmployee.Execute();    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
