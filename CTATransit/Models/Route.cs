using System;

namespace CTATransit
{
	public class Route
	{
		public Route(string routeCode)
		{
			routeCode = routeCode;
			
			switch(routeCode) {
				case "Red":
					RouteName = "Red";
					break;
				case "Blue":
					RouteName = "Blue";
					break;
				case "Brn":
					RouteName = "Brown";
					break;
				case "G":
					RouteName = "Green";
					break;
				case "Org":
					RouteName = "Orange";
					break;
				case "P":
					RouteName = "Purple";
					break;
				case "Pink":
					RouteName = "Pink";
					break;
				case "Y":
					RouteName = "Yellow";
					break;
			}
		}
		
		public string RouteCode { get; set; }
		public string RouteName { get; set; }
	}
}

