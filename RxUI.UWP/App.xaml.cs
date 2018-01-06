using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ReactiveUI;
using RxUI.UWP.Bootstrapping;
using RxUI.UWP.Core.ViewModels;
using RxUI.UWP.Views;
using Splat;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RxUI.UWP
{
	public sealed partial class App : BootstrapApplication
	{
		public App()
		{
			this.InitializeComponent();

			var locator = Locator.CurrentMutable;

			locator.RegisterConstant<ILogger>(new Logger());
			locator.RegisterConstant<IScreen>(this);

			Locator.CurrentMutable.RegisterLazySingleton(() => new HomeView(), typeof(IViewFor<HomeViewModel>));
			Locator.CurrentMutable.RegisterLazySingleton(() => new SecondaryView(), typeof(IViewFor<SecondaryViewModel>));
		}

		protected override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
		{
			if (Debugger.IsAttached)
			{
				DebugSettings.EnableFrameRateCounter = false;
				DebugSettings.IsTextPerformanceVisualizationEnabled = false;
				DebugSettings.IsOverdrawHeatMapEnabled = false;

				Observable
					.FromEventPattern<Windows.UI.Xaml.BindingFailedEventHandler, Windows.UI.Xaml.BindingFailedEventArgs>(
						x => DebugSettings.BindingFailed += x,
						x => DebugSettings.BindingFailed -= x)
					.Select(x => x.EventArgs)
					.Subscribe(
						failedBinding =>
						{
							Debugger.Break();
						}
					);
			}

			await Router.Navigate.Execute(new HomeViewModel()).ToTask();
			RootFrame.Navigate(typeof(Shell));
		}

		public class Logger : ILogger
		{
			public void Write(string message, LogLevel logLevel)
			{
				if ((int)logLevel < (int)Level)
				{
					return;
				}

				Debug.WriteLine(message);
			}

			public LogLevel Level { get; set; }
		}
	}
}
