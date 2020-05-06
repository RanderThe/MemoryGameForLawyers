using MemoryGameForLawyers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryGameForLawyers.Quiz
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class QuizPerguntas : ContentPage
  {
    public QuizPerguntas()
    {
      InitializeComponent();      
    }

    private void BtnIniciarQuiz_Clicked(object sender, EventArgs e)
    {
      QuizModel respostasQuiz = new QuizModel();
      Device.BeginInvokeOnMainThread(async () =>
      {
        await App.CreateWaitPage(Color.White, "Carregando jogo");
        await Navigation.PushAsync(new Pergunta1(respostasQuiz)
        {
        });
        await App.DestroiWaitPage();
      });
    }
  }
}