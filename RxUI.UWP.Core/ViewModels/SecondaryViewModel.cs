using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Splat;

namespace RxUI.UWP.Core.ViewModels
{
	public class SecondaryViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment { get; set; }

		public IScreen HostScreen { get; }

		public SecondaryViewModel()
		{
			UrlPathSegment = nameof(SecondaryViewModel);

			HostScreen = Locator.Current.GetService<IScreen>();
		}
	}
}