using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades 
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }


        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um Item de pedido ou muitos Items de pedidos
        /// </summary>
        public ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedido.Any())
                AdicionarCritica("CRITICA - Pedido não pode ficar sem item de pedido ");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("CRITICA - CEP deve estar preenchido");

            if (FormaPagamentoId == 0)
                AdicionarCritica("CRITICA - Não foi informado a forma de pagamento");
        }
    }
}
