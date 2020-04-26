using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections;
using MemoryGameForLawyers;

namespace MemoryGameForLawyers
{
  // Learn more about making custom code visible in the Xamarin.Forms previewer
  // by visiting https://aka.ms/xamarinforms-previewer
  [DesignTimeVisible(false)]
  public partial class MainPage : ContentPage
  {
    public const string Professor = "Ministra aulas, prepara o material didático das aulas de Direito conforme orientação e conteúdo previamente distribuído, aplica provas, desenvolve trabalhos em aula e esclarece dúvidas.";
    public const string JulgadorDeLicitacao = "Exerçam a função de receber, examinar e julgar todos os documentos e procedimentos relativos às licitações e ao cadastramento de licitantes, conforme o artigo 6º, XVI da Lei 8666/93.";
    public const string GerenteJuridico = "Atua como gestor e mentor, contribuindo para a formação dos membros da equipe. É responsável por uma adequação jurídica completa na empresa, devendo ter uma clara comunicação com diversos outros setores da organização.";
    public const string AuditorJuridico = "Assessorar e coordenar a revisão de processos de qualquer natureza, ou proceder a avaliação de uma ou diversas situações concretas que lhe são apresentadas para que emita um parecer vinculante, observando princípios éticos e legais.";

    public string[] profissionais = new string[4] { "gerenteMasculino", "auditorFeminino", "executivoFeminino", "teacherFeminino" };
    public string[] descricoes = new string[4] { Professor, JulgadorDeLicitacao, GerenteJuridico, AuditorJuridico };
    public MainPage()
    {
      InitializeComponent();
    }

    public void CreateOcupations(ImageButton[] imageOcupations, Label[] labelOcupations)
    {
      for (var i = 0; i < 4; i++)
      {
        imageOcupations[i] = new ImageButton();
        imageOcupations[i].Margin = new Thickness(0);
        imageOcupations[i].Scale = 0.6;
        imageOcupations[i].Padding = new Thickness(0);
        imageOcupations[i].BackgroundColor = Color.Transparent;
        imageOcupations[i].BorderColor = Color.Transparent;
        imageOcupations[i].BorderWidth = 2;
        imageOcupations[i].CornerRadius = 5;

        labelOcupations[i] = new Label();
        labelOcupations[i].Margin = new Thickness(0);
        labelOcupations[i].Padding = new Thickness(0);
        labelOcupations[i].BackgroundColor = Color.Transparent;
        labelOcupations[i].HorizontalOptions = LayoutOptions.Center;
        labelOcupations[i].VerticalOptions = LayoutOptions.Start;
      }
    }

    private void CreateDescriptions(Frame[] frameDescriptions, Label[] labelDescriptions)
    {
      for (int i = 0; i < 4; i++)
      {
        labelDescriptions[i] = new Label();
        labelDescriptions[i].VerticalTextAlignment = TextAlignment.Start;
        labelDescriptions[i].HorizontalTextAlignment = TextAlignment.Center;
        labelDescriptions[i].Margin = new Thickness(0);
        labelDescriptions[i].Padding = new Thickness(0);
        labelDescriptions[i].FontSize = 12;
      }

      for (var i = 0; i < 4; i++)
      {
        frameDescriptions[i] = new Frame();
        frameDescriptions[i].IsVisible = true;
        frameDescriptions[i].HasShadow = true;
        frameDescriptions[i].Margin = new Thickness(2);
        frameDescriptions[i].Padding = new Thickness(3);
        frameDescriptions[i].VerticalOptions = LayoutOptions.Center;
        frameDescriptions[i].HorizontalOptions = LayoutOptions.FillAndExpand;
        frameDescriptions[i].BorderColor = Color.FromHex("#DADEDF");
        frameDescriptions[i].CornerRadius = 5;
        frameDescriptions[i].Content = labelDescriptions[i];
        frameDescriptions[i].Width.ToString("200");
      }
    }


