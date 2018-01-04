using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using RxUI.UWP.Bootstrapping;
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
	public sealed partial class Shell : Page
	{
		public Shell()
		{
			this.InitializeComponent();

			this.NavigationCacheMode = NavigationCacheMode.Required;

			// we're a "page" not a view, which means we're created by the app, directly
			// this means we don't fit within the ViewModel-first navigation style RxUI gives us
			RoutedViewHost.Router = BootstrapApplication.Current.Router;
		}
	}
}