namespace UsingMVVMLight
{
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


	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
		{
			NavigationService nav = NavigationService.GetNavigationService(this);

			switch (((TreeViewItem)sender).Name)
			{
				case "tviDataBinding":
					MainFrame.Navigate(new Uri("/pages/DataBinding_Tutorial.xaml", UriKind.RelativeOrAbsolute));		
					break;
				case "tviContextMenu":
					MainFrame.Navigate(new Uri("/pages/BlendTutorialWindow.xaml", UriKind.RelativeOrAbsolute));
					break;
				case "tviMarkupExtensions":
					MainFrame.Navigate(new Uri("/pages/MarkupExtensions.xaml", UriKind.RelativeOrAbsolute));
					break;
				case "tviDependencyProperties":
					MainFrame.Navigate(new Uri("/pages/DependencyProperties.xaml", UriKind.RelativeOrAbsolute));
					break;
				case "tviGrep":
					MainFrame.Navigate(new Uri("/pages/MyGrepToy.xaml", UriKind.RelativeOrAbsolute));
					break;
			}
		}
	}
}
