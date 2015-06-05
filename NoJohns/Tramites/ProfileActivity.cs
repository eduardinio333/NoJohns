
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
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Profile);
			string x = Intent.GetStringExtra ("Cliente") ?? "0";
			Clients cliente = JsonConvert.DeserializeObject<List<Clients>> (x).First ();
			TextView plName = FindViewById<TextView> (Resource.Id.plName);
			TextView pAddress = FindViewById<TextView> (Resource.Id.pAddress);
			TextView pPhone = FindViewById<TextView> (Resource.Id.pPhone);
			TextView pMail = FindViewById<TextView> (Resource.Id.pMail);
			ProgressBar pProgressBar = FindViewById<ProgressBar> (Resource.Id.progressBar);
			Button ToComments = FindViewById<Button> (Resource.Id.ToComments);

			plName.Text = cliente.fName +" " + cliente.lName;
			pAddress.Text =cliente.Address;
			pPhone.Text = cliente.Phone;
			pMail.Text = cliente.Mail;
			ToComments.Click += delegate {
				var intent = new Intent(this, typeof(CommentsActivity));
				intent.PutExtra("Id", cliente.Id);
				StartActivity(intent);
			};
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

