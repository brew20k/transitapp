using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CTATransit
{
	public class ArrivalTableViewDataSource : UITableViewDataSource
	{
		static NSString kCellIdentifier = new NSString("MyIdentifier");
		private List<CTATrainArrival> list;
		
		public ArrivalTableViewDataSource(List<CTATrainArrival> list)
		{
			this.list = list;
		}
		
		public override int RowsInSection(UITableView tableView, int section)
		{
			return list.Count;
		}
		
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(kCellIdentifier);
			
			if(cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Value1, kCellIdentifier);	
			}
						
			int minutes = (list[indexPath.Row].arrivalTime.Subtract(DateTime.Now)).Minutes;
														
			string label = list[indexPath.Row].route.routeName + " " + list[indexPath.Row].destination.stationName;
			
			if(list[indexPath.Row].isApproaching) {
				label += " (A)";	
			} else if(list[indexPath.Row].isDelayed) {
				label += " (D)";	
			}
			
			cell.TextLabel.Text = label;
				
			cell.DetailTextLabel.Text = (minutes == 0) ? "Due" : (minutes + " " + (minutes > 1 ? "mins" : "min"));
			
			return cell;
		}

	}

}

