using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForms
{
    public interface ISoapService
    {
        string validateUser(string name, string pass);

        string cargarTabla(string tableName);

        string getSetServiceUrl(string newUrl);
    }
}
