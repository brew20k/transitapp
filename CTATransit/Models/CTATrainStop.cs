using System;

namespace CTATransit
{
	public class CTATrainStop
	{
		public CTATrainStop(string stopNumber, string stopDescription)
		{
			this.stopNumber = Convert.ToInt32(stopNumber);
			this.stopDescription = stopDescription;
		}
		
		public int stopNumber { get; set; }
		public string stopDescription { get; set; }
		
	}
}

