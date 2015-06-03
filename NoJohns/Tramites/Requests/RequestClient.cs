using System;
using NoJohns.Portable;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;


namespace Tramites
{
	public class RequestClient : Requests
	{
		public RequestClient (string URL, NoJohns.Portable.Requests.ClientRequest Parametros)
		{
			string aux = URL + Parametros.ToRequestString ();
			request = new RestRequest (aux, Method.GET);
			var response = client.Execute<List<Clients>>(request);
			Resultado = JsonConvert.DeserializeObject<List<Clients>> (response.Content);
		}
		public RequestClient(Clients Parametros, int id){
			string aux = "api/Clients/" + id.ToString ();
			request = new RestRequest (aux, Method.PUT);
			request.AddHeader("Content-Type", "application/json");
			request.AddBody (Parametros);

		}
		public List<Clients> Resultado{ get; set; }
		
	}
}

