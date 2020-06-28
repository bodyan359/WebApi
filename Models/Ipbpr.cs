using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Ipbpr
    {
        public string PrimaryId { get; set; }
        public string Ilosc { get; set; }
        public string Kategoria { get; set; }
        public string DlugoscMieszkania { get; set; }
        public int Cenam { get; set; }
    }
}
