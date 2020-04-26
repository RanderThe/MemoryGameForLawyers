﻿using System;
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
    StackLayout[] stackSorteio;
    List<StackLayout> stackMatched = new List<StackLayout>();
    
    public const string Professor = "Ministra aulas, prepara o material didático das aulas de Direito conforme orientação e conteúdo previamente distribuído, aplica provas, desenvolve trabalhos em aula e esclarece dúvidas.";
    public const string JulgadorDeLicitacao = "Exerçam a função de receber, examinar e julgar todos os documentos e procedimentos relativos às licitações e ao cadastramento de licitantes, conforme o artigo 6º, XVI da Lei 8666/93.";
    public const string GerenteJuridico = "Atua como gestor e mentor, contribuindo para a formação dos membros da equipe. É responsável por uma adequação jurídica completa na empresa, devendo ter uma clara comunicação com diversos outros setores da organização.";
    public const string AuditorJuridico = "Assessorar e coordenar a revisão de processos de qualquer natureza, ou proceder a avaliação de uma ou diversas situações concretas que lhe são apresentadas para que emita um parecer vinculante, observando princípios éticos e legais.";

    public string[] profissionais = new string[4] { "teacherFeminino", "executivoFeminino", "gerenteMasculino", "auditorFeminino" };
    public string[] descricoes = new string[4] { Professor, JulgadorDeLicitacao, GerenteJuridico, AuditorJuridico };
    public MainPage()
    {
      InitializeComponent();
    }

    public void CreateOcupations(Image[] imageOcupations, Label[] labelOcupations, Frame[] frameOcupations, StackLayout[] stackOcupations)
    {
      for (var i = 0; i < 4; i++)
      {
        stackOcupations[i] = new StackLayout();
        stackOcupations[i].Padding = new Thickness(0);
        stackOcupations[i].Margin = new Thickness(0);
        stackOcupations[i].Spacing = 0;
        stackOcupations[i].BackgroundColor = Color.Transparent;

        imageOcupations[i] = new Image();
        imageOcupations[i].Margin = new Thickness(0);
        imageOcupations[i].Scale = 0.6;
        imageOcupations[i].BackgroundColor = Color.Transparent;

        labelOcupations[i] = new Label();
        labelOcupations[i].Margin = new Thickness(0);
        labelOcupations[i].Padding = new Thickness(0);
        labelOcupations[i].BackgroundColor = Color.Transparent;
        labelOcupations[i].HorizontalOptions = LayoutOptions.Center;
        labelOcupations[i].VerticalOptions = LayoutOptions.Start;

        frameOcupations[i] = new Frame();
        frameOcupations[i].IsVisible = true;
        frameOcupations[i].HasShadow = true;
        frameOcupations[i].Margin = new Thickness(2);
        frameOcupations[i].Padding = new Thickness(0);
        frameOcupations[i].VerticalOptions = LayoutOptions.Fill;
        frameOcupations[i].HorizontalOptions = LayoutOptions.Fill;
        frameOcupations[i].BorderColor = Color.FromHex("#DADEDF");
        frameOcupations[i].CornerRadius = 5;

        stackOcupations[i].Children.Add(imageOcupations[i]);
        stackOcupations[i].Children.Add(labelOcupations[i]);
        frameOcupations[i].Content = stackOcupations[i];
      }
    }

    private void CreateDescriptions(Frame[] frameDescriptions, Label[] labelDescriptions)
    {
      #region Create Labels
      for (int i = 0; i < 4; i++)
      {
        labelDescriptions[i] = new Label();
        labelDescriptions[i].VerticalTextAlignment = TextAlignment.Start;
        labelDescriptions[i].HorizontalTextAlignment = TextAlignment.Center;
        labelDescriptions[i].Margin = new Thickness(0);
        labelDescriptions[i].Padding = new Thickness(0);
        labelDescriptions[i].FontSize = 12;
      }
      #endregion

      #region Create Frames
      for (var i = 0; i < 4; i++)
      {
        frameDescriptions[i] = new Frame();
        frameDescriptions[i].IsVisible = true;
        frameDescriptions[i].HasShadow = true;
        frameDescriptions[i].Margin = new Thickness(2);
        frameDescriptions[i].Padding = new Thickness(3);
        frameDescriptions[i].VerticalOptions = LayoutOptions.Fill;
        frameDescriptions[i].HorizontalOptions = LayoutOptions.Fill;
        frameDescriptions[i].BorderColor = Color.FromHex("#DADEDF");
        frameDescriptions[i].CornerRadius = 5;
        frameDescriptions[i].Content = labelDescriptions[i];
        frameDescriptions[i].Width.ToString("200");
      }
      #endregion
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      StackLayout professorImg = new StackLayout();
      StackLayout professorDesc = new StackLayout();
      StackLayout julgadorDeLicitacaoImg = new StackLayout();
      StackLayout julgadorDeLicitacaoDesc = new StackLayout();
      StackLayout gerenteJuridicoImg = new StackLayout();
      StackLayout gerenteJuridicoDesc = new StackLayout();
      StackLayout auditorJuridicoImg = new StackLayout();
      StackLayout auditorJuridicoDesc = new StackLayout();
      stackSorteio = new StackLayout[8] { professorImg, professorDesc, julgadorDeLicitacaoImg, julgadorDeLicitacaoDesc, gerenteJuridicoImg, gerenteJuridicoDesc, auditorJuridicoImg, auditorJuridicoDesc };

      Frame[] frameDescriptions = new Frame[4];
      Label[] labelDescriptions = new Label[4];

      StackLayout[] stackOcupations = new StackLayout[4];
      Frame[] frameOcupations = new Frame[4];
      Label[] labelOcupations = new Label[4];
      Image[] imageOcupations = new Image[4];

      CreateOcupations(imageOcupations, labelOcupations, frameOcupations, stackOcupations);
      CreateDescriptions(frameDescriptions, labelDescriptions);

      //Instancia Stacks
      for (int i = 0; i < 8; i++)
      {
        stackSorteio[i].Padding = new Thickness(0);
        stackSorteio[i].Margin = new Thickness(0);
        stackSorteio[i].Spacing = 0;
        stackSorteio[i].BackgroundColor = Color.Transparent;
      }

      #region Popula view
      //0
      //Professor
      stackSorteio[0].Children.Add(frameOcupations[0]);
      imageOcupations[0].Source = profissionais[0];
      labelOcupations[0].Text = profissionais[0];

      stackSorteio[1].Children.Add(frameDescriptions[0]);
      labelDescriptions[0].Text = descricoes[0];

      //1
      //Julgador De Licitacao
      stackSorteio[2].Children.Add(frameOcupations[1]);
      imageOcupations[1].Source = profissionais[1];
      labelOcupations[1].Text = profissionais[1];

      stackSorteio[3].Children.Add(frameDescriptions[1]);
      labelDescriptions[1].Text = descricoes[1];

      //2
      //Gerente Juridico
      stackSorteio[4].Children.Add(frameOcupations[2]);
      imageOcupations[2].Source = profissionais[2];
      labelOcupations[2].Text = profissionais[2];

      stackSorteio[5].Children.Add(frameDescriptions[2]);
      labelDescriptions[2].Text = descricoes[2];

      //3
      //Auditor Juridico
      stackSorteio[6].Children.Add(frameOcupations[3]);
      imageOcupations[3].Source = profissionais[3];
      labelOcupations[3].Text = profissionais[3];

      stackSorteio[7].Children.Add(frameDescriptions[3]);
      labelDescriptions[3].Text = descricoes[3];
      #endregion

      //Formata nomes das profissões
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

      StackLayout00.Children.Add(stackSorteio[shuffled[0]]);
      StackLayout01.Children.Add(stackSorteio[shuffled[1]]);
      StackLayout02.Children.Add(stackSorteio[shuffled[2]]);
      StackLayout03.Children.Add(stackSorteio[shuffled[3]]);
      StackLayout04.Children.Add(stackSorteio[shuffled[4]]);
      StackLayout05.Children.Add(stackSorteio[shuffled[5]]);
      StackLayout06.Children.Add(stackSorteio[shuffled[6]]);
      StackLayout07.Children.Add(stackSorteio[shuffled[7]]);

    }

    public StackLayout VerificaStackLayout(StackLayout stackSelected)
    {
      if (stackSelected.Children.Contains(stackSorteio[0]))
      {
        return stackSorteio[1];
      }
      if (stackSelected.Children.Contains(stackSorteio[1]))
      {
        return stackSorteio[0];
      }
      if (stackSelected.Children.Contains(stackSorteio[2]))
      {
        return stackSorteio[3];
      }
      if (stackSelected.Children.Contains(stackSorteio[3]))
      {
        return stackSorteio[2];
      }
      if (stackSelected.Children.Contains(stackSorteio[4]))
      {
        return stackSorteio[5];
      }
      if (stackSelected.Children.Contains(stackSorteio[5]))
      {
        return stackSorteio[4];
      }
      if (stackSelected.Children.Contains(stackSorteio[6]))
      {
        return stackSorteio[7];
      }
      if (stackSelected.Children.Contains(stackSorteio[7]))
      {
        return stackSorteio[6];
      }
      return stackSorteio[0];
    }
    public bool VerificaStackLayoutVisible(StackLayout stackOriginalSelected)
    {
      if (stackOriginalSelected.IsVisible)
      {
        return true;
      }
      return false;
    }
    public StackLayout VerificaStackLayoutCorrespondente(StackLayout stackSelected)
    {
      if (StackLayout00.Children.Contains(stackSelected))
      {
        return StackLayout00;
      }
      if (StackLayout01.Children.Contains(stackSelected))
      {
        return StackLayout01;
      }
      if (StackLayout02.Children.Contains(stackSelected))
      {
        return StackLayout02;
      }
      if (StackLayout03.Children.Contains(stackSelected))
      {
        return StackLayout03;
      }
      if (StackLayout04.Children.Contains(stackSelected))
      {
        return StackLayout04;
      }
      if (StackLayout05.Children.Contains(stackSelected))
      {
        return StackLayout05;
      }
      if (StackLayout06.Children.Contains(stackSelected))
      {
        return StackLayout06;
      }
      if (StackLayout07.Children.Contains(stackSelected))
      {
        return StackLayout07;
      }
      return stackSorteio[0];
    }


    #region Click LawIcon
    private void ImageButton_Clicked_0(object sender, EventArgs e)
    {
      StackIconDireito0.IsVisible = false;
      StackLayout00.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout00);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout00);
      }
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
      StackIconDireito1.IsVisible = false;
      StackLayout01.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout01);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout01);
      }
    }

    private void ImageButton_Clicked_2(object sender, EventArgs e)
    {
      StackIconDireito2.IsVisible = false;
      StackLayout02.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout02);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout02);
      }
    }

    private void ImageButton_Clicked_3(object sender, EventArgs e)
    {
      StackIconDireito3.IsVisible = false;
      StackLayout03.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout03);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout03);
      }
    }

    private void ImageButton_Clicked_4(object sender, EventArgs e)
    {
      StackIconDireito4.IsVisible = false;
      StackLayout04.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout04);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout04);
      }
    }

    private void ImageButton_Clicked_5(object sender, EventArgs e)
    {
      StackIconDireito5.IsVisible = false;
      StackLayout05.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout05);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout05);
      }
    }

    private void ImageButton_Clicked_6(object sender, EventArgs e)
    {
      StackIconDireito6.IsVisible = false;
      StackLayout06.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout06);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout06);
      }
    }

    private void ImageButton_Clicked_7(object sender, EventArgs e)
    {
      StackIconDireito7.IsVisible = false;
      StackLayout07.IsVisible = true;
      StackLayout stackOriginalSelected = VerificaStackLayout(StackLayout07);
      StackLayout stackOriginalCorrespondente = VerificaStackLayoutCorrespondente(stackOriginalSelected);

      if (VerificaStackLayoutVisible(stackOriginalCorrespondente))
      {
        stackMatched.Add(stackOriginalCorrespondente);
        stackMatched.Add(StackLayout07);
      }
    }

    #endregion

    #region Click Items

    private void StackLayout00Tapped(object sender, EventArgs e)
    {
      StackIconDireito0.IsVisible = true;
      StackLayout00.IsVisible = false;
    }

    private void StackLayout01Tapped(object sender, EventArgs e)
    {
      StackIconDireito1.IsVisible = true;
      StackLayout01.IsVisible = false;
    }

    private void StackLayout02Tapped(object sender, EventArgs e)
    {
      StackIconDireito2.IsVisible = true;
      StackLayout02.IsVisible = false;
    }

    private void StackLayout03Tapped(object sender, EventArgs e)
    {
      StackIconDireito3.IsVisible = true;
      StackLayout03.IsVisible = false;
    }

    private void StackLayout04Tapped(object sender, EventArgs e)
    {
      StackIconDireito4.IsVisible = true;
      StackLayout04.IsVisible = false;
    }

    private void StackLayout05Tapped(object sender, EventArgs e)
    {
      StackIconDireito5.IsVisible = true;
      StackLayout05.IsVisible = false;
    }

    private void StackLayout06Tapped(object sender, EventArgs e)
    {
      StackIconDireito6.IsVisible = true;
      StackLayout06.IsVisible = false;
    }

    private void StackLayout07Tapped(object sender, EventArgs e)
    {
      StackIconDireito7.IsVisible = true;
      StackLayout07.IsVisible = false;
    }

    #endregion
  }
}