using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Disco
    {
        public int IdDisco { get; set; }
        public string Titulo { get; set; }
        public ML.Artista Artista{ get; set; }
        public ML.Genero Genero { get; set; }
        public string Duracion { get; set; }
        public int Anio { get; set; }
        public string Distribuidora { get; set; }
        public int Ventas { get; set; }
        public int Disponibilidad { get; set; }

        public List<object> Discos { get; set; }
        public List<object> Discos2 { get; set; }

    }
}
