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
using NoJohns.Portable.Requests;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace Tramites
{
	
	[Activity (Label = "Tramites", MainLauncher = true, Icon = "@drawable/logo",
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			StartActivity (typeof(LoginActivity));
			// Get our button from the layout resource,
			// and attach an event to it
			Button LoginButton = FindViewById<Button> (Resource.Id.Login);
			Button button1 = FindViewById<Button> (Resource.Id.button1);
			EditText pass = FindViewById<EditText> (Resource.Id.Pass);
			EditText user = FindViewById<EditText>(Resource.Id.User);
			ImageView logo = FindViewById<ImageView> (Resource.Id.Logo);
			Button SignUpButton = FindViewById<Button> (Resource.Id.SignUpButton);
			ProgressBar progressBar = FindViewById<ProgressBar> (Resource.Id.progressBar1);
			progressBar.Visibility = ViewStates.Gone;

			LoginButton.Click += async delegate 
			{
				progressBar.Visibility = ViewStates.Visible;
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
			button1.Click += delegate {
				/*ProgressDialog progress = new ProgressDialog(this);
				progress.Indeterminate = true;
				progress.SetProgressStyle(ProgressDialogStyle.Spinner);
				progress.SetMessage("Contacting server. Please wait...");
				progress.SetCancelable(false);
				progress.Show();*/
			};

		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.mymenu, menu);
			base.OnPrepareOptionsMenu(menu);
			return true;
		}
	}
}


