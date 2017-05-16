namespace UsingMVVMLight.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using GalaSoft.MvvmLight;
	using System.Collections.ObjectModel;
	using System.Windows.Input;
	using GalaSoft.MvvmLight.Command;
	using GalaSoft.MvvmLight.Messaging;

	/// <summary>
	/// <para>Using the MVVM Light Library Nuget Package  http://dotnetpattern.com/mvvm-light-toolkit-example
	/// </para>
	/// <para><see cref="2"/> Using MVVM Light and adding EventToCommand functionality http://www.dotnetcurry.com/wpf/1037/mvvm-light-wpf-model-view-viewmodel 
	/// </para>
	/// </summary>
	public partial class MainViewModel: ViewModelBase
	{


		public ICommand LoadEmployeesCommand { get; private set; }
		public ICommand SaveEmployeesCommand { get; private set; }

		/// <summary>
		/// CRef 2
		/// </summary>
		public RelayCommand SearchCommand { get; private set; }

		public MainViewModel()
		{
			LoadEmployeesCommand = new RelayCommand(LoadEmployeesMethod);
			SaveEmployeesCommand = new RelayCommand(SaveEmployeesMethod);

			// Cref 2
			SearchCommand = new RelayCommand(FindEmployee);
		}

		#region Properties

		private string _searchEmp;

		public string EmpTofind
		{
			get { return _searchEmp; }
			set { Set<string>(()=>EmpTofind, ref _searchEmp, value); }
		}


		private ObservableCollection<Employee> employees;
		public ObservableCollection<Employee> EmployeeList
		{
			get { return employees; }
		}

		private Employee selectedEmployee;
		public Employee SelectedEmployee
		{
			get { return selectedEmployee; }
			set
			{
				selectedEmployee = value;
				RaisePropertyChanged(()=> SelectedEmployee);
			}
		}
		#endregion

		#region Methods

		private void FindEmployee()
		{
			var emp = EmployeeList.FirstOrDefault(s => s.Name.ToLower().Contains(_searchEmp.ToLower().Trim())) as Employee;
			if (emp != null) SelectedEmployee = emp;
		}
		private void SaveEmployeesMethod()
		{
			Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Saved."));
		}

		private void LoadEmployeesMethod()
		{
			employees = Employee.GetSampleEmployees();
			RaisePropertyChanged(() => EmployeeList);
			Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Loaded."));
		}
	}
	#endregion
}
