using System;
using System.Collections.Generic;
using System.Text;

namespace AppClima.Clases
{
   public class Clima
    {
        public string Titulo { get; set; }
        public string Tempertura { get; set; }
        public string Viento { get; set; }
        public string Humedad { get; set; }
        public string Visibildad { get; set; }
        public string Amanecer { get; set; }
        public string Ocaso { get; set; }

        public Clima()
        {
            this.Amanecer = string.Empty;
            this.Humedad = string.Empty;
            this.Ocaso = string.Empty;
            this.Tempertura = string.Empty;
            this.Viento = string.Empty;
            this.Visibildad = string.Empty;
            this.Ocaso = string.Empty;

        }
    }
}
