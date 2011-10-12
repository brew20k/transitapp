using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CTATransit
{
	public partial class ArrivalViewController : UIViewController, WebServiceAPIDelegate
	{
		List<CTATrainArrival> list;
		
		//loads the ArrivalViewController.xib file and connects it to this object
		public ArrivalViewController () : base ("ArrivalViewController", null)
		{
		
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			CTATrainTrackerAPI api = new CTATrainTrackerAPI();
			
			api.GetStationTraffic(this, "41320");
			
			this.RefreshButton.Clicked += (sender, e) => {
				api.GetStationTraffic(this, "41320");
			};
						
		}
		
		public void renderTableView()
		{							
			UITableView tableView = new UITableView()
			{
				Delegate = new ArrivalTableViewDelegate(list),
				DataSource = new ArrivalTableViewDataSource(list),
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth,
				//BackgroundColor = UIColor.Yellow,
			};
			
			tableView.SizeToFit();
						
			tableView.Frame = new System.Drawing.RectangleF(0, 44, this.View.Frame.Width, this.View.Frame.Height-44);
			
			foreach(UIView subview in this.View.Subviews)
			{
				if(subview.GetType().Name == "UINavigationBar") continue;
				subview.RemoveFromSuperview();	
			}
			
			this.View.AddSubview(tableView);
		}
		
		public void didFinish(WebServiceAPI api)
		{			
			list = ((CTATrainTrackerAPI)api).ArrivalList;
			NavigationBar.TopItem.Title = ((CTATrainTrackerAPI)api).station.stationName;
			renderTableView();
		}
		
		public void failedWithError(WebServiceAPI api, string error)
		{
			list = new List<CTATrainArrival>();
			//list.Add("Finished With Error");
			renderTableView();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		
	}
}
