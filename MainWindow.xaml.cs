using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Payroll;
using System.Data;

namespace PayrollUi
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            PayrollDatabase database = new FunctionPayrollDatabase();
            Lable1.Content = database.ShowEmployeeCount1();
            Lable2.Content = database.ShowEmployeeCount2();
            Lable3.Content = database.ShowEmployeeCount3();
            Lable4.Content = database.ShowEmployeeCount4();

            this.DataGrid1.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid1_LoadingRow);//datagrid1中自动标号
            this.DataGrid2.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid2_LoadingRow);//datagrid2中自动标号
            this.DataGrid3.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid3_LoadingRow);//datagrid3中自动标号
            this.DataGrid4.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid4_LoadingRow);//datagrid4中自动标号
            this.DataGrid5.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid5_LoadingRow);//datagrid5中自动标号
        }
        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)//datagrid1中自动标号
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        private void DataGrid2_LoadingRow(object sender, DataGridRowEventArgs e)//datagrid2中自动标号
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        private void DataGrid3_LoadingRow(object sender, DataGridRowEventArgs e)//datagrid3中自动标号
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        private void DataGrid4_LoadingRow(object sender, DataGridRowEventArgs e)//datagrid4中自动标号
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        private void DataGrid5_LoadingRow(object sender, DataGridRowEventArgs e)//datagrid4中自动标号
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //添加小时工界面
        {
            HourlyEmployeeForm win = new HourlyEmployeeForm();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //添加销售员工界面
        {
            CommissionedEmployee win = new CommissionedEmployee();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) //添加普通员工界面
        {
            SalariedEmployeeForm win = new SalariedEmployeeForm();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //刷新所有员工信息
        {
            string connString = @"Data Source=(local);Initial Catalog=Employeedb;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string sqlStr = "select * from HourlyEmployee";
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlStr, connString);
            sqlDataAdapter.Fill(dataSet, "HourlyEmployee");
            DataView dataView = new DataView(dataSet.Tables["HourlyEmployee"]);
            DataGrid1.ItemsSource = dataView;

            string sqlStr1 = "select * from CommissionedEmployee";
            DataSet dataSet1 = new DataSet();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlStr1, connString);
            sqlDataAdapter1.Fill(dataSet1, "CommissionedEmployee");
            DataView dataView1 = new DataView(dataSet1.Tables["CommissionedEmployee"]);
            DataGrid2.ItemsSource = dataView1;

            string sqlStr2 = "select * from SalariedEmployee";
            DataSet dataSet2 = new DataSet();
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlStr2, connString);
            sqlDataAdapter2.Fill(dataSet2, "SalariedEmployee");
            DataView dataView2 = new DataView(dataSet2.Tables["SalariedEmployee"]);
            DataGrid3.ItemsSource = dataView2;

            string sqlStr3 = "select * from TimeCard";
            DataSet dataSet3 = new DataSet();
            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlStr3, connString);
            sqlDataAdapter3.Fill(dataSet3, "TimeCard");
            DataView dataView3 = new DataView(dataSet3.Tables["TimeCard"]);
            DataGrid4.ItemsSource = dataView3;

            string sqlStr4 = "select * from SalesReceipt";
            DataSet dataSet4 = new DataSet();
            SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlStr4, connString);
            sqlDataAdapter4.Fill(dataSet4, "SalesReceipt");
            DataView dataView4 = new DataView(dataSet4.Tables["SalesReceipt"]);
            DataGrid5.ItemsSource = dataView4;
            sqlConnection.Close();

            PayrollDatabase database = new FunctionPayrollDatabase();
            Lable1.Content = database.ShowEmployeeCount1();
            Lable2.Content = database.ShowEmployeeCount2();
            Lable3.Content = database.ShowEmployeeCount3();
            Lable4.Content = database.ShowEmployeeCount4();
        }


        private void MenuItem_Click_3(object sender, RoutedEventArgs e)//删除员工界面
        {
            DeleteEmployee win = new DeleteEmployee();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)//添加考勤记录界面
        {
            AddTimeCard win = new AddTimeCard();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)//支付小时工薪水界面
        {
            PHourlyEmployee win = new PHourlyEmployee();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)//添加销售记录界面
        {
            AddSalesReceipt win = new AddSalesReceipt();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)//支付临时工界面
        {
            PHourlyEmployee win = new PHourlyEmployee();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)//支付销售员工薪水
        {
            PCommissionedEmployee win = new PCommissionedEmployee();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)//支付普通员工薪水
        {
            PSalariedEmployee win = new PSalariedEmployee();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
