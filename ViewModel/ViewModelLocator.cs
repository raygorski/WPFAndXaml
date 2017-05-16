namespace UsingMVVMLight.ViewModel
{
	using GalaSoft.MvvmLight.Ioc;
	using GalaSoft.MvvmLight.Messaging;
	using Microsoft.Practices.ServiceLocation;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows;

	/// <summary>
	/// Contains static references for all the view models in the application
	/// <para> Each view model nees to be registered by/in SimpleIoc in the .Ctor</para>
	/// <para>It also needs to provide an instance of each view model 
	/// ie. a property getter like public MainViewModel MainViewModel {get{}}</para>
	/// <para>This locator is used for databinding and is usually registerd in the app.xaml </para>
	/// </summary>
	public partial class ViewModelLocator
	{
		/// <summary>
		/// .Ctor - instantiate SimpleIoc for the ServiceLocator.SetLocatorProvider
		/// <para>Also register all pertinent view models...and any Messengers</para>
		/// </summary>
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<BlendTutorialViewModel>();
			SimpleIoc.Default.Register<GrepToyViewModel>();
			Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
		}

		/// <summary>
		/// Access to instance of view model
		/// </summary>
		public MainViewModel MainViewModel
		{
			get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
		}

		public BlendTutorialViewModel BlendTutorialViewModel
		{
			get { return ServiceLocator.Current.GetInstance<BlendTutorialViewModel>(); }
		}

		public GrepToyViewModel GrepToyViewModel
		{
			get { return ServiceLocator.Current.GetInstance<GrepToyViewModel>(); }
		}

		private void NotifyUserMethod(NotificationMessage message)
		{
			MessageBox.Show(message.Notification);
		}
	}
}
