using System;

namespace CTATransit
{
	public class CTATrainStation
	{
		public CTATrainStation(string stationNumber, string stationName)
		{
			this.stationNumber = Convert.ToInt32(stationNumber);
			this.stationName = stationName;
		}
		
		public int stationNumber { get; set; }
		public string stationName { get; set; }
	}
}

