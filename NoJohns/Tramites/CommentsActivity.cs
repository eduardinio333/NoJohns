
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
	public class CommentsActivity : ListActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			List <Comments> comentarios = new List<Comments> ();
			var UserId = Intent.Extras.GetInt ("Id");
			var a = new NoJohns.Portable.Requests.CommentRequest();
			a.ClientId = UserId;
			RequestComments aux = new RequestComments ("api/Comments/filter/", a);
			comentarios = aux.Resultado;
			List <string> items = new List<string> ();
			foreach (var i in comentarios) {
				items.Add (i.Comment);
			}
			ListAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, items);
			
			//ListAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, comentarios);
			// Create your application here
		}
	}
}

