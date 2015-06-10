using System;
using NoJohns.Portable;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using System.Threading.Tasks;


namespace Tramites
{
	public class RequestClient : Requests
	{
		public RequestClient (string URL, NoJohns.Portable.Requests.ClientRequest Parametros)
		{
			string aux = URL + Parametros.ToRequestString ();
			request = new RestRequest (aux, Method.GET);
			//response = client.Execute<List<Clients>>(request);
			//Resultado = JsonConvert.DeserializeObject<List<Clients>> (response.Content);
		}

		public Task<Clients> GetResponseContentAsync()
		{
			var tcs=new TaskCompletionSource<Clients>();
			client.ExecuteAsync(request, response => {
				Resultado = JsonConvert.DeserializeObject<List<Clients>> (response.Content);
				tcs.SetResult(Resultado[0]);
				clientString = response.Content;
				//
			});
			return tcs.Task;
		}
			
		public RequestClient(Clients Parametros){
			string aux = "api/Clients/";
			if (Parametros.Id == 0)
				request = new RestRequest (aux, Method.POST);
			else {
				aux += Parametros.Id.ToString ();
				request = new RestRequest (aux, Method.PUT);
			}
			request.AddHeader("Content-Type", "application/json");
			request.AddObject(Parametros);
			response = client.Execute<Clients>(request);

		}
		public string getClientString(){
			return clientString;
		}

		private string clientString { get; set; }
		public List<Clients> Resultado{ get; set; }
		public IRestResponse response {get;set;}
		
	}
}

