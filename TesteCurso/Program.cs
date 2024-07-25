


using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using metodos;

namespace TesteCurso

{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var menu = new Menu();

            var empresa = new Empresa();
            //var cliente = new Cliente("",1, 10);
            menu.MenuPrincipal();
          ;

            empresa.CadastrarEmpresa();

            var cliente = new Cliente("", 0, 0);

            cliente.CadastrarCliente();

            //var carrinho = new Carrinho();
           // carrinho.RetornaPedidos();
        }

        
    }   
}


        