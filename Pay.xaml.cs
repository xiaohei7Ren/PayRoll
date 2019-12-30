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
    /// Pay.xaml 的交互逻辑
    /// </summary>
    public partial class Pay : Window
    {
        public Pay()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime startdate = Convert.ToDateTime(TextBox1.Text);
            DateTime enddate = Convert.ToDateTime(TextBox2.Text);
            int id = int.Parse(TextBox3.Text);
            PayrollDatabase database = new FunctionPayrollDatabase();
            Employee ee = database.GetEmployee(id);
            Paycheck st = new Paycheck(startdate, enddate);
            double pay = ee.Classification.CalculatePay(st);
            PaydayTransaction pt = new PaydayTransaction(enddate, database);
            pt.Execute();
            Paycheck pc = pt.GetPaycheck(id);
            DateTime date = Convert.ToDateTime(TextBox4.Text);
            if (pc != null && date >= enddate)
            {
                string payMethod = TextBox5.Text;
                database.pay(id, pay, date, payMethod);
                MessageBox.Show("共付 " + pay + " 元", "通知");
            }
            else
            {
                MessageBox.Show("未到支付日期");
            }
        }
    }
}
