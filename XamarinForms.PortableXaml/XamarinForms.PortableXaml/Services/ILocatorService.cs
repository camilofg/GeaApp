using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForms.PortableXaml
{
    public interface ILocatorService
    {
        Task<Position>getCurrentLocation();
    }
}
