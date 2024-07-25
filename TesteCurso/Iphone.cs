using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCurso
{
    public class Iphone
    {
            public string Modelo { get; set; }
            public int Ano { get; set; }
            public string Cor { get; set; }
            public decimal Valor { get; set; }
            public bool IsDisponivel { get; set; }
            public int Quantidade { get; set; }
            List<Iphone> Iphones { get; set; }
           
    }


}
