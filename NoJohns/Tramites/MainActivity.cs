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
			//StartActivity (typeof(LoginActivity));
			Button NewRequest = FindViewById<Button>(Resource.Id.Request);
			ListView Recientes = FindViewById<ListView> (Resource.Id.Recent);
			var Procedimientos = new List<string> ();
			var parametros = new ProcedureRequest ();
			parametros.Status = false;
			var aux = new RequestProcedures ("api/procedures/filter", parametros);
			var myStack = new Stack<Procedures> (aux.Resultado);
			for (int i = 0; i < 10; i++) {
				Procedimientos.Add (myStack.Pop ().Description);
			}
			var adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, Procedimientos);
			Recientes.Adapter = adapter;
			//button1.Click += delegate {
				/*ProgressDialog progress = new ProgressDialog(this);
				progress.Indeterminate = true;
				progress.SetProgressStyle(ProgressDialogStyle.Spinner);
				progress.SetMessage("Contacting server. Please wait...");
				progress.SetCancelable(false);
				progress.Show();*/
			//};

		}
	}
}


