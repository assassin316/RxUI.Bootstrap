using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ReactiveUI;
using RxUI.UWP.Bootstrapping;
using RxUI.UWP.Core.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RxUI.UWP.Views
{
	public sealed partial class HomeView : IViewFor<HomeViewModel>
	{
		public static readonly DependencyProperty ViewModelProperty =
			DependencyProperty.Register(
				nameof(ViewModel),
				typeof(HomeViewModel),
				typeof(HomeView),
				new PropertyMetadata(default(HomeViewModel)));

		public HomeViewModel ViewModel
		{
			get => (HomeViewModel)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (HomeViewModel)value;
		}

		public HomeView()
		{
			this.InitializeComponent();
		}
	}
}
