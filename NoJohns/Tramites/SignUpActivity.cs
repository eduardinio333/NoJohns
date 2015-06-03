
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NoJohns.Portable;
using NoJohns.Portable.Requests;
using RestSharp;
using Newtonsoft.Json;
namespace Tramites
{
	[Activity (Label = "SignUpActivity")]			
	public class SignUpActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SignUp);
			// Create your application here
			EditText Username = FindViewById<EditText>(Resource.Id.sUsername);
			EditText Password = FindViewById<EditText> (Resource.Id.sPassword);
			EditText Mail = FindViewById<EditText> (Resource.Id.sMail);
			EditText fName = FindViewById<EditText> (Resource.Id.sfName);
			EditText lName = FindViewById<EditText> (Resource.Id.slName);
			EditText Address = FindViewById<EditText> (Resource.Id.sAddress);
			EditText Phone = FindViewById<EditText> (Resource.Id.sPhone);
			Button sSingUpButton = FindViewById<Button> (Resource.Id.sSignUpButton);

			/*sSingUpButton.Click += delegate {
				var client = new RestClient ("http://nojohns-api.azurewebsites.net/");
				var request = new RestRequest ("api/clients/1/", Method.PUT);
				request.AddParameter("Id",1);
				request.AddParameter("Username", "Memolestasmucho");
				request.AddParameter ("Password", "idontgiveafuck");
				request.AddParameter ("Mail", "lel");
				request.AddParameter ("fName", fName.Text);
				request.AddParameter("lName",lName.Text);
				request.AddParameter("Address",Address.Text);
				request.AddParameter("Phone",Phone.Text);
				var response = client.Execute<jsonProfile>(request);
			};*/
			// How To Use GET 
			/*sSingUpButton.Click += delegate {
				var a = new ClientRequest ();
				a.Username = Username.Text;
				RequestClient aux = new RequestClient ("api/Clients/filter/", a);
				Clients Result = aux.Resultado.First();
				Password.Text = Result.Password;
				Mail.Text = Result.Mail;
				fName.Text = Result.fName;
				lName.Text = Result.lName;
				Address.Text = Result.Address;
				Phone.Text = Result.Phone;
			};*/
			sSingUpButton.Click += delegate {
				Clients a = new Clients ();
				a.Id = 1;
				a.Username = "eduardinio333";
				a.fName = "Eduardo";
				a.lName = "Alonzo";
				a.Mail = "eduardinio33340@gmail.com";
				a.Password = "culo";
				a.Phone = "9982429063";
				a.Address = "Smz 46 Mz 11 Lote 1";
				var request = new RequestClient (a, 1);

			};


		}
	}
}

