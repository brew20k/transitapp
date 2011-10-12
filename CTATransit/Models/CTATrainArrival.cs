using System;

namespace CTATransit
{
	public class CTATrainArrival
	{
		public CTATrainStation destination { get; set; }
		public CTATrainRoute route { get; set; }
		
		public CTATrainStop stop { get; set; }
		
		public DateTime lastUpdated { get; set; }
		public DateTime arrivalTime { get; set; }
		
		public bool isApproaching { get; set; }
		public bool isSchedule { get; set; }
		public bool isFault { get; set; }
		public bool isDelayed { get; set; }
	}
}

