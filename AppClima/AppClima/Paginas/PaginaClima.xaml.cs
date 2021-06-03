using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppClima.Clases;
using AppClima.Servicios;
using Xamarin.Forms.Internals;

namespace AppClima.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaClima : ContentPage
    {
        public PaginaClima()
        {
            InitializeComponent();
            this.BindingContext = new Clima();
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            //System.Console.WriteLine("CIUDAD ----------------> ", txtCiudad.Text);
            if (!String.IsNullOrEmpty(txtCiudad.Text))
            {
                var clima = await ServicioClima.ConsultarClima(txtCiudad.Text);



                if (clima != null)
                {
                    this.BindingContext = clima;
                    btnBuscar.Text = "Buscar de nuevo";
                }

            }

        }
    }
}