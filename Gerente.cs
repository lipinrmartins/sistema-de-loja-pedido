using System;

namespace projetoAOP02
{
    class Gerente : Funcionario
    {
        private const float DESCONTO = 0.2f;

        public string senha{get; set;}

        public float descontoMaior(float valorDoProduto)
        {
            return valorDoProduto - (valorDoProduto*DESCONTO);
        }
    }
}