using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using NoJohns.Portable;
using NoJohns.Portable.Requests;

namespace Tramites
{
	public class RequestProcedures : Requests
	{
		public RequestProcedures (string URL, ProcedureRequest Parametros)
		{
			string aux = URL + Parametros.ToRequestString ();
			request = new RestRequest (aux, Method.GET);
			response = client.Execute<List<Procedures>>(request);
			Resultado = JsonConvert.DeserializeObject<List<Procedures>> (response.Content);
		}
		public List<Procedures> Resultado{ get; set; }
		public IRestResponse response {get;set;}
	}
}


