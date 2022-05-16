using System;

namespace projetoAOP02
{
    class Pedido
    {
        public int pedidoId {get; set; }

        public DateTime dataEmissao {get; set;}

        public float valorDoProduto {get; set;}

        public string descricaoDoProduto {get; set;}

        public float calcularPrecoTotal()
        {
            return valorDoProduto;
        }      
    }
}
