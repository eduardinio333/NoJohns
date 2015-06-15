
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
using Xamarin.Auth;
using System.Json;
using NoJohns;
using NoJohns.Portable.Requests;
using System.Threading.Tasks;


namespace Tramites
{
	[Activity (Label = "LoginActivity", Icon = "@drawable/logo",
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class LoginActivity : Activity
	{
		void LoginToFacebook (bool allowCancel){
			var auth = new OAuth2Authenticator (
				clientId: "903802423009257",
				scope: "",
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri ("http://www.facebook.com/connect/login_success.html"));
			auth.AllowCancel = allowCancel;
			auth.Completed += (s, ee) => {
				if (!ee.IsAuthenticated) {
					var builder = new AlertDialog.Builder (this);
					builder.SetMessage ("Not Authenticated");
					builder.SetPositiveButton ("Ok", (o, e) => { });
					builder.Create().Show();
					return;
				}
				// Now that we're logged in, make a OAuth2 request to get the user's info.
				var request = new OAuth2Request ("GET", new Uri ("https://graph.facebook.com/me"), null, ee.Account);
				request.GetResponseAsync().ContinueWith (t => {
					var builder = new AlertDialog.Builder (this);
					if (t.IsFaulted) {
						builder.SetTitle ("Error");
						builder.SetMessage (t.Exception.Flatten().InnerException.ToString());
					} else if (t.IsCanceled)
						builder.SetTitle ("Task Canceled");
					else {
						var obj = JsonValue.Parse (t.Result.GetResponseText());

						builder.SetTitle ("Logged in");
						builder.SetMessage ("Name: " + obj["name"]);
					}

					builder.SetPositiveButton ("Ok", (o, e) => { });
					builder.Create().Show();
				}, UIScheduler);
			};
			var intent = auth.GetUI (this);
			StartActivity (intent);
		}
		private static readonly TaskScheduler UIScheduler = TaskScheduler.FromCurrentSynchronizationContext();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Login);
			Button LoginButton = FindViewById<Button> (Resource.Id.Login);
			Button button1 = FindViewById<Button> (Resource.Id.button1);
			EditText pass = FindViewById<EditText> (Resource.Id.Pass);
			EditText user = FindViewById<EditText>(Resource.Id.User);
			ImageView logo = FindViewById<ImageView> (Resource.Id.Logo);
			Button SignUpButton = FindViewById<Button> (Resource.Id.SignUpButton);
			//ProgressBar progressBar = FindViewById<ProgressBar> (Resource.Id.progressBar1);
			//ProgressBar progressBar = 
			//progressBar.Visibility = ViewStates.Gone;

			LoginButton.Click += async delegate 
			{
				//progressBar.Visibility = ViewStates.Visible;
				var a = new ClientRequest ();
				a.Username = user.Text;
				RequestClient aux = new RequestClient ("api/Clients/filter/", a);
				var response = await aux.GetResponseContentAsync();
				//var res = JsonConvert.DeserializeObject<List<Clients>> (response);
				if (user.Text==response.Address && pass.Text==response.Password)
				{
					var intent = new Intent(this, typeof(Profile));
					//var client = await aux.GetResponseStringAsync();
					intent.PutExtra("Cliente", aux.getClientString());
					StartActivity(intent);
					//Finish();
				}
				else{
					Toast.MakeText(this, "Usuario o Contraseña incorrectos", ToastLength.Short).Show();
				}

			};
			SignUpButton.Click += delegate {
				var intent = new Intent(this, typeof(SignUpActivity));
				StartActivity(intent);
			};
			var facebook = FindViewById<Button> (Resource.Id.button1);			
			facebook.Click += delegate { LoginToFacebook(true);};

			/*var facebookNoCancel = FindViewById<Button> (Resource.Id.FacebookButtonNoCancel);*/
			//facebookNoCancel.Click += delegate { LoginToFacebook(false);};
		}
		
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.mymenu, menu);
			base.OnPrepareOptionsMenu(menu);
			return true;
		}	
	}
}

