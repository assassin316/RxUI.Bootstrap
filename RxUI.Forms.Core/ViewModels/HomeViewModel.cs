using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace RxUI.Forms.Core.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		public HomeViewModel(IScreen host = null)
			: base(host)
		{
			UrlPathSegment = nameof(HomeViewModel);
		}
	}
}