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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;

namespace Macros_Keyboard
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static SerialPort serialPort;


		public MainWindow()
		{
			InitializeComponent();
		}

		public void GetSerialPortList()
		{
			com_port_selector.ItemsSource = SerialPort.GetPortNames();
		}

		private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		{
			SerialPort sp = (SerialPort)sender;
			string indata = sp.ReadExisting();
			Console.WriteLine("Data Received: " + indata);
		}
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				DragMove();
		}
		private void ComboBox_Opened(object sender, EventArgs e)
		{
			GetSerialPortList();
		}
	}
}
