using System;

namespace CTATransit
{
	public class Arrival
	{
		public int stationId { get; set; }
		public int stopId { get; set; }
		public string stationName { get; set; }
		public string stopDescription { get; set; }
		public int runNo { get; set; }
		public Route route { get; set; }
		public string destinationStation { get; set; }
		public string destinationName { get; set; }
		public int trainDirection { get; set; }
		public string lastUpdated { get; set; }
		public string arrivalTime { get; set; }
		public bool isApproaching { get; set; }
		public bool isSchedule { get; set; }
		public bool isFault { get; set; }
		public bool isDelayed { get; set; }
	}
}

