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

namespace UsingMVVMLight.Pages
{
	/// <summary>
	/// Interaction logic for MyGrepToy.xaml
	/// </summary>
	public partial class MyGrepToy : Page
	{
		public MyGrepToy()
		{
			InitializeComponent();

		}



		public void Page_Loaded(object sender, RoutedEventArgs e)
		{
			// this is needed to force the validation rules to be checked.
			SearchDirBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
			SearchStringBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
			FileExtensionBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
		}

	}
}
