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
using Java.IO;
using Java.Util;
using Android.Provider;
using Android.Telephony.Gsm;
using Xamarin.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(graftest.Droid.ClassAndroid))]
namespace graftest.Droid
{
    class ClassAndroid :Interface
    {
        public bool Send(string Mobile, string TextSms)

        {
            try
            {
                SmsManager.Default.SendTextMessage(Mobile, null, TextSms, null, null);
                return true;
            }
            catch
            {
                return false;
            }
        }



        Android.Net.Uri uri = Telephony.Sms.Inbox.ContentUri;
        public List<string[]> Dslc()
        {
            List<string[]> listBuf = new List<string[]>();
            string[] gg = new string[1];
            try
            {
                //  Cursor c = getContentResolver().query(uri, null, null, null, null);
                //  startManagingCursor(c);
                var ctx = Forms.Context;
                var cursor = ctx.ApplicationContext.ContentResolver.Query(uri, null, null, null, null);

                string[] body = new String[cursor.Count];
                string[] number = new String[cursor.Count];

                if (cursor.MoveToFirst())
                {
                    for (int i = 0; i < cursor.Count; i++)
                    {
                        body[i] = cursor.GetString(cursor.GetColumnIndexOrThrow("body")).ToString();
                        number[i] = cursor.GetString(cursor.GetColumnIndexOrThrow("address")).ToString();
                       

                        cursor.MoveToNext();
                    }
                }
              
                cursor.Close();

                for(int i = 0; i< body.Length;i++)
                {
                    string[] bufMuss = new string[2];
                    bufMuss[0] = number[i];
                    bufMuss[1] = body[i];
                    listBuf.Add(bufMuss);
                }
            }
            catch (Exception ex)
            {
              
            }
            return listBuf;
        }
    }
}