using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MiniChef.Resources;
using Parse;
using MiniChef.Model;

namespace MiniChef
{
    public partial class MainPage : PhoneApplicationPage
    {
        IEnumerable<ParseObject> receitas;
        List<ReceitaModel> listaReceitas = new List<ReceitaModel>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            CarregaReceitas();
            //teste commit
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected async void CarregaReceitas()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("RECEITAS");
            receitas = await query.FindAsync();


            ReceitaModel receita;

            foreach (ParseObject receitaParse in receitas)
            {
                receita = new ReceitaModel()
                {
                    nome = receitaParse.Get<string>("nome"),
                    descricao = receitaParse.Get<string>("descricao")
                    //foto = receitaParse.Get<string>("foto")
                };
                listaReceitas.Add(receita);
            }

            lstReceitas.ItemsSource = listaReceitas;

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}


    }
}