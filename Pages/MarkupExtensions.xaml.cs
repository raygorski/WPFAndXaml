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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsingMVVMLight.Pages
{
	/// <summary>
	/// Interaction logic for MarkupExtensions.xaml
	/// </summary>
	public partial class MarkupExtensions : Page
	{
		public MarkupExtensions()
		{
			InitializeComponent();
		}
	}

	public partial class MyMarkupExtension : MarkupExtension
	{

		public MyMarkupExtension() { }

		public string  FirstStr { get; set; }
		public string SecondStr { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return $"{FirstStr} {SecondStr}";
		}
	}
}
