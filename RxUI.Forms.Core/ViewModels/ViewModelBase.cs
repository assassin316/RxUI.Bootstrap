using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Splat;

namespace RxUI.Forms.Core.ViewModels
{
	public abstract class ViewModelBase : ReactiveObject, IRoutableViewModel, ISupportsActivation
	{
		public ViewModelActivator Activator { get; } = new ViewModelActivator();

		public string UrlPathSegment { get; protected set; }

		public IScreen HostScreen { get; protected set; }

		protected ViewModelBase(IScreen hostScreen = null)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
		}
	}
}