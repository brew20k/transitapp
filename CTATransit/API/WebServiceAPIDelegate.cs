using System;

namespace CTATransit
{
	public interface WebServiceAPIDelegate
	{
		void didFinish(WebServiceAPI api);
		void failedWithError(WebServiceAPI api, string error);
	}
}

