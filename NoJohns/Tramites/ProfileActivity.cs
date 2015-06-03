
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
using RestSharp;

namespace Tramites
{
	[Activity (Label = "Profile",Icon = "@drawable/logo")]			
	public class Profile : Activity
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
		protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Profile);
			int x = Intent.GetIntExtra ("id",0);
			//Intent mIntent = getIntent();
			//int intValue = mIntent.getIntExtra("id", 0);
			TextView plName = FindViewById<TextView> (Resource.Id.plName);
			TextView pAddress = FindViewById<TextView> (Resource.Id.pAddress);
			TextView pPhone = FindViewById<TextView> (Resource.Id.pPhone);
			TextView pMail = FindViewById<TextView> (Resource.Id.pMail);
			ProgressBar pProgressBar = FindViewById<ProgressBar> (Resource.Id.progressBar);
			ActionBar actionBar = 


			var client= new RestClient ("http://nojohns-api.azurewebsites.net/");
			var request= new RestRequest("api/clients/"+x.ToString(),Method.GET);
			request.RequestFormat = DataFormat.Json;
			var cancellationTokenSource = new CancellationTokenSource();
			var response = await client.ExecuteTaskAsync<jsonProfile>(request,cancellationTokenSource.Token);
			/*var response = client.ExecuteAsync<jsonProfile> (request, r => {
				if (r.ResponseStatus== ResponseStatus.Completed)
				{
					pMail.Text = "complete";
					pPhone.Text = r.Data.Phone;
				}
				plName.Text=r.Data.fName + " "+ r.Data.lName;

			}); no escribe en mis botones */

			plName.Text = response.Data.fName +" " + response.Data.lName;
			pAddress.Text = response.Data.Address;
			pPhone.Text = response.Data.Phone;
			pMail.Text = response.Data.Mail;
			//response.res;


		}
	}
}

