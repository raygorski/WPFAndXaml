namespace UsingMVVMLight.Validators
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Markup;

	[ValueConversion(typeof(ReadOnlyObservableCollection<ValidationError>), typeof(string))]
	public partial class ValidationErrorsToStringConverter : MarkupExtension, IValueConverter
	{
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new ValidationErrorsToStringConverter();
		}
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ReadOnlyObservableCollection<ValidationError> errors = value as ReadOnlyObservableCollection<ValidationError>;

			if(errors == null) { return string.Empty; }

			return string.Join("\n|", (from e in errors
																 select e.ErrorContent as string).ToArray());
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}

	public partial class InverseAndBooleansToBooleanConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values.LongLength > 0)
			{
				foreach (var value in values)
				{
					if (value is bool && (bool)value)
					{
						return false;
					}
				}
			}
			return true;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
