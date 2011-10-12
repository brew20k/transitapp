using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CTATransit
{
	public class ArrivalTableViewDelegate : UITableViewDelegate
	{
		private List<CTATrainArrival> list;
		
		public ArrivalTableViewDelegate (List<CTATrainArrival> list)
		{
			this.list = list;
		}
		
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true); 
		}
	}
}

