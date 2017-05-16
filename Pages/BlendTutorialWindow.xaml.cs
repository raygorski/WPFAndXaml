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
	using System.Windows.Shapes;

	/// <summary>
	/// Interaction logic for BlendTutorialWindow.xaml
	/// </summary>
	public partial class BlendTutorialWindow : Page
	{
		public BlendTutorialWindow()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Button has been clicked");
		}

		private void Bold_Checked(object sender, RoutedEventArgs e)
		{
			txtTut.FontWeight = FontWeights.Bold;
		}

		private void Bold_UnChecked(object sender, RoutedEventArgs e)
		{
			txtTut.FontWeight = FontWeights.Normal;
		}

		private void Italic_Checked(object sender, RoutedEventArgs e)
		{
			txtTut.FontStyle = FontStyles.Italic;
		}

		private void Italic_UnChecked(object sender, RoutedEventArgs e)
		{
			txtTut.FontStyle = FontStyles.Normal;
		}

		private void IncreaseFont_Click(object sender, RoutedEventArgs e)
		{
			if (txtTut.FontSize < 18)
			{
				txtTut.FontSize += 2;
			}
		}

		private void DecreaseFont_Click(object sender, RoutedEventArgs e)
		{
			if (txtTut.FontSize > 10)
			{
				txtTut.FontSize -= 2;
			}
		}


	}
}
