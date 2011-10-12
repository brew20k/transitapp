using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using MonoTouch.UIKit;
using MonoTouch.Foundation;


namespace CTATransit
{
	public class CTADataSource : UITableViewSource
	{
		List<Arrival> ArrivalList;
		
		public CTADataSource ()
		{
			
			GetStationData();
		}
		
		public void GetStationData()
		{
			// CTA Transit API URL
			string url = "http://lapi.transitchicago.com/api/1.0/ttarrivals.aspx?key=43d63f4a818d44a19d1ddb94afe716a0&mapid=41320";
			
			// Load URL
			XmlDocument doc = new XmlDocument();
			doc.Load(url);
			
			// Select list of arrivals/departures
			XmlNodeList Departures = doc.SelectNodes("/ctatt/eta");
			
			ArrivalList = new List<Arrival>();
			
			string stationName = "";
			
			// Iterate though upcoming arrivals/departures
			foreach(XmlNode Departure in Departures)
			{
				Arrival arrival = new Arrival();
				arrival.stationId = Convert.ToInt32(Departure.SelectSingleNode("staId").InnerText);
				arrival.stopId = Convert.ToInt32(Departure.SelectSingleNode("stpId").InnerText);
				arrival.stationName = Departure.SelectSingleNode("staNm").InnerText;
				arrival.stopDescription = Departure.SelectSingleNode("stpDe").InnerText;
				arrival.runNo = Convert.ToInt32(Departure.SelectSingleNode("rn").InnerText);
				arrival.route = new Route(Departure.SelectSingleNode("rt").InnerText);
				arrival.destinationStation = Departure.SelectSingleNode("destSt").InnerText;
				arrival.destinationName = Departure.SelectSingleNode("destNm").InnerText;
				arrival.trainDirection = Convert.ToInt32(Departure.SelectSingleNode("trDr").InnerText);
				arrival.lastUpdated = Departure.SelectSingleNode("prdt").InnerText;
				arrival.arrivalTime = Departure.SelectSingleNode("arrT").InnerText;
				arrival.isApproaching = Convert.ToBoolean(Convert.ToInt32(Departure.SelectSingleNode("isApp").InnerText));
				arrival.isSchedule = Convert.ToBoolean(Convert.ToInt32(Departure.SelectSingleNode("isSch").InnerText));
				arrival.isFault = Convert.ToBoolean(Convert.ToInt32(Departure.SelectSingleNode("isFlt").InnerText));
				arrival.isDelayed = Convert.ToBoolean(Convert.ToInt32(Departure.SelectSingleNode("isDly").InnerText));
				
				stationName = Departure.SelectSingleNode("staNm").InnerText;
				
				ArrivalList.Add(arrival);
			}
			
			Console.WriteLine(stationName);
			
			foreach(Arrival arr in ArrivalList)
			{
				DateTime arrivalTime = DateTime.ParseExact(arr.arrivalTime, "yyyyMMdd HH:mm:ss", null);
				Console.WriteLine(arr.route.RouteName + " arriving at " + arrivalTime.ToString("h:mm") + " with service towards " + arr.destinationName + "(" + arr.trainDirection + ")");	
			}
			
		}
		
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return ArrivalList.Count;
		}
		
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = null;
			
			cell = new UITableViewCell(UITableViewStyle.Plain, "");
			
			cell.TextLabel.Text = "Hello";
			
			return cell;
		}
	}
}

