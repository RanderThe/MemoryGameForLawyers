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
  public partial class Pergunta7 : ContentPage
  {
    QuizModel _quizModel;
    public Pergunta7(QuizModel quizModel)
    {
      _quizModel = quizModel;
      Title = "Pergunta 7";
      InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      if (Btn0.BorderColor == Color.White)
      {
        Avançar.IsEnabled = true;
        Btn0.BorderColor = Color.LightGreen;
        Btn1.BorderColor = Color.White;
      }
      else if (Btn0.BorderColor == Color.LightGreen)
      {
        Avançar.IsEnabled = false;
        Btn0.BorderColor = Color.White;
      }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
      if (Btn1.BorderColor == Color.White)
      {
        Avançar.IsEnabled = true;
        Btn0.BorderColor = Color.White;
        Btn1.BorderColor = Color.LightGreen;
      }
      else if (Btn1.BorderColor == Color.LightGreen)
      {
        Avançar.IsEnabled = false;
        Btn1.BorderColor = Color.White;
      }
    }

    public void SetProfissao()
    {
      if (Btn0.BorderColor == Color.LightGreen)
      {
        _quizModel.professor++;
        _quizModel.gerenteJuridico++;
      }
      else if (Btn1.BorderColor == Color.LightGreen)
      {
        _quizModel.julgadorDeLicitacao++;
        _quizModel.auditorJuridico++;
      }
    }

    private void Avancar_Clicked(object sender, EventArgs e)
    {
      SetProfissao();
      Device.BeginInvokeOnMainThread(async () =>
      {
        await App.CreateWaitPage(Color.White, "Carregando pergunta 8");
        await Navigation.PushAsync(new Pergunta8(_quizModel)
        {
        });
        await App.DestroiWaitPage();
      });

    }
  }
}