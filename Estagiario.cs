using System;

namespace projetoAOP02
{
    class Estagiario : Funcionario
    {
        private const float DESCONTO = 0.05f;

        public float descontoMenor(float valorDoProduto)
        {
            return valorDoProduto*DESCONTO;
        }
    }
}