    protected override void OnAppearing()
    {
      base.OnAppearing();

      StackLayout[] StackSorteio = new StackLayout[8];
      Frame[] frameDescriptions = new Frame[4];
      Label[] labelDescriptions = new Label[4];
      Label[] labelOcupations = new Label[4];
      ImageButton[] imageOcupations = new ImageButton[4];


      CreateOcupations(imageOcupations, labelOcupations);
      CreateDescriptions(frameDescriptions, labelDescriptions);

      #region Sorteio OLD
      //var lstProfissionaisSorteados = new List<string>();
      //for (var i = 0; i < 4; i++)
      //{
      //  var profissaoSorteada = Sorteio(profissionais);

      //  if (!lstProfissionaisSorteados.Any(x => x.Contains(profissaoSorteada)))
      //  {
      //    lstProfissionaisSorteados.Add(profissaoSorteada);
      //  }
      //  else
      //  {
      //    i--;
      //  }
      //}
      #endregion

      for (int i = 0; i < 8; i++)
      {
        StackSorteio[i] = new StackLayout();
        StackSorteio[i].Padding = new Thickness(0);
        StackSorteio[i].Margin = new Thickness(0);
        StackSorteio[i].Spacing = 0;
        StackSorteio[i].BackgroundColor = Color.Transparent;
      }

      //Popula view
      //0
      StackSorteio[0].Children.Add(imageOcupations[0]);
      StackSorteio[0].Children.Add(labelOcupations[0]);
      imageOcupations[0].Source = profissionais[0];
      labelOcupations[0].Text = profissionais[0];

      StackSorteio[1].Children.Add(frameDescriptions[0]);
      labelDescriptions[0].Text = descricoes[0];

      //1
      StackSorteio[2].Children.Add(imageOcupations[1]);
      StackSorteio[2].Children.Add(labelOcupations[1]);
      imageOcupations[1].Source = profissionais[1];
      labelOcupations[1].Text = profissionais[1];

      StackSorteio[3].Children.Add(frameDescriptions[1]);
      labelDescriptions[1].Text = descricoes[1];

      //2
      StackSorteio[4].Children.Add(imageOcupations[2]);
      StackSorteio[4].Children.Add(labelOcupations[2]);
      imageOcupations[2].Source = profissionais[2];
      labelOcupations[2].Text = profissionais[2];

      StackSorteio[5].Children.Add(frameDescriptions[2]);
      labelDescriptions[2].Text = descricoes[2];

      //3
      StackSorteio[6].Children.Add(imageOcupations[3]);
      StackSorteio[6].Children.Add(labelOcupations[3]);
      imageOcupations[3].Source = profissionais[3];
      labelOcupations[3].Text = profissionais[3];

      StackSorteio[7].Children.Add(frameDescriptions[3]);
      labelDescriptions[3].Text = descricoes[3];

      foreach (Label item in labelOcupations)
      {
        switch (item.Text)
        {
          case "gerenteMasculino":
            item.Text = "Gerente Jurídico";
            break;
          case "auditorFeminino":
            item.Text = "Auditor Jurídico";
            break;
          case "executivoFeminino":
            item.Text = "Julgador de Licitação";
            break;
          case "teacherFeminino":
            item.Text = "Professor";
            break;
        }
      }

      int[] numbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
      int[] shuffled = numbers.OrderBy(n => Guid.NewGuid()).ToArray();

      StackLayout01.Children.Add(StackSorteio[shuffled[0]]);
      StackLayout02.Children.Add(StackSorteio[shuffled[1]]);
      StackLayout03.Children.Add(StackSorteio[shuffled[2]]);
      StackLayout04.Children.Add(StackSorteio[shuffled[3]]);
      StackLayout05.Children.Add(StackSorteio[shuffled[4]]);
      StackLayout06.Children.Add(StackSorteio[shuffled[5]]);
      StackLayout07.Children.Add(StackSorteio[shuffled[6]]);
      StackLayout08.Children.Add(StackSorteio[shuffled[7]]);

    }


    private static string Sorteio(string[] times)
    {
      var rnd = new Random();

      var r = rnd.Next(times.Length);
      return ((string)times[r]);
    }


    private void ImageButton_Clicked(object sender, EventArgs e)
    {

    }
  }
}
