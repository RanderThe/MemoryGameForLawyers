using MemoryGameForLawyers.Utils;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryGameForLawyers
{
  public partial class App : Application
  {
    private static WaitPage waitPage = null;
    public App()
    {
      InitializeComponent();

      MainPage = new MainPage();
    }

    protected override void OnStart()
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
          MainPage = new NavigationPage(new Home()
          {
          });
      });
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }

    public async static Task CreateWaitPage(Color color)
    {
      await CreateWaitPage(color, string.Empty);
    }
    public async static Task CreateWaitPage(Color color, string Descricao)
    {
      try
      {
        if (waitPage == null)
        {
          waitPage = new WaitPage(color, Descricao);

          Device.BeginInvokeOnMainThread(async () =>
          {
            await GetCurrentPage().Navigation.PushPopupAsync(waitPage);
          });
          await Task.Delay(1000);

        }
        else
        {
          if (waitPage != null && !waitPage.Mensagem.Equals(Descricao))
          {
            Device.BeginInvokeOnMainThread(() =>
            {
              waitPage.Mensagem = Descricao;
            });
          }
        }
      }
      catch { }
    }

    public async static Task DestroiWaitPage()
    {
      await DestroiWaitPage(false);
    }
    /// <summary>
    /// 
    /// </summary>
    public async static Task DestroiWaitPage(bool FiniskAllPopUps)
    {
      try
      {
        var CollectionPoupStack =
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack;

        if (CollectionPoupStack.Any())
        {
          if (FiniskAllPopUps)
          {
            PopAllPopUoAsybc();
          }
          else
          {
            if (waitPage != null)
            {
              Device.BeginInvokeOnMainThread(async () =>
              {
                await GetCurrentPage().Navigation.RemovePopupPageAsync(waitPage, false);
                waitPage = null;
              });
            }
            else
            {
              PopAllPopUoAsybc();
            }
          }
        }
      }
      catch { }
    }

    private static void PopAllPopUoAsybc()
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
        await GetCurrentPage().Navigation.PopAllPopupAsync(false);
        waitPage = null;
      });
    }

    /// <summary>
    /// Retorna a página corrente
    /// </summary>
    /// <returns></returns>
    public static Xamarin.Forms.Page GetCurrentPage()
    {
      INavigation navigation = Application.Current.MainPage.Navigation;
      if (navigation.NavigationStack.Any())
      {
        return (navigation.NavigationStack[navigation.NavigationStack.Count -1]);
      }
      return null;
    }

    /// <summary>
    /// Verifica se a página é a corrente.
    /// </summary>
    /// <returns></returns>
    public static bool IsCurrent()
    {
      INavigation navigation = Application.Current.MainPage.Navigation;
      if (navigation.NavigationStack.Any())
      {
        return (navigation.NavigationStack[navigation.NavigationStack.Count - 1] == GetCurrentPage());
      }
      return false;
    }

    /// <summary>
    /// Verifica se é a página corrente é a página raiz
    /// </summary>
    /// <returns></returns>
    public static bool IsRootPage()
    {
      INavigation navigationPage = Application.Current.MainPage.Navigation;
      int total_paginas = navigationPage.NavigationStack.Count;
      if (total_paginas > 0)
      {
        Xamarin.Forms.Page rootPage = navigationPage.NavigationStack[0];
        Xamarin.Forms.Page currentPage = navigationPage.NavigationStack[total_paginas - 1];

        return (total_paginas == 1);
      }

      // Nenhuma página empilhada na pilha
      return true;
    }
  }
}
