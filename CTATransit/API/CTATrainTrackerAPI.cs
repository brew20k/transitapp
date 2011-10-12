using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CTATransit
{
	public class CTATrainTrackerAPI : WebServiceAPI
	{
		public List<CTATrainArrival> ArrivalList;
		public CTATrainStation station;
		
		public CTATrainTrackerAPI()
		{
			
		}
		
		public void GetStationTraffic(WebServiceAPIDelegate webDelegate, string stationNumber)
		{
			ArrivalList = new List<CTATrainArrival>();
			
			string apiKey = "43d63f4a818d44a19d1ddb94afe716a0";
			string url = "http://lapi.transitchicago.com/api/1.0/ttarrivals.aspx?key=" + apiKey + "&mapid=" + stationNumber;
			
			XmlDocument doc = new XmlDocument();
			doc.Load(url);
			
			// Select list of arrivals/departures
			XmlNodeList Arrivals = doc.SelectNodes("/ctatt/eta");
			
			// Iterate though upcoming arrivals/departures
			foreach(XmlNode xml in Arrivals)
			{
				CTATrainArrival arrival = new CTATrainArrival();
				
				arrival.stop = new CTATrainStop(
					xml.SelectSingleNode("stpId").InnerText,
					xml.SelectSingleNode("stpDe").InnerText
				);
				
				arrival.route = new CTATrainRoute(
					xml.SelectSingleNode("rt").InnerText,
					xml.SelectSingleNode("rn").InnerText,
					xml.SelectSingleNode("trDr").InnerText
				);
				
				arrival.destination = new CTATrainStation(
					xml.SelectSingleNode("destSt").InnerText,
					xml.SelectSingleNode("destNm").InnerText
				);
	
				arrival.lastUpdated = DateTime.ParseExact(xml.SelectSingleNode("prdt").InnerText, "yyyyMMdd HH:mm:ss", null);
				arrival.arrivalTime = DateTime.ParseExact(xml.SelectSingleNode("arrT").InnerText, "yyyyMMdd HH:mm:ss", null);
				
				arrival.isApproaching = Convert.ToBoolean(Convert.ToInt32(xml.SelectSingleNode("isApp").InnerText));
				arrival.isSchedule = Convert.ToBoolean(Convert.ToInt32(xml.SelectSingleNode("isSch").InnerText));
				arrival.isFault = Convert.ToBoolean(Convert.ToInt32(xml.SelectSingleNode("isFlt").InnerText));
				arrival.isDelayed = Convert.ToBoolean(Convert.ToInt32(xml.SelectSingleNode("isDly").InnerText));
				
				station = new CTATrainStation(xml.SelectSingleNode("staId").InnerText, xml.SelectSingleNode("staNm").InnerText);
				
				ArrivalList.Add(arrival);
			}
			
			ArrivalList.Sort(
				delegate(CTATrainArrival ar1, CTATrainArrival ar2) { 
					return ar1.arrivalTime.CompareTo(ar2.arrivalTime);
				}
			);

			webDelegate.didFinish(this);
		}
	}
}

