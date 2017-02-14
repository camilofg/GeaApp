using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForms.PortableXaml.Models
{
    public class TIPO_NOVEDAD
    {
        public int ID { get; set; }
        public string VALOR { get; set; }
        public string VALOR1 { get; set; }

    }

    public class USUARIO
    {
        public int ID { get; set; }
        public string VALOR { get; set; }
        public string VALOR1 { get; set; }
    }

    public class Configuraciones
    {
        public int ID { get; set; }
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }
    }
}
