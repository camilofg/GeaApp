using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using XamarinForms.PortableXaml.Droid.WebReference;

namespace XamarinForms.PortableXaml.Droid
{
    public class SoapService : ISoapService
    {
        WSInspeccion wsInspeccion;
        public SoapService()
        {
            wsInspeccion = new WSInspeccion();
            //test to override the web reference
            //wsInspeccion.Url = @"http://192.168.0.8/TestAsmxServices/WebServices/TestWS.asmx";
        }

        public string validateUser(string user, string pass)
        {
            return wsInspeccion.ValidaUsuario(user, pass);
        }

        public string cargarTabla(string tableName)
        {
            return wsInspeccion.CargueTablas(tableName);
        }

        public string getSetServiceUrl(string overUrlService) {
            if (!string.IsNullOrEmpty(overUrlService))
                wsInspeccion.Url = overUrlService;
            return wsInspeccion.Url;
        }
    }
}