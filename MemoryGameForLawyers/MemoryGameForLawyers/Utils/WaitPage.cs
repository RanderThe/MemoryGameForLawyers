using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryGameForLawyers.Utils
{
  /// <summary>
  /// Página de espera
  /// </summary>
  [XamlCompilation(XamlCompilationOptions.Compile)]
  class WaitPage : PopupPage
  {
    private Label lblMessage { get; set; }
    private Label lblAguarde { get; set; }
    public Color Coloractivity
    {
      get { return _coloractivity; }
      set
      {
        if (_coloractivity == value)
          return;

        _coloractivity = value;
        OnPropertyChanged(nameof(WaitPage.Coloractivity));
      }
    }
    private Color _coloractivity;

    public string Mensagem
    {
      get { return _mensagem; }
      set
      {
        if (_mensagem == value)
          return;

        _mensagem = value;
        OnPropertyChanged(nameof(WaitPage.Mensagem));
      }
    }
    private string _mensagem;

    public string WaitMensagem
    {
      get { return _waitMensagem; }
      set
      {
        if (_waitMensagem == value)
          return;

        _waitMensagem = value;
        OnPropertyChanged(nameof(WaitPage.WaitMensagem));
      }
    }
    private string _waitMensagem;
    public WaitPage(Color coloractivity, string descricao)
    {
      InitializeComponent();

      Coloractivity = coloractivity;
      Mensagem = descricao;
      WaitMensagem = "Aguarde...";
    }
    private void InitializeComponent()
    {
      lblMessage = new Label()
      {
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
        TextColor = Coloractivity,
        FontAttributes = FontAttributes.Bold,
        VerticalTextAlignment = TextAlignment.Center,
        HorizontalTextAlignment = TextAlignment.Center,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BindingContext = this
      };
      lblMessage.SetBinding<WaitPage>(Label.TextProperty, waitPage => waitPage.Mensagem);
      lblMessage.SetBinding<WaitPage>(Label.TextColorProperty, waitPage => waitPage.Coloractivity);

      lblAguarde = new Label()
      {
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
        Text = "Aguarde...",
        Opacity = 0,
        TextColor = Coloractivity,
        FontAttributes = FontAttributes.Bold,
        VerticalTextAlignment = TextAlignment.Center,
        HorizontalTextAlignment = TextAlignment.Center,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BindingContext = this
      };
      lblAguarde.SetBinding<WaitPage>(Label.TextProperty, waitPage => waitPage.WaitMensagem);
      lblAguarde.SetBinding<WaitPage>(Label.TextColorProperty, waitPage => waitPage.Coloractivity);

      ActivityIndicator activityIndicator =
        new ActivityIndicator()
        {
          IsRunning = true,
          Color = Coloractivity

        };

      Content = new StackLayout
      {
        BackgroundColor = Color.Transparent,
        Children =
        {
         activityIndicator,
         lblMessage,
         lblAguarde

        },
        VerticalOptions = LayoutOptions.Center,
        Padding = new Thickness(20, 10, 20, 10),
      };

      this.BackgroundColor = new Color(0, 0, 0, 0.4);
    }

    protected override bool OnBackgroundClicked()
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
        await lblAguarde.FadeTo(1, 2000, Easing.Linear);
        lblAguarde.Opacity = 1;
        await lblAguarde.FadeTo(0, 1000, Easing.Linear);
      });

      return false;
    }
  }
}
