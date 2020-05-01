using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MemoryGameForLawyers.Custom
{
  public class ColorIconButton : Button
  {
    #region ForegroundProperty

    public static readonly BindableProperty ForegroundProperty = BindableProperty.Create(nameof(Foreground), typeof(Color), typeof(ColorIconButton), default(Color));

    public Color Foreground
    {
      get
      {
        return (Color)GetValue(ForegroundProperty);
      }
      set
      {
        SetValue(ForegroundProperty, value);
      }
    }

    #endregion

    #region SourceProperty
    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(ColorIconButton), default(string));

    public string Source
    {
      get
      {
        return (string)GetValue(SourceProperty);
      }
      set
      {
        SetValue(SourceProperty, value);
      }
    }
    #endregion
  }
}
