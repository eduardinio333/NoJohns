
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
using Newtonsoft.Json;
using NoJohns.Portable;

namespace Tramites
{
	[Activity (Label = "Commentarios")]			
	public class CommentsActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			List <string> comentarios = new List<string> ();
			var UserId = Intent.Extras.GetInt ("Id");

			//ListAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, comentarios);
			// Create your application here
		}
	}
}

