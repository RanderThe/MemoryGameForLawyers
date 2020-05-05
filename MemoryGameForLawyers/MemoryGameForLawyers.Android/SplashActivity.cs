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

namespace MemoryGameForLawyers.Droid
{

  [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
  public class SplashActivity : Activity
  {
    System.Timers.Timer timer = null;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.SplashLayout);

      timer = new System.Timers.Timer();
      timer.Interval = 2000;
      timer.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
      timer.Start();
    }

    void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      timer.Stop();
      StartActivity(typeof(MainActivity));
      Finish();
    }
  }
}