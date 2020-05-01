using Xamarin.Forms.Platform.Android;
using Android.Widget;
using System.ComponentModel;
using Xamarin.Forms;
using Android.Graphics;
using Android.Content;
using MemoryGameForLawyers.Droid.Renderers;
using MemoryGameForLawyers.Custom;

[assembly: ExportRendererAttribute(typeof(ColorIconButton), typeof(ColorIconButtonRenderer))]

namespace MemoryGameForLawyers.Droid.Renderers
{
  public class ColorIconButtonRenderer : ViewRenderer<ColorIconButton, ImageView>
  {
    private bool _isDisposed;

    public ColorIconButtonRenderer(Context context) : base(context)
    {
      base.AutoPackage = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (_isDisposed)
      {
        return;
      }
      _isDisposed = true;
      base.Dispose(disposing);
    }

    protected override void OnElementChanged(ElementChangedEventArgs<ColorIconButton> e)
    {
      base.OnElementChanged(e);

      if (Control == null)
      {
        SetNativeControl(new ImageView(Context));
      }

      Control.Click += (sender, args) =>
      {
        var bc = (IButtonController)this.Element;
        bc.SendClicked();
      };

      UpdateBitmap(e.OldElement);
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      base.OnElementPropertyChanged(sender, e);
      if (e.PropertyName == ColorIconButton.SourceProperty.PropertyName)
      {
        UpdateBitmap(null);
      }
      else if (e.PropertyName == ColorIconButton.ForegroundProperty.PropertyName)
      {
        UpdateBitmap(null);
      }
    }

    private void UpdateBitmap(ColorIconButton previous = null)
    {
      if (!_isDisposed && !string.IsNullOrWhiteSpace(Element.Source))
      {
        var d = Context.GetDrawable(Element.Source).Mutate();
        d.SetColorFilter(new LightingColorFilter(Element.Foreground.ToAndroid(), Element.Foreground.ToAndroid()));
        d.Alpha = Element.Foreground.ToAndroid().A;
        Control.SetImageDrawable(d);
        ((IVisualElementController)Element).NativeSizeChanged();
      }
    }
  }
}