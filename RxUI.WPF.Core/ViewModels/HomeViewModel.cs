using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace RxUI.WPF.Core.ViewModels
{
	public class HomeViewModel : ReactiveObject
	{
		public string UrlPathSegment { get; set; }

		public HomeViewModel()
		{
			UrlPathSegment = nameof(HomeViewModel);
		}
	}
}