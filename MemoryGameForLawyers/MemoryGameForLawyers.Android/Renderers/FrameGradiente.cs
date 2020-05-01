using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MemoryGameForLawyers.Custom;
using MemoryGameForLawyers.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrameGradiente), typeof(FrameGradiente))]
namespace MemoryGameForLawyers.Droid.Renderers
{
 public class FrameGradiente: FrameRenderer
  {
    public FrameGradiente(Context context) : base(context)
    {
    }

    private Xamarin.Forms.Color StartColor { get; set; }
    private Xamarin.Forms.Color EndColor { get; set; }


    public override void Draw(Canvas canvas)
    {
      base.Draw(canvas);



      var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0, this.StartColor.ToAndroid(), this.EndColor.ToAndroid(), Android.Graphics.Shader.TileMode.Mirror);



      var paint = new Android.Graphics.Paint()
      {
        Dither = true,
        AntiAlias = true
      };
      paint.SetShader(gradient);
      var rect = new RectF(0, 0, canvas.Width, canvas.Height);

      canvas.DrawRoundRect(rect, 00f, 00f, paint); // set CornerRadius  here 
    }


    protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
    {


      base.OnElementChanged(e);

      if (e.OldElement != null || Element == null)
      {
        return;
      }
      try
      {
        var stack = e.NewElement as CustomFrameGradiente;
        this.StartColor = stack.StartColor;
        this.EndColor = stack.EndColor;

      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
      }
    }
  }
}