using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TesteCurso;

namespace metodos
    {

    public class Empresa

    {
        public string Loja { get; set; }
        public int CNPJ { get; set; }
        public List<Iphone> Iphones { get; set; }
        public Cliente Cliente { get; set; }


       
      
        
        

        public void CadastrarIphones(int quantidadeModelos)
            
        {
            fim:

            int totalIphones = 0;

            while (totalIphones < quantidadeModelos)
            {
                var iphone = new Iphone();
                try

                {
                    Console.Clear();
                    Console.WriteLine("\nCadrastro de Iphones:");
                    Console.Write("\nDigite o modelo do Iphone:");
                    iphone.Modelo = Console.ReadLine().ToLower().Trim();

                    Console.Write("\nDigite o ano do Iphone:");
                    iphone.Ano = int.Parse(Console.ReadLine().Trim());

                    Console.Write("\nDigite a cor do Iphone:");
                    iphone.Cor = Console.ReadLine();

                    Console.Write("\nDigite o valor do Iphone:");
                    iphone.Valor = decimal.Parse(Console.ReadLine());

                    Console.Write($"\nDigite quantas unidades do Iphone vão estar diponíveis para o cliente:");
                    iphone.Quantidade = int.Parse(Console.ReadLine());

                    if (totalIphones + iphone.Quantidade > quantidadeModelos)
                    {
                        iphone.Quantidade = quantidadeModelos - totalIphones;
                        Console.WriteLine("\nO número de unidades cadastrados foi ajustado, para não exceder a quantidade total de modelos desejada do cliente.");
                    }

                    iphone.IsDisponivel = true;
                    var listaIphone = new List<Iphone>();
                    listaIphone.Add(iphone); 
                    
                    Iphones = listaIphone;
                    totalIphones += iphone.Quantidade;

                    if (totalIphones >= quantidadeModelos)
                    {
                        break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Houve um erro ao atribuir os valores, verifique se possui algo nulo.");
                    goto fim;
                }

                Thread.Sleep(2000);
                Console.Clear();

            }
        }
        
        public Empresa CadastrarEmpresa()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Cadrastro da empresa.");
                Console.Write("\nDigite o nome da empresa:");
                string nomeLoja = Console.ReadLine().ToLower();

                Console.Write("\nDigite o CNPJ da empresa:");
                int cnpjLoja = int.Parse(Console.ReadLine());

                var empresa = new Empresa();
               
                Console.Write("\nDigite a quantidade de Iphones que deseja cadastrar:");
                int quantidadeModelos = int.Parse(Console.ReadLine());

                empresa.CadastrarIphones(quantidadeModelos);

                empresa.VisualizarInformacoesEmpresa();
               
                Console.Clear();
                return empresa;
            }
            catch (Exception)
            {
                Console.Clear ();
                Console.WriteLine("Ocorreu um erro, verifique se digitou tudo da empresa corretamente corretamente.");
                return new Empresa();
               
            }
          



        }
        public void VisualizarInformacoesEmpresa()

        {

            Console.Clear() ;
            Console.WriteLine("Dados da empresa:");
            Console.WriteLine($"\nNome da Loja: {Loja}");
            Console.WriteLine($"\nCNPJ: {CNPJ}");
            Console.WriteLine("\nIphones Disponíveis:");
            foreach (var iphone in Iphones)
            {
                if (iphone.IsDisponivel)
                {
                    Console.WriteLine($"\nModelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor}, Quantidade: {iphone.Quantidade}");
                }
            }

            Console.Clear();
           
           
        }
        
    }


}
