namespace UsingMVVMLight.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Command;
	using GalaSoft.MvvmLight.Messaging;
	using UsingMVVMLight.ViewModels;
	using System.Collections.ObjectModel;
	using System.Windows.Forms;
	using System.Windows;

	public partial class GrepToyViewModel : ViewModelBase
	{
		public RelayCommand SearchDirectoryCommand { get; private set; }
		public RelayCommand GetFolderBrowserCommand { get; set; }


		public GrepToyViewModel()
		{
			SearchDirectoryCommand = new RelayCommand(SearchDirectoryMethod);
			GetFolderBrowserCommand = new RelayCommand(GetFolderBrowserMethod);
		}

		#region Methods
		private void GetFolderBrowserMethod()
		{
			using (var dlg = new FolderBrowserDialog() { SelectedPath = @"C:\" })
			{
				SearchDirectory = (dlg.ShowDialog() == DialogResult.OK) ? dlg.SelectedPath : string.Empty;
			}
		}

		private void SearchDirectoryMethod()
		{
			SearchResults = DosFindStr.FindStringValue(SearchDirectory, SearchString, FileExtension);
		}
		#endregion

		#region Properties

		private ObservableCollection<DosFindStrResult> _searchResults;

		public ObservableCollection<DosFindStrResult> SearchResults
		{
			get { return _searchResults; }
			set { Set(() => SearchResults, ref _searchResults, value); }
		}


		private string _searchDirectory = string.Empty;
		public string SearchDirectory
		{
			get { return _searchDirectory; }
			set { Set(() => SearchDirectory, ref _searchDirectory, value); }
		}

		private string _searchString = string.Empty;
		public string SearchString
		{
			get { return _searchString; }
			set { Set(() => SearchString, ref _searchString, value); }
		}

		private string _fileExt = string.Empty;
		public string FileExtension
		{
			get { return _fileExt; }
			set { Set(() => FileExtension, ref _fileExt, value); }
		}


		#endregion
	}
}
