﻿using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int FormaPagamentoId  { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }

        /* Validação. */

        public override void Validate()
        {
            LimparMensagensValidacao();
            if (!ItensPedido.Any())
            {
                AdicionarCritica("Critica - Pedido não pode ficar sem item de pedido.");
            }
            if (string.IsNullOrEmpty(CEP))
            {
                AdicionarCritica("Critica - CEP deve estar preeenchido.");
            }
            if (FormaPagamentoId.Equals(0))
            {
                AdicionarCritica("Crítica - Não foi informado a forma de pagamento");
            }

        }
    }
}
