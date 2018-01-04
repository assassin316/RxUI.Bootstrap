using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ReactiveUI;
using RxUI.WPF.Core.ViewModels;
using Splat;

namespace RxUI.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Locator.CurrentMutable.RegisterLazySingleton(() => new HomeWindow(), typeof(IViewFor<HomeViewModel>));
		}
	}
}
