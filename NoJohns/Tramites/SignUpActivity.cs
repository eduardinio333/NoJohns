
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
using RestSharp;
using Newtonsoft.Json;
namespace Tramites
{
	[Activity (Label = "SignUpActivity")]			
	public class SignUpActivity : Activity
	{
		public class jsonProfile{
			public string Username { get;set;}
			public string Password { get; set;}
			public string Mail{ get; set;}
			public string fName{ get; set;}
			public string lName{ get; set;}
			public string Address{ get; set;}
			public string Phone{ get; set;}
		}

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

			sSingUpButton.Click += delegate {
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
			};
		}
	}
}

