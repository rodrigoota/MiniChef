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
using Windows.Networking.Connectivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MiniChef
{
    public partial class MainPage : PhoneApplicationPage
    {
        IEnumerable<ParseObject> receitas;
        List<ReceitaModel> listaReceitas = new List<ReceitaModel>();
        List<CategoriaModel> listaCategorias = new List<CategoriaModel>();
        List<IngredienteModel> listaIngredientes = new List<IngredienteModel>();

        // Constructor
        public MainPage()
        {
            InitializeComponent();


            if (getIsInternetAccessAvailable())
            {
                CarregaBanco();
            }
            else
            {
                MessageBox.Show("Sem acesso à internet. Favor verificar.");
            }

        }

        protected async void CarregaBanco()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("RECEITAS");
            receitas = await query.FindAsync();

            ReceitaModel receita;
            CategoriaModel categoria;
            IngredienteModel ingrediente;

            foreach (ParseObject receitaParse in receitas)
            {
                receita = new ReceitaModel();

                receita.nome = receitaParse.Get<string>("nome");
                receita.descricao = receitaParse.Get<string>("descricao");
                receita.data = receitaParse.UpdatedAt;
                receita.tempo = receitaParse.Get<int>("tempo");
                receita.nota = receitaParse.Get<int>("nota");

                //foto
                try
                {
                    ParseFile fotoFile = receitaParse.Get<ParseFile>("foto");
                    receita.foto = fotoFile.Url.ToString();

                    /* baixar imagem por url
                    Image myImage = new Image();
                    myImage.Source = new BitmapImage(new Uri(receita.foto, UriKind.Absolute));
                    LayoutRoot.Children.Add(myImage); */
                } 
                catch
                {
                    receita.foto = "sem imagem";
                }


                //categoria
                List<CategoriaModel> listaCat = new List<CategoriaModel>();

                IList<string> categoriasParse = receitaParse.Get<IList<string>>("categorias");

                foreach (String catParse in categoriasParse)
                {
                    categoria = new CategoriaModel();
                    categoria.descricao = catParse;

                    if (!listaCategorias.Contains(categoria))
                    {
                        listaCategorias.Add(categoria);
                    }

                    listaCat.Add(categoria);
                    
                }
                receita.categorias = listaCat;


                //ingredientes
                List<IngredienteModel> listaIng = new List<IngredienteModel>();

                IList<string> ingredientesParse = receitaParse.Get<IList<string>>("ingredientes");

                foreach (String ingParse in ingredientesParse)
                {
                    ingrediente = new IngredienteModel();
                    ingrediente.descricao = ingParse;
                    string[] IngSep = ingParse.Split(';');

                    ingrediente.descricao = IngSep[0];
                    ingrediente.quantidade = Double.Parse(IngSep[1]);
                    ingrediente.unidadeMedida = IngSep[2];

                    if (!listaIngredientes.Contains(ingrediente))
                    {
                        listaIngredientes.Add(ingrediente);
                    }

                    listaIng.Add(ingrediente);

                }
                receita.ingredientes = listaIng;


                listaReceitas.Add(receita);
            }

            lstReceitas.ItemsSource = listaReceitas;
            //lstReceitas.ItemsSource = listaCategorias;
            //lstReceitas.ItemsSource = listaIngredientes;

        }

        public static bool getIsInternetAccessAvailable()
        {
            switch (NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel())
            {
                case NetworkConnectivityLevel.InternetAccess:
                    return true;
                default:
                    return false;
            }
        }

    }
}