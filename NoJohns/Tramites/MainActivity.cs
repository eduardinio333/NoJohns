using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RestSharp;


namespace Tramites
{
	
	[Activity (Label = "Tramites", MainLauncher = true, Icon = "@drawable/logo")]
	public class MainActivity : Activity
	{
		public class Login{
			public string User { get;set;}
			public string Password { get; set;}
			public string Comment{ get; set;}
		}
		/*public override void OnBackPressed()
//		{
			long doublePressInterval_ms = 3000;
			DateTime lastPressTime = DateTime.Now;
			DateTime pressTime = DateTime.Now;
			if ((pressTime - lastPressTime).TotalMilliseconds <= doublePressInterval_ms) 
			{
				Java.Lang.JavaSystem.Exit(0);
			}
		}*/

		protected override void OnCreate (Bundle bundle)
		{
			
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.Login);
			EditText pass = FindViewById<EditText> (Resource.Id.Pass);
			EditText user = FindViewById<EditText>(Resource.Id.User);
			ImageView logo = FindViewById<ImageView> (Resource.Id.Logo);
			user.Text = null;

			button.Click += delegate 
			{
				/*
				var client= new RestClient ("http://nojohns-api.azurewebsites.net/");
				var request= new RestRequest("api/clients/1",Method.GET);
				request.RequestFormat = DataFormat.Json; 
				var response = client.Execute<Login> (request);
				user.Text= response.Data.Comment;
				*/
				var intent = new Intent(this, typeof(Profile));
				StartActivity(intent);
				Finish();
			};
		}
	}
}


