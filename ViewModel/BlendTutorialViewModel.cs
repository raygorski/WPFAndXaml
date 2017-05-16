namespace UsingMVVMLight.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using GalaSoft.MvvmLight;
	using System.Windows.Input;
	using GalaSoft.MvvmLight.Command;
	using System.Windows.Media;

	public partial class BlendTutorialViewModel: ViewModelBase
	{
		// using the presented skills in the Channel 9 Video DesignXAMLUIBlendM03_Source
		/* This type of class is not really all that much different than other POCOs with
		 *	with the exception that we need things to be Observable and/or able to interact
		 *	with the XAML event/commands/behaviors.
		 *	
		 *	So, we use the MVVMLightLib from Nuget and we tie in some
		 *	of the mvvmlight classes/controls/objects to do the boilerplate
		 *	code to make the objects within and this class Observable
		 *	....Steps 1,2,3 etc.
		 * */  
		//Step 1 add the ICommands that you want to use.
		public ICommand LoadDataCommand { get; set; }

		//Step 2 Set the ICommand equal to a relayCommand in the .Ctor
		public BlendTutorialViewModel()
		{
			LoadDataCommand = new RelayCommand(LoadDataMethod);
		}

		#region Properties
		//Step 3 add some properties but tie in the ObservableObject stuff fromteh 
		private string _LoadDataText = default(string);

		public string LoadDataText
		{
			get { return _LoadDataText; }
			set { Set(() => LoadDataText, ref _LoadDataText, value); }
		}


		private string _ReloadDataText = default(string);

		public string ReloadDataText
		{
			get { return _ReloadDataText; }
			set { Set(() => ReloadDataText, ref _ReloadDataText, value); }
		}


		private Color _Color = Colors.Green;
		public Color Color
		{
			get { return _Color; }
			set { Set(() => Color, ref _Color, value); }
		}

		#endregion

		#region Methods

		public void ReloadDataMethod()
		{
			ReloadDataText = DateTime.Now.ToString("MMM dd yyyy HH:mm:ss");
		}

		private void LoadDataMethod()
		{
			LoadDataText= DateTime.Now.ToString();
		}

		#endregion
	}
}
