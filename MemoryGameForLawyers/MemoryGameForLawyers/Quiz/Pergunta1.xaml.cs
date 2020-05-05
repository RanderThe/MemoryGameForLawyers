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
  public partial class Pergunta1 : ContentPage
  {
    public Pergunta1()
    {
      Title = "Pergunta 1";
      InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      if (Btn0.BorderColor == Color.White)
      {
        Btn0.BorderColor = Color.LightGreen;
        Btn1.BorderColor = Color.White;
        Btn2.BorderColor = Color.White;
        Btn3.BorderColor = Color.White;
      }
      else if(Btn0.BorderColor == Color.LightGreen)
      {
        Btn0.BorderColor = Color.White;
      }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
      if (Btn1.BorderColor == Color.White)
      {
        Btn0.BorderColor = Color.White;
        Btn1.BorderColor = Color.LightGreen;
        Btn2.BorderColor = Color.White;
        Btn3.BorderColor = Color.White;
      }
      else if (Btn1.BorderColor == Color.LightGreen)
      {
        Btn1.BorderColor = Color.White;
      }
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
      if (Btn2.BorderColor == Color.White)
      {
        Btn0.BorderColor = Color.White;
        Btn1.BorderColor = Color.White;
        Btn2.BorderColor = Color.LightGreen;
        Btn3.BorderColor = Color.White;
      }
      else if (Btn2.BorderColor == Color.LightGreen)
      {
        Btn2.BorderColor = Color.White;
      }
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
      if (Btn3.BorderColor == Color.White)
      {
        Btn0.BorderColor = Color.White;
        Btn1.BorderColor = Color.White;
        Btn2.BorderColor = Color.White;
        Btn3.BorderColor = Color.LightGreen;
      }
      else if (Btn3.BorderColor == Color.LightGreen)
      {
        Btn3.BorderColor = Color.White;
      }
    }
  }
}