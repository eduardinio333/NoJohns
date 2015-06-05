using System;
using NoJohns.Portable;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Tramites
{
	public class RequestComments : Requests
	{
		public RequestComments (string URL, NoJohns.Portable.Requests.CommentRequest Parametros)
		{
			string aux = URL + Parametros.ToRequestString ();
			request = new RestRequest (aux, Method.GET);
			response = client.Execute<List<Comments>>(request);
			Resultado = JsonConvert.DeserializeObject<List<Comments>> (response.Content);
		}
		public List<Comments> Resultado{ get; set; }
		public IRestResponse response {get;set;}
	}
}

