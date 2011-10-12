using System;

namespace CTATransit
{
	public class CTATrainRoute
	{
		public CTATrainRoute(string routeCode, string runNo, string direction)
		{
			this.routeCode = routeCode;
			this.runNo = Convert.ToInt32(runNo);
			this.direction = Convert.ToInt32(direction);
			
			switch(routeCode) {
				case "Red":
					routeName = "Red";
					break;
				case "Blue":
					routeName = "Blue";
					break;
				case "Brn":
					routeName = "Brown";
					break;
				case "G":
					routeName = "Green";
					break;
				case "Org":
					routeName = "Orange";
					break;
				case "P":
					routeName = "Purple";
					break;
				case "Pink":
					routeName = "Pink";
					break;
				case "Y":
					routeName = "Yellow";
					break;
			}
		}
		
		public string routeCode { get; set; }
		public string routeName { get; set; }
		public int runNo { get; set; }
		public int direction { get; set; }
	}
}

