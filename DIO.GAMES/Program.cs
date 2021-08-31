using System;
using DIO.GAMES.Classes;

namespace DIO.GAMES
{
    class Program
    {
        static GameRepositorio repositorio = new GameRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ListarOpcoesUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        AdcionarGame();
                        break;
                    case "2":
                        ListarGames();
                        break;
                    case "3":
                        ExcluirGame();
                        break;
                    case "4":
                        AtualizarGame();
                        break;
                    case "5":
                        VisualizarGame();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ListarOpcoesUsuario();
            }

        }
        private static string ListarOpcoesUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo a DIO Games!");
            Console.WriteLine("Escolha o que deseja: ");
            Console.WriteLine("1- Adciona Game");
            Console.WriteLine("2- Listar Games");
            Console.WriteLine("3- Excluir Game");
            Console.WriteLine("4- Atualizar Game");
            Console.WriteLine("5- Visualizar Game");
            Console.WriteLine("6- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void AdcionarGame()
        {
            Console.WriteLine("Adcionar novo game: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do Game: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a descrição do game: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do game: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o modo do game (Online / offLine)");
            string entradaModo = Console.ReadLine();

            Game novoGame = new Game(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    descricao: entradaDescricao,
                                    anoLancamento: entradaAno,
                                    modo: entradaModo
                                    );
            repositorio.Insere(novoGame);
        }
        private static void ListarGames()
        {
            Console.WriteLine("Lista dos Games: ");
            Console.WriteLine();
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Lista de games vazía.");
                return;
            }
            foreach (var game in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", game.retornaId(), game.retornaTitulo());
            }
        }
        private static void ExcluirGame()
        {
            Console.Write(" Digite o ID do game: ");
            int indiceGame = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceGame);
        }
        private static void AtualizarGame()
        {
            Console.Write(" Digite o ID do game: ");
            int indiceGame = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(" {0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write(" Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write(" Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write(" Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write(" Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o modo do game (OnLine / OffLine): ");
            string entradaModo = Console.ReadLine();


            Game atualizaGame = new Game(id: indiceGame,
                                     genero: (Genero)entradaGenero,
                                     titulo: entradaTitulo,
                                     descricao: entradaDescricao,
                                     anoLancamento: entradaAno,
                                     modo: entradaModo
                                     );

            repositorio.Atualiza(indiceGame, atualizaGame);
        }
        private static void VisualizarGame()
        {
            Console.Write(" Digite o ID do game: ");
            int indiceGame = int.Parse(Console.ReadLine());

            var game = repositorio.RetornaPorId(indiceGame);

            Console.WriteLine(game);
        }
    }

}
