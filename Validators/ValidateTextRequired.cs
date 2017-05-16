namespace UsingMVVMLight.Validators
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Controls;

	public partial class ValidateTextRequired : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			try
			{
				if (((string)value).Trim().Length > 0)
				{
					//Text = ((string)value).ToString();
					return new ValidationResult(true, null);

				}
				else { return new ValidationResult(false, "This is a required field"); }

			}
			catch(Exception e) { return new ValidationResult(false, $"ValidateTextRequired error: Illegal characters or {e.Message}"); };
		}
	}
}
