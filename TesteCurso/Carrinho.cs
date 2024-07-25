using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TesteCurso
{
    public class Carrinho
    {
        public List<Iphone> Iphones { get; set; } = new List<Iphone>();

        public void ArmazenaPedidos(Iphone produtoDoPedido)
        {
            try
            {
                if (produtoDoPedido != null)
                {
                    Iphones.Add(produtoDoPedido);
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Não foi possivel adicionar o {produtoDoPedido} desejado no carrinho".ToString());
            }
        }

        public void RemovePedidos(int id)
        {
            if (Iphones
                != null && id >= 0 && id < Iphones.Count)
            {
                Iphones.RemoveAt(id);
            }
        }

        public List<Iphone> RetornaPedidos()
        {
            return Iphones;
        }

    }

} 



    
    

    

