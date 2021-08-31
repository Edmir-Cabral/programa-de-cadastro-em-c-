using System.Collections.Generic;
using DIO.GAMES.Interfaces;

namespace DIO.GAMES.Classes
{
    public class GameRepositorio : IRepositorio<Game>
    {
        private List<Game> listaGames = new List<Game>();
        public void Atualiza(int id, Game entidade)
        {
            listaGames[id] = entidade;
        }
        public void Exclui(int id)
        {
            listaGames[id].excluir();
        }

        public void Insere(Game entidade)
        {
            listaGames.Add(entidade);
        }

        public List<Game> Lista()
        {
            return listaGames;
        }

        public int ProximoId()
        {
            return listaGames.Count;
        }

        Game IRepositorio<Game>.RetornaPorId(int id)
        {
            return listaGames[id];
        }
    }
}