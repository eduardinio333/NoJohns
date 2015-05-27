
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

namespace Tramites
{
	[Activity (Label = "Profile",Icon = "@drawable/logo")]			
	public class Profile : Activity
	{
		public class jsonProfile{
			public string User { get;set;}
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
			SetContentView (Resource.Layout.Profile);

			TextView plName = FindViewById<TextView> (Resource.Id.plName);
			TextView pAddress = FindViewById<TextView> (Resource.Id.pAddress);
			TextView pPhone = FindViewById<TextView> (Resource.Id.pPhone);
			TextView pMail = FindViewById<TextView> (Resource.Id.pMail);
			ImageView MailIcon = FindViewById<ImageView> (Resource.Id.MailIcon);
			ImageView AddressIcon = FindViewById<ImageView> (Resource.Id.AddresIcon);
			ImageView PhoneIcon = FindViewById<ImageView> (Resource.Id.PhoneIcon);
			// Create your application here

			var client= new RestClient ("http://nojohns-api.azurewebsites.net/");
			var request= new RestRequest("api/clients/1",Method.GET);
			request.RequestFormat = DataFormat.Json; 
			var response = client.Execute<jsonProfile> (request);
			plName.Text = response.Data.fName +" " + response.Data.lName;
			pAddress.Text = response.Data.Address;
			pPhone.Text = response.Data.Phone;
			pMail.Text = response.Data.Mail;

		}
	}
}

