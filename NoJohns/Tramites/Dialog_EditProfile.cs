﻿using System;
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
	public class Dialog_EditProfile: DialogFragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate (Resource.Layout.Dialog_editProfile, container, false);
			EditText mtext = view.FindViewById<EditText> (Resource.Id.text1);
			return view;
		}
		public override void OnActivityCreated(Bundle savedInstanceState){
			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
		
		}
	}
}

