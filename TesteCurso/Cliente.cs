using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using metodos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TesteCurso
{

    public class Cliente
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public decimal Saldo { get; set; }
        public List<Iphone> IphonesComprados { get; set; }
        public Empresa Empresas { get; set; }
        public Carrinho Carrinho { get; set; }

        public Cliente(string nome, int cpf, decimal saldo)
        {
            Nome = nome;
            CPF = cpf;
            Saldo = saldo;
            IphonesComprados = new List<Iphone>();
        }

        public void CadastrarCliente()
        {
           amg:
            try
            {
                Console.Clear();
                Console.WriteLine("Cadrastro do cliente." );
               
                Console.Write("\nDigite o nome do cliente:");
                string nomeCli = Console.ReadLine().ToLower().Trim();
                Console.Write("\nDigite o CPF do cliente:");
                int cpfCli = int.Parse(Console.ReadLine().Trim());
                Console.Write("\nDigite o saldo do cliente:");
                decimal saldoCli = decimal.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Após clicar na tecla 'Enter' retornaremos a ao Menu Cliente, para você decidir o próximo passo.");

                var cliente = new Cliente(nomeCli, cpfCli, saldoCli);
             
                cliente.VisualizarIphones();

                cliente.VisualizarInformacoesCliente();
            }
            catch (Exception)
            {
                Console.WriteLine("Verifique se digitou os dados do cliente corretamente");
                goto amg;
            }

            Console.Clear();
            
        }

     

        public void VisualizarIphones()
        {

            Console.Clear();
            if (Empresas == null)
            {
                Console.WriteLine("\nNenhuma empresa selecionada.");
                return;
            }
            Console.Clear();
            Console.WriteLine($"\nIphones disponíveis na loja  {Empresas.Loja}:");
            foreach (var iphone in Empresas.Iphones)
            {
                if (iphone.IsDisponivel)
                {
                    Console.WriteLine($"\nModelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor}, Quantidade: {iphone.Quantidade}");
                }
            }

            Console.WriteLine("\nDigite o modelo do Iphone que deseja adicionar no carrinho :");
            string modeloCompra = Console.ReadLine().ToLower().Trim();
            AdicionarCarrinho(modeloCompra);

            Console.Clear();
          
        }
        public void VisualizarInformacoesCliente()
        {
            Console.WriteLine("Informações cadrastradas do cliente:");
            Console.WriteLine($"\nNome: {Nome}");
            Console.WriteLine($"\nCPF: {CPF}");
            Console.WriteLine($"\nSaldo: {Saldo}");
            Console.WriteLine("\niphones Comprados:");
            foreach (var iphone in IphonesComprados)
            {
                Console.WriteLine($"\nModelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor}");
            }
        }

        public void EfetuarCompra()
        {
            Console.Clear();
            Console.WriteLine("\nPagamento:");
            var carrinho = new Carrinho();
            Console.WriteLine("Deseja finalizar a compra?");

            decimal somaTotal = 0;
        
            if (Saldo <= somaTotal  && carrinho.Iphones != null) 
            {
                Console.WriteLine("Parabéns! Sua compra foi efetuada.");
                VisualizarInformacoesCliente();
                Console.WriteLine($"\nValor total pago: {somaTotal.ToString("C")}");
            }
            else
            {
                Console.WriteLine("Infelizmente seu saldo é insuficiente para efetuar a compra.");
            }

            foreach (var iphone in Carrinho.Iphones)
            {
                Console.WriteLine($"Modelo: {iphone.Modelo}, Cor {iphone.Cor}, Valor: {iphone.Valor.ToString("C")}");
                somaTotal += iphone.Valor;
                Saldo -= somaTotal;
            }

        }

        public void Excluir(Iphone iphone)
        {
            Console.Clear();
            Console.WriteLine("Excluindo Iphone do carrinho:");
            if (!Carrinho.Iphones.Any(i => i.Modelo == iphone.Modelo))
            {
                Carrinho.Iphones.Remove(iphone);

                Console.WriteLine("O Iphone foi deletado com sucesso.");
            }

            else
            {
                Console.WriteLine("Erro a excluir o Iphone.");
            }
            Console.Clear() ;
        }


        public void AdicionarCarrinho(string modelo)
        {
            
            Console.Clear();
            Console.WriteLine("Adicionando Iphone do carrinho: ");
            Iphone iphoneDesejado = Empresas.Iphones.Find(iphone => iphone.Modelo == modelo && iphone.IsDisponivel && iphone !=null);

            var carrinho = new Carrinho();
            var menus = new Menu();

            if (iphoneDesejado != null)
            {
                carrinho.ArmazenaPedidos(iphoneDesejado);
                Carrinho = carrinho;
                var iphone = new Iphone();
                Console.Clear();
                Console.WriteLine($"\nSeu Iphone {modelo} foi adicionado no carrinho.");

                Console.WriteLine($"\nNeste momento você tem a opção de adicionar, remover algum item do seu carrinho ou apenas visualiza-ló. ");
                Console.WriteLine("Digite [1] para adicionar outro Iphone no seu carrinho.");
                Console.WriteLine("Digite [2] para remover um produto já adicionado no carrinho.");
                Console.WriteLine("Digite [3] para  visualizar seu carrinho.");

                Console.WriteLine("Digite [4] para Finalizar a compra.");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Seu produto será adicionado:");
                        VisualizarIphones();
                        carrinho.ArmazenaPedidos(iphone);
                        break;

                    case 2:
                       
                        Console.WriteLine("Vamos remover o produto que já foi adicionado no seu carrinho");
                        Console.WriteLine("Escolha o Iphone que deseja excluir: ");
                        var escolhaExcluir = Console.ReadLine().Trim();
                      
                        foreach (var item in Carrinho.Iphones)
                        {
                            if(item.Modelo == escolhaExcluir)
                            {
                                iphone = item; break;
                            }
                            else
                            {
                                Console.WriteLine("\nIphone não disponível, modelo não encontrado.");
                                Console.Clear();

                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("finalizando sua compra:");
                        EfetuarCompra();
                        break;

                    default:
                        Console.WriteLine("Reveja se digitou os números disponivel do Menu corretamente.");
                        break;
                }

            }
            Console.Clear();
        }
    }
}