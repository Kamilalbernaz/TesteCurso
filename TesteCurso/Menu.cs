using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metodos;

namespace TesteCurso
{
    public class Menu
    {
        public Empresa Empresa { get; set; }
        public void MenuPrincipal()
        {
            Console.WriteLine("\nOlá, bem vindo ao Menu Inicial! Deseja acessar como cliente ou como empresa?");

            Console.WriteLine("\nDigite [1] para acessar como cliente");
            Console.WriteLine("Digite [2] para acessar como empresa");
         

            var escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Console.Clear();
                    MenuCliente();
                    break;
                case 2:
                    Console.Clear();
                    MenuEmpresa(); 
                    break;

                default:
                    Console.WriteLine("Opção invalida");
                    MenuPrincipal();
                    break;

               
            }
        }
           
        public void MenuCliente()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Cadastro do Cliente!");
            Console.WriteLine("********************");

            Console.WriteLine("\nDigite [1] para iniciar seu cadastro.");
            Console.WriteLine("Digite [2] para acessar  os Iphones disponiveis.");
            Console.WriteLine("Digite [3] para acessar o seu carrinho");
            Console.WriteLine("Digite [4] para excluir algum item do seu carrinho.");
            Console.WriteLine("Digite [5] para finalizar a compra.");


            Console.WriteLine("\nOu digite [0] para voltar ao Menu Principal.");

            var climenu = int.Parse(Console.ReadLine());
            var cliente = new Cliente("1", 1, 1);
            cliente.Empresas = Empresa;
            var iphone = new Iphone();
          
            switch (climenu)
            {
                case 1:
                    Console.Clear();
                    cliente.CadastrarCliente();
                    MenuCliente();
                    break;
                case 2:
                    Console.Clear();
                    cliente.VisualizarIphones();
                    MenuCliente();
                    break;

                case 3:
                    Console.Clear();
                    cliente.AdicionarCarrinho("");
                    MenuCliente();
                    break;

                case 4:
                    Console.Clear();
                    cliente.Excluir(iphone);
                    MenuCliente();
                    break;

                case 0:
                    Console.Clear();
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção invalida, é necessário cadrastrar a empresa.");

                    break;
            }


        }
        public void MenuEmpresa()
        {
            inicio:
            Console.WriteLine("********************");
            Console.WriteLine("Cadastro da empresa!");
            Console.WriteLine("********************");

            Console.WriteLine("\nDigite [1] para cadrastrar os dados da empresa.");
            Console.WriteLine("Digite [2] para cadrastrar os dados dos Iphones");

            Console.WriteLine("\nOu digite [0] para voltar ao Menu Principal.");

            Console.Write("\nDigite a opção desejada:");
            int menu = int.Parse(Console.ReadLine());

            Console.Write("\nLogo após você será redirecoinado para o cadastro do cliente.");

            var empresa = new Empresa();
            var cliente = new Cliente("charles", 124, 12);
            var iphone = new Iphone();

            switch (menu)
            {
                case 1:
                    Console.Clear();
                    Empresa = empresa.CadastrarEmpresa();
                    goto inicio;
                    break;

                case 2:
                    Console.Clear();
                    empresa.CadastrarIphones(2);
                    MenuPrincipal();
                    goto inicio;
                    break;

                case 0:
                    Console.Clear();
                    MenuPrincipal();
                    goto inicio;
                    break;


                default:
                    Console.WriteLine("Opção invalida.");
                    goto inicio;
                   
            }
            Console.WriteLine("Digite [A] para ser direcionado ao Cadrastro do clinete");
        }
    }   
}
