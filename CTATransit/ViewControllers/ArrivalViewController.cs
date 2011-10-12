using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CTATransit
{
	public partial class ArrivalViewController : UIViewController
	{
		//loads the ArrivalViewController.xib file and connects it to this object
		public ArrivalViewController () : base ("ArrivalViewController", null)
		{
			
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			ArrivalTableView.Source = new CTADataSource();
			
			
		}
		
		
	}
}
