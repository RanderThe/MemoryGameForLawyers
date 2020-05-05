using MemoryGameForLawyers.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryGameForLawyers
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Home : ContentPage
  {
    public Home()
    {
      InitializeComponent();
    }

    private void BtnMemoryGame_Clicked(object sender, EventArgs e)
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
        await App.CreateWaitPage(Color.White, "Carregando jogo");
        await Navigation.PushAsync(new MemoryGame()
        {
        });
        await App.DestroiWaitPage();
      });
    }

    private void BtnQuiz_Clicked(object sender, EventArgs e)
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
        await App.CreateWaitPage(Color.White, "Carregando jogo");
        await Navigation.PushAsync(new Pergunta1()
        {
        });
        await App.DestroiWaitPage();
      });
    }
  }
}