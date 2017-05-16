namespace UsingMVVMLight.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using GalaSoft.MvvmLight;
	using System.Collections.ObjectModel;

	public partial class Employee : ObservableObject
	{
		private int _id;
		public int ID
		{
			get { return _id; }
			set {Set<int>(()=> ID, ref _id, value); }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { Set<string>(()=> Name, ref _name, value); }
		}

		private int _age;

		public int Age
		{
			get { return _age; }
			set { Set<int>(()=> Age, ref _age, value); }
		}

		private decimal _salary;

		public decimal Salary
		{
			get { return _salary; }
			set { Set<decimal>(()=> Salary, ref _salary, value); }
		}

		public static ObservableCollection<Employee> GetSampleEmployees()
		{
			ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
			for(int i=0; i<30; i++)
			{
				employees.Add(new Employee
				{
					ID = i + 1,
					Name = $"Name {i + 1}",
					Age = 20 + i,
					Salary = 20000 + (i * 10)
				});
			}
			return employees;
		}
	}
}
