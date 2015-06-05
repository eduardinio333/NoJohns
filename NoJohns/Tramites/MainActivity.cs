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
using System.Threading;
using NoJohns.Portable;
using Newtonsoft.Json;
using RestSharp;

namespace Tramites
{
	
	[Activity (Label = "Tramites", MainLauncher = true, Icon = "@drawable/logo")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.Login);
			Button button1 = FindViewById<Button> (Resource.Id.button1);
			EditText pass = FindViewById<EditText> (Resource.Id.Pass);
			EditText user = FindViewById<EditText>(Resource.Id.User);
			ImageView logo = FindViewById<ImageView> (Resource.Id.Logo);
			Button SignUpButton = FindViewById<Button> (Resource.Id.SignUpButton);
			user.Text = null;
			button.Click += delegate 
			{
				var client= new RestClient ("http://nojohns-api.azurewebsites.net/");
				var request = new NoJohns.Portable.Requests.ClientRequest {Username=user.Text};
				var request1= new RestRequest("api/clients/filter/"+request.ToRequestString(),Method.GET);
				request1.RequestFormat = DataFormat.Json; 
				var response = client.Execute<List<Clients>>(request1);
				var desResponse = JsonConvert.DeserializeObject<List<Clients>>(response.Content);
				//List<Clients> subProducts = new List<Clients>(Model.subproduct);
				var intent = new Intent(this, typeof(Profile));
				//intent.PutStringArrayListExtra("lol",(IList<string>)desResponse);
				//intent.PutParcelableArrayListExtra("no",(IList<IParcelable>)desResponse);
				//intent.PutExtra("id",desResponse[0].Id);
				StartActivity(intent);
				try {
					if (user.Text==desResponse[0].Username && pass.Text==desResponse[0].Password)
					{

						//Finish();
						}
					}
				catch (SystemException)
				{
					user.Text="invalido";
				}

					
			};
			SignUpButton.Click += delegate {
				var intent = new Intent(this, typeof(SignUpActivity));
				StartActivity(intent);
			};
			button1.Click += delegate {
				Toast.MakeText (this, "ops", ToastLength.Short).Show();
			};

		}

	}
}


