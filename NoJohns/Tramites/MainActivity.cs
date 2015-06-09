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

			// Get our button from the layout resource,
			// and attach an event to it
			Button LoginButton = FindViewById<Button> (Resource.Id.Login);
			Button button1 = FindViewById<Button> (Resource.Id.button1);
			EditText pass = FindViewById<EditText> (Resource.Id.Pass);
			EditText user = FindViewById<EditText>(Resource.Id.User);
			ImageView logo = FindViewById<ImageView> (Resource.Id.Logo);
			Button SignUpButton = FindViewById<Button> (Resource.Id.SignUpButton);
			user.Text = null;
			LoginButton.Click += delegate 
			{
				var a = new ClientRequest ();
				a.Username = user.Text;
				RequestClient aux = new RequestClient ("api/Clients/filter/", a);
				Clients Result = aux.Resultado.First();
				string cliente = aux.response.Content;

				var intent = new Intent(this, typeof(Profile));
				intent.PutExtra("Cliente", cliente);
				//try 
				//{

				if (user.Text==Result.Username && pass.Text==Result.Password)
				{
					StartActivity(intent);
					//Finish();
				}
				else{
					Toast.MakeText(this, "Usuario o Contraseña incorrectos", ToastLength.Short).Show();
				}

				/*}
				catch (SystemException){
					user.Text="invalido";
				}*/

					
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


