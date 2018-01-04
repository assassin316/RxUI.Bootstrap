using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Splat;

namespace RxUI.UWP.Core.ViewModels
{
	public class HomeViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment { get; set; }

		public IScreen HostScreen { get; }

		public HomeViewModel()
		{
			UrlPathSegment = nameof(HomeViewModel);

			HostScreen = Locator.Current.GetService<IScreen>();
		}
	}
}