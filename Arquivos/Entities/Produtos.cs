using System;
using System.Collections.Generic;
using System.Text;

namespace Arquivos.Entities
{
    class Produtos
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public Produtos(string nome, double valor, int qtd)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Quantidade = qtd;
        }

        public double Total()
        {
            return Valor * Quantidade;
        }
    }
}
