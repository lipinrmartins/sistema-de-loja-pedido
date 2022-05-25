using System;
using System.Collections.Generic;

namespace projetoAOP02
{ 
    class Loja
    {
        public List<Pedido> listaPedidos;
        private int qtdPedido;
        private Gerente gerenteDaLoja;
        private Estagiario estagiarioDaLoja;

        public void iniciar()
        {
            this.qtdPedido = 0;
            this.gerenteDaLoja = new Gerente(); /* Instanciando o Objeto Gerente */
            this.gerenteDaLoja.senha = "1234"; /* Com a criação do Gerente, determinei sua senha */
            this.estagiarioDaLoja = new Estagiario();   
            listaPedidos = new List<Pedido>();
            Console.WriteLine("Iniciando Loja");
            Console.WriteLine();
            int opcao = -1;

            while (opcao != 0)
            {
                menu();
                try
                {
                    opcao = Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Erro! Digite um número válido.");
                }

                switch (opcao)
                {
                    case 1:
                    {
                        inserirPedido();
                    } break;
                    case 2:
                    {
                        buscarPedido();
                    } break;
                    case 3:
                    {
                        removerPedido();
                    } break;
                    case 4:
                    { 
                        calcularTotal(); 
                    } break;
                        
                }
            }
        }

        public void menu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Inserir Pedido");
            Console.WriteLine("2 - Buscar Pedido");
            Console.WriteLine("3 - Remover Pedido");
            Console.WriteLine("4 - Valor Total do Pedido");
            Console.WriteLine("0 - Para sair");
            Console.WriteLine("Escolha uma Opção:");
            Console.WriteLine();
        }

        public void inserirPedido()
        {
            Console.WriteLine("-- Inserir Pedido --");
            Pedido pedido = new Pedido();
            this.qtdPedido++;
            pedido.pedidoId = qtdPedido;
            pedido.dataEmissao = new DateTime();
            
            Console.WriteLine("Informe o valor do produto");
            pedido.valorDoProduto = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Informe a descriçao do produto");
            pedido.descricaoDoProduto = Console.ReadLine();

            listaPedidos.Add(pedido);
            Console.WriteLine("Pedido {0} inserido.", pedido.pedidoId);

        }

        public void buscarPedido()
        {
            Console.WriteLine("-- Buscar Pedido --");
            Console.WriteLine("Informe o codigo do pedido");
            Estagiario estagiario = new Estagiario();
            int idPedido = Int32.Parse(Console.ReadLine());
            bool achou = false;

            foreach (Pedido mPedido in listaPedidos)
            {
                if(mPedido.pedidoId == idPedido)
                {
                    achou = true;
                    Console.WriteLine("Pedido {0} encontrado.", listaPedidos[idPedido - 1].pedidoId);
                    Console.WriteLine("Produto: {0}", listaPedidos[idPedido - 1].descricaoDoProduto);
                    Console.WriteLine("Valor do Pedido: R$ {0}", listaPedidos[idPedido - 1].valorDoProduto);
                    break;
                }
            }

            if(!achou) {
                Console.WriteLine("Pedido {0} nao encontrado.");
            }
        }

        public void removerPedido()
        {
            Console.WriteLine("-- Remover Pedido --");
            Console.WriteLine("Informe o codigo do pedido que deseja remover");
            int idPedido = Int32.Parse(Console.ReadLine());
            bool achou = false;

            foreach (Pedido mPedido in listaPedidos)
            {
                if (mPedido.pedidoId == idPedido)
                {
                    achou = true;
                    listaPedidos.Remove(mPedido);
                    Console.WriteLine("Pedido {0} removido.", mPedido.descricaoDoProduto);
                    break;
                }
            }

            if (!achou)
            {
                Console.WriteLine("Pedido {0} nao encontrado.");
            }
        }
        public void calcularTotal()
        {
            Console.WriteLine("-- Valor Total do seu Pedido --");
            float total = 0;
            foreach (Pedido somaPedido in listaPedidos)
            {
                total = total + somaPedido.calcularPrecoTotal();
            }
            Console.WriteLine("O valor total dos pedidos: R$ {0}", total);
            Console.WriteLine("Deseja aplicar desconto? S (Sim) ou N (Não)");
            string opcao = "";

            while (opcao.ToUpper() != "S" && opcao.ToUpper() != "N")
            {
                opcao = Console.ReadLine();
            }
            if (opcao.ToUpper() == "N")
            {
                Console.WriteLine("Nenhum desconto será aplicado.");
                return;
            }
            Console.WriteLine("Aplicar desconto como: G (Gerente) ou E (Estagiário)");
            while (opcao.ToUpper() != "E" && opcao.ToUpper() != "G")
            {
                opcao = Console.ReadLine();
            }
            if (opcao.ToUpper() == "E")
            {
                total = estagiarioDaLoja.descontoMenor(total);
                Console.WriteLine("O valor total com desconto de estagiário: R$ {0}", total);
                return;
            }
            Console.WriteLine("Informe sua senha: C (Cancelar)");
            string password = "";
            while (password != gerenteDaLoja.senha && password.ToUpper() != "C")
            {
                password = Console.ReadLine();
            }
            if (password.ToUpper() == "C")
            {
                Console.WriteLine("Desconto não aplicado.");
                return;
            }
            total = gerenteDaLoja.descontoMaior(total);
            Console.WriteLine("O valor total com desconto do Gerente: R$ {0}", total);
        }
    }
}
