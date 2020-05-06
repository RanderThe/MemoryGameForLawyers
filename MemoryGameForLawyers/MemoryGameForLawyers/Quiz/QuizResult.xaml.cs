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
  public partial class QuizResult : ContentPage
  {
    QuizModel _quizModel;
    public QuizResult(QuizModel quizModel)
    {
      _quizModel = quizModel;
      Title = "Resultado";
      InitializeComponent();
    }
    public void SetProfissao()
    {
      int max;
      List<int> items = new List<int> { _quizModel.auditorJuridico, _quizModel.professor, _quizModel.julgadorDeLicitacao, _quizModel.gerenteJuridico};

      max = items.Max();

      if (max == _quizModel.auditorJuridico)
      {

      }
      else if (max == _quizModel.professor)
      {

      }
      else if (max == _quizModel.julgadorDeLicitacao)
      {

      }
      else if (max == _quizModel.gerenteJuridico)
      {

      }
    }

  }
}