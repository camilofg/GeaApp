using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ModelLayer.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Logo { get; set; }
        public string Clave { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        
    }

    public class Photograph {
        public string photoName { get; set; }
        public string file { get; set; }
    }

    public class Position
    {
        public int UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Accuracy { get; set; }
        public int BatteryRemaining { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
     
    }
    
}