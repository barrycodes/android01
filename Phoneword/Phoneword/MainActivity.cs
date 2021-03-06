﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Phoneword
{
    [Activity(Label = "Phone Word", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //// Get our button from the layout resource,
            //// and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            string phoneNumber = string.Empty;

            var phonewordText = FindViewById<EditText>(Resource.Id.PhonewordText);
            var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var callButton = FindViewById<Button>(Resource.Id.CallButton);
            var callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);

            translateButton.Click += delegate
            {
                phoneNumber = TranslateNumber.Translate(phonewordText.Text);
                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    callButton.Enabled = true;
                    callButton.Text = "Call " + phoneNumber;
                }
                else
                {
                    callButton.Enabled = false;
                    callButton.Text = "Call";
                }
            };

            callButton.Click += delegate
            {
                var confirmDialog = new AlertDialog.Builder(this);
                confirmDialog.SetMessage("Call " + phoneNumber + "?");
                confirmDialog.SetNeutralButton("Call", delegate
                {
                    phoneNumbers.Add(phoneNumber);
                    callHistoryButton.Enabled = true;

                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumber));
                    StartActivity(callIntent);
                });
                confirmDialog.SetNegativeButton("Cancel", delegate { });
                confirmDialog.Show();
            };

            callHistoryButton.Click += delegate
            {
                var intent = new Intent(this, typeof(CallHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
        }
    }
}

