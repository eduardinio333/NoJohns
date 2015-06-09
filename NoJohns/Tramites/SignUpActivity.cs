
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
using NoJohns.Portable;
using NoJohns.Portable.Requests;
using RestSharp;
using Newtonsoft.Json;
namespace Tramites
{
	[Activity (Label = "SignUpActivity")]			
	public class SignUpActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SignUp);
			// Create your application here
			EditText Username = FindViewById<EditText>(Resource.Id.sUsername);
			EditText Password = FindViewById<EditText> (Resource.Id.sPassword);
			EditText Mail = FindViewById<EditText> (Resource.Id.sMail);
			EditText fName = FindViewById<EditText> (Resource.Id.sfName);
			EditText lName = FindViewById<EditText> (Resource.Id.slName);
			EditText Address = FindViewById<EditText> (Resource.Id.sAddress);
			EditText Phone = FindViewById<EditText> (Resource.Id.sPhone);
			Button sSingUpButton = FindViewById<Button> (Resource.Id.sSignUpButton);

			// How To Use GET 
			/*sSingUpButton.Click += delegate {
				var a = new ClientRequest ();
				a.Username = Username.Text;
				RequestClient aux = new RequestClient ("api/Clients/filter/", a);
				Clients Result = aux.Resultado.First();
				Password.Text = Result.Password;
				Mail.Text = Result.Mail;
				fName.Text = Result.fName;
				lName.Text = Result.lName;
				Address.Text = Result.Address;
				Phone.Text = Result.Phone;
			};*/
			sSingUpButton.Click += delegate {
				Clients a = new Clients ();
				a.Username = Username.Text;
				a.fName = fName.Text;
				a.lName = lName.Text;
				a.Mail = Mail.Text;
				a.Password = Password.Text;
				a.Phone = Phone.Text;
				a.Address = Address.Text;
				var request = new RequestClient (a);
				if (request.response.Content == "" || request.response.StatusDescription == "Created"){
					Toast.MakeText(this, "Success", ToastLength.Short).Show();
				}
				else{
					Toast.MakeText(this, "Fail", ToastLength.Short).Show();
				}
			};
			/*sSingUpButton.Click += delegate {
				Intent aux = new  Intent (this, typeof(CommentsActivity));
				aux.PutExtra("Id", 1);
				StartActivity(aux);	

			};*/
		}
	}
}

