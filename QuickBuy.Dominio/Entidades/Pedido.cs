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
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um Item de pedido ou muitos Itens de pedidos
        /// </summary>
        public ICollection<ItemPedido> ItensPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();


            if (ItensPedidos.Any())
                AdicionarCritica("Critica - Pedido não pode ficar sem item de pedido");
                //MensagemValidacao.Add("Critica - Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("CEP deve estar preenchido");
            if (string.IsNullOrEmpty(Estado))
                AdicionarCritica("Estado deve ser prenchido");
            if (string.IsNullOrEmpty(Cidade))
                AdicionarCritica("Nome da cidade deve ser prenchido");
            if (string.IsNullOrEmpty(EnderecoCompleto))
                AdicionarCritica("O endereço completo deve ser informado");
            if (NumeroEndereco == 0)
                AdicionarCritica("O número do endereço deve ser informado");
            if (FormaPagamentoId == 0)
                AdicionarCritica("Não foi informado a forma de pagamento");
        }
    }
}
