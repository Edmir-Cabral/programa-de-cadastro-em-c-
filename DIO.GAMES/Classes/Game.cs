
using System;

namespace DIO.GAMES
{
    public class Game : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int AnoLancamento { get; set; }
        private string Modo { get; set; }
        private bool Excluido { get; set; }

        public Game(int id, Genero genero, string titulo, string descricao, int anoLancamento, string modo)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoLancamento = anoLancamento;
            this.Modo = modo;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero = " + this.Genero + Environment.NewLine;
            retorno += "Título = " + this.Titulo + Environment.NewLine;
            retorno += "Descrição = " + this.Titulo + Environment.NewLine;
            retorno += "Ano de lançamento = " + this.Titulo + Environment.NewLine;
            retorno += "Modo = " + this.Modo + Environment.NewLine;
            retorno += "Excluído = " + this.Excluido;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}