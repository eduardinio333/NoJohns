using System;
using RestSharp;
namespace Tramites
{
	public class Requests
	{
		public Requests ()
		{
			client = new RestClient ("http://nojohns-api.azurewebsites.net");
		}
		public RestClient client { get; set; }
		public RestRequest request { get; set; }

	}
}

