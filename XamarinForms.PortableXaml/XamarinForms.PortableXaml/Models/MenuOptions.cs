using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForms.PortableXaml.Models
{
    public class MenuOptions
    {
        public string Name { get; set; }
        public string Imagen { get; set; }
        public string BackGroundColor { get; set; }
        public bool EPPvalidation { get; set; }
        public bool IsHeader { get; set; }

        public MenuOptions() { }
    }
}
