
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
using NoJohns.Portable;
using Newtonsoft.Json;
namespace Tramites
{
	[Activity (Label = "Profile",Icon = "@drawable/logo")]			
	public class Profile : Activity
	{
		protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Profile);
			//int x = Intent.GetIntExtra ("id",0);
			List<Clients> x = (List<Clients>)Intent.GetStringArrayListExtra ("lol");

			TextView plName = FindViewById<TextView> (Resource.Id.plName);
			TextView pAddress = FindViewById<TextView> (Resource.Id.pAddress);
			TextView pPhone = FindViewById<TextView> (Resource.Id.pPhone);
			TextView pMail = FindViewById<TextView> (Resource.Id.pMail);
			ProgressBar pProgressBar = FindViewById<ProgressBar> (Resource.Id.progressBar);

			/*var client= new RestClient ("http://nojohns-api.azurewebsites.net/");
			var request = new NoJohns.Portable.Requests.ClientRequest {Username=user.Text};
			var request1= new RestRequest("api/clients/filter/"+request.ToRequestString(),Method.GET);
			request1.RequestFormat = DataFormat.Json; 
			var response = client.Execute<List<Clients>>(request1);
			var desResponse = JsonConvert.DeserializeObject<List<Clients>>(response.Content);

			plName.Text = desResponse[0].fName +" " + desResponse[0].lName;
			pAddress.Text =desResponse[0].Address;
			pPhone.Text = desResponse[0].Phone;
			pMail.Text = desResponse[0].Mail;*/
			//response.res;
			pMail.Text=x[0].Mail;


		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.mymenu, menu);
			base.OnPrepareOptionsMenu(menu);
			return true;
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Resource.Id.editProfile:
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				Dialog_EditProfile editProfileDialog = new Dialog_EditProfile();
				editProfileDialog.Show(transaction,"dialog fragment");
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}

