using System;
using System.Linq;
using System.Reactive.Concurrency;
using ReactiveUI;
using RxUI.Forms.Core.ViewModels;
using RxUI.Forms.Core.Views;
using Splat;
using Xamarin.Forms;

namespace RxUI.Forms.Core
{
	public class AppBootstrapper : ReactiveObject, IScreen
	{
		public RoutingState Router { get; protected set; }

		public AppBootstrapper()
		{
			Router = new RoutingState();
			Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

			// Page-ViewModel Registration
			Locator.CurrentMutable.RegisterLazySingleton(() => new HomePage(), typeof(IViewFor<HomeViewModel>));

			this.Router
				.NavigateAndReset
				.Execute(new HomeViewModel())
				.Subscribe();
		}

		public Page CreateMainPage()
		{
			// NB: This returns the opening page that the platform-specific
			// boilerplate code will look for. It will know to find us because
			// we've registered our AppBootstrapper as an IScreen.
			return new ReactiveUI.XamForms.RoutedViewHost();
		}
	}
}