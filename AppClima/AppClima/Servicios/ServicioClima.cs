using System;
using System.Collections.Generic;
using System.Text;


using AppClima.Clases;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AppClima.Servicios
{
    static class ServicioClima
    {
        static string Key = "138e21fa275f7e1f73c8609608e54137";


        public static async Task<Clima> ConsultarClima(string ciudad)
        {
            // string clave = "138e21fa275f7e1f73c8609608e54137";
            var conexion = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid=138e21fa275f7e1f73c8609608e54137";
            using (var cliente = new HttpClient())
            {
                var peticion = await cliente.GetAsync(conexion);//peticion URL
                if (peticion != null)
                {
                    var json = peticion.Content.ReadAsStringAsync().Result;
                    //   var json = await peticion.Content.ReadAsStringAsync();

                    var datos = (JContainer)JsonConvert.DeserializeObject(json);

                    if (datos["weather"] != null)
                    {
                        var clima = new Clima();
                        clima.Titulo = (string)datos["name"];
                        clima.Tempertura = ((float)datos["main"]["temp"] - 273.15).ToString("N2") + " oC";
                        clima.Viento = (string)datos["wind"]["speed"] + " mph";
                        clima.Humedad = (string)datos["main"]["humidity"] + " %";
                        clima.Visibildad = (string)datos["weather"][0]["main"];

                        var fechaBase = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        var amanecer = fechaBase.AddSeconds((double)datos["sys"]["sunrise"]);
                       var ocaso = fechaBase.AddSeconds((double)datos["sys"]["sunset"]);
                        clima.Amanecer = amanecer.ToString() + " UTC";
                        clima.Ocaso = ocaso.ToString() + " UTC";
                        return clima;
                    }

                }
            }
            return default(Clima);
        }
    }
}