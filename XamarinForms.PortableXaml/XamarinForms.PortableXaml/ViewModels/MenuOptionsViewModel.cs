using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinForms.PortableXaml.Models;

namespace XamarinForms.PortableXaml.ViewModels
{
    
    public class MenuOptionsViewModel : BaseViewModel
    {
        public ObservableCollection<MenuOptions> ListMenu { get; set; }

        public MenuOptionsViewModel() {
            ListMenu = new ObservableCollection<MenuOptions>();
            ListMenu.Add(new MenuOptions { IsHeader = true, BackGroundColor = "B4BCBC", Imagen = "ic_today_black_24dp.png", Name = "Hoy", EPPvalidation = true });
            ListMenu.Add(new MenuOptions { IsHeader = true, BackGroundColor = "FFFFFF", Imagen = "ic_inbox_black_24dp.png", Name = "Buzon de Entrada", EPPvalidation = false });
            ListMenu.Add(new MenuOptions { IsHeader = false, BackGroundColor = "FFFFFF", Imagen = "ic_assignment_black_24dp.png", Name = "Configuración", EPPvalidation = true });
            ListMenu.Add(new MenuOptions { IsHeader = false, BackGroundColor = "FFFFFF", Imagen = "iconosclubes.png", Name = "Inicio", EPPvalidation = false });
            ListMenu.Add(new MenuOptions { IsHeader = false, BackGroundColor = "FFFFFF", Imagen = "iconosclases.png", Name = "Visita 2", EPPvalidation = false });
            //ListMenu.Add(new MenuOptions { IsHeader = false, BackGroundColor = "FFFFFF", Imagen = "iconosherramientas.png", Name = "Herramientas" });
            //ListMenu.Add(new MenuOptions { IsHeader = true, BackGroundColor = "B4BCBC", Imagen = "", Name = "Soporte" });
            //ListMenu.Add(new MenuOptions { IsHeader = false, BackGroundColor = "FFFFFF", Imagen = "info.png", Name = "Acerca de" });

            //Icon = "slideout.png";
        }
    }
}
