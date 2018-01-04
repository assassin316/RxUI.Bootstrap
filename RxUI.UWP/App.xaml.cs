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
	//	static class DependencyResolverExtensions
	//	{
	//		public static void RegisterViewsForViewModels(this IMutableDependencyResolver resolver, Assembly assembly)
	//		{
	//			// for each type that implements IViewFor
	//			foreach (var ti in assembly.DefinedTypes
	//				.Where(ti => ti.ImplementedInterfaces.Contains(typeof(IViewFor)))
	//				.Where(ti => !ti.IsAbstract))
	//			{
	//				var ivf = ti.ImplementedInterfaces.SingleOrDefault(t => t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IViewFor)));

	//				// need to check for null because some classes may implement IViewFor but not IViewFor<T> - we don't care about those
	//				if (ivf != null)
	//				{
	//#pragma warning disable CS0436 // Type conflicts with imported type
	//					var contract = ti.GetCustomAttribute<ViewContractAttribute>()?.Contract;
	//#pragma warning restore CS0436 // Type conflicts with imported type

	//					RegisterType(resolver, ti, ivf, contract);
	//				}
	//			}
	//		}

	//		public static void Register<TService>(this IMutableDependencyResolver resolver, Func<object> factory, string contract = null)
	//		{
	//			resolver.Register(factory, typeof(TService), contract);
	//		}

	//		public static void RegisterConstant<TService>(this IMutableDependencyResolver resolver, TService value, string contract = null)
	//		{
	//			resolver.RegisterConstant(value, typeof(TService), contract);
	//		}

	//		static void RegisterType(IMutableDependencyResolver resolver, TypeInfo ti, Type serviceType, string contract)
	//		{
	//			var factory = TypeFactory(ti.AsType());
	//			if (ti.GetCustomAttribute<LocatorSingleInstanceAttribute>() != null)
	//			{
	//				// *call* factory
	//				resolver.RegisterConstant(factory(), serviceType, contract);
	//			}
	//			else
	//			{
	//				// pass in factory
	//				resolver.Register(factory, serviceType, contract);
	//			}
	//		}

	//		static Func<object> TypeFactory(Type type)
	//		{
	//			return Expression.Lambda<Func<object>>(Expression.New(type.GetConstructor(Type.EmptyTypes))).Compile();
	//		}
	//	}

	public sealed partial class App : BootstrapApplication
	{
		public App()
		{
			this.InitializeComponent();

			var locator = Locator.CurrentMutable;

			locator.RegisterConstant<ILogger>(new Logger());
			locator.RegisterConstant<IScreen>(this);

			//locator.RegisterViewsForViewModels(typeof(App).GetTypeInfo().Assembly);
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
