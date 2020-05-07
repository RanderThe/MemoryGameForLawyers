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
    public const string Professor = "Ministra aulas, prepara o material didático das aulas de Direito conforme orientação e conteúdo previamente distribuído, aplica provas, desenvolve trabalhos em aula e esclarece dúvidas.";
    public const string JulgadorDeLicitacao = "Exerçam a função de receber, examinar e julgar todos os documentos e procedimentos relativos às licitações e ao cadastramento de licitantes, conforme o artigo 6º, XVI da Lei 8666/93.";
    public const string GerenteJuridico = "Atua como gestor e mentor, contribuindo para a formação dos membros da equipe. É responsável por uma adequação jurídica completa na empresa, devendo ter uma clara comunicação com diversos outros setores da organização.";
    public const string AuditorJuridico = "Assessorar e coordenar a revisão de processos de qualquer natureza, ou proceder a avaliação de uma ou diversas situações concretas que lhe são apresentadas para que emita um parecer vinculante, observando princípios éticos e legais.";
    public string[] descricoes = new string[4] { Professor, JulgadorDeLicitacao, GerenteJuridico, AuditorJuridico };

    QuizModel _quizModel;
    public QuizResult(QuizModel quizModel)
    {
      _quizModel = quizModel;
      Title = "Resultado";
      InitializeComponent();
      SetProfissao();
    }
    public void SetProfissao()
    {
      int max;
      List<int> items = new List<int> { _quizModel.auditorJuridico, _quizModel.professor, _quizModel.julgadorDeLicitacao, _quizModel.gerenteJuridico };

      max = items.Max();

      if (max == _quizModel.auditorJuridico)
      {
        LabelNameProfissao.Text = "Auditor Jurídico";
        ImgProfissional.Source = "auditorFeminino";
        LabelDescricaoProfissao.Text = descricoes[3];
      }
      else if (max == _quizModel.professor)
      {
        LabelNameProfissao.Text = "Professor";
        ImgProfissional.Source = "teacherFeminino";
        LabelDescricaoProfissao.Text = descricoes[0];
      }
      else if (max == _quizModel.julgadorDeLicitacao)
      {
        LabelNameProfissao.Text = "Julgador de Licitação";
        ImgProfissional.Source = "executivoFeminino";
        LabelDescricaoProfissao.Text = descricoes[1];
      }
      else if (max == _quizModel.gerenteJuridico)
      {
        LabelNameProfissao.Text = "Gerente Jurídico";
        ImgProfissional.Source = "gerenteMasculino";
        LabelDescricaoProfissao.Text = descricoes[2];
      }
    }

    private void Finalizar_Clicked(object sender, EventArgs e)
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
        await App.CreateWaitPage(Color.White, "Voltando");
        await Navigation.PushAsync(new Home()
        {
        });
        await App.DestroiWaitPage();
      });
    }
  }
}