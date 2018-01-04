using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.XamForms;
using RxUI.Forms.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxUI.Forms.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ReactiveContentPage<HomeViewModel>
	{
		public HomePage()
		{
			InitializeComponent();
		}
	}
}