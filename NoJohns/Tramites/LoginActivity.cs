
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
using System.Threading.Tasks;


namespace Tramites
{
	[Activity (Label = "LoginActivity")]			
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

			var facebook = FindViewById<Button> (Resource.Id.Login);			
			facebook.Click += delegate { LoginToFacebook(true);};

			/*var facebookNoCancel = FindViewById<Button> (Resource.Id.FacebookButtonNoCancel);
			facebookNoCancel.Click += delegate { LoginToFacebook(false);};
		*/

		}

	}
}

