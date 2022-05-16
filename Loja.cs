using System;
using System.Collections.Generic;

namespace projetoAOP02
{ 
    class Loja
    {
        public List<Pedido> listaPedidos;
        private int qtdPedido;

        public void inciar()
        {
            this.qtdPedido = 0;
            listaPedidos = new List<Pedido>();
            Console.WriteLine("Iniciando Loja");
            Console.WriteLine();
            int opcao = -1;

            while (opcao != 0)
            {
                menu();
                opcao = Int32.Parse(Console.ReadLine());
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
                }
            }
        }

        public void menu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Inserir Pedido");
            Console.WriteLine("2 - Buscar Pedido");
            Console.WriteLine("3 - Remover Pedido");
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
            int idPedido = Int32.Parse(Console.ReadLine());
            bool achou = false;

            foreach (Pedido mPedido in listaPedidos)
            {
                if(mPedido.pedidoId == idPedido)
                {
                    achou = true;
                    Console.WriteLine("Pedido {0} encontrado.", listaPedidos[idPedido - 1].descricaoDoProduto);
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
    
    }
}
