using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ReactiveUI;
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
	public sealed partial class SecondaryView : IViewFor<SecondaryViewModel>
	{
		public static readonly DependencyProperty ViewModelProperty =
			DependencyProperty.Register(
				nameof(ViewModel),
				typeof(SecondaryViewModel),
				typeof(HomeView),
				new PropertyMetadata(default(SecondaryViewModel)));

		public SecondaryViewModel ViewModel
		{
			get => (SecondaryViewModel)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (SecondaryViewModel)value;
		}

		public SecondaryView()
		{
			this.InitializeComponent();
		}
	}
}
