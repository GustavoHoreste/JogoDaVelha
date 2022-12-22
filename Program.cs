namespace JogoDaVelha;
class Program
{
  static void Main(string[] args)
  {
    Console.Clear();

    Console.WriteLine("+---------------------------+");
    Console.WriteLine("+       JOGO DA VELHA       +");
    Console.WriteLine("+---------------------------+");
    Console.WriteLine();
    Menu();

    Console.Write("Vai jogar quantas partidas: ");
    int quantidade = int.Parse(Console.ReadLine());

    int jogadorO = 0, jogadorX = 0, velha = 0;

    for (int i = 0; i < quantidade; i++)
    {
      Console.WriteLine("");
      Console.WriteLine($"[{i}] - partida");

      int resultado = VerificaJogo(Inserir(OcuparMemoria()));

      switch (resultado)
      {
        case 0: Console.WriteLine("--Jogador O ganhou--"); jogadorO++; break;
        case 1: Console.WriteLine("--Jogador X ganhou--"); jogadorX++; break;
        default: Console.WriteLine("--Velha--"); velha++; break;
      }

      Console.WriteLine("Iniciando proxima partida");
      Thread.Sleep(2000);
      Console.Clear();
    }

    Console.WriteLine($"--Jogador X ganhou: {jogadorX}--");
    Console.WriteLine($"--Jogador O ganhou: {jogadorO}--");
    Console.WriteLine($"--Deu velha: {velha}--");


    Console.WriteLine("\nBYEBYE");

  }

  static int VerificaJogo(char[,] matriz)
  {
    int v = 2;
    if (matriz[0, 0] == 'X' && matriz[0, 1] == 'X' && matriz[0, 2] == 'X') return v = 1;           //linha 1 jogador 1
    else if (matriz[0, 0] == 'O' && matriz[0, 1] == 'O' && matriz[0, 2] == 'O') return v = 0;          //linha 1 jogador 0

    else if (matriz[1, 0] == 'X' && matriz[1, 1] == 'X' && matriz[1, 2] == 'X') return v = 1;         //linha 2 jogador 1						
    else if (matriz[1, 0] == 'O' && matriz[1, 1] == 'O' && matriz[1, 2] == 'O') return v = 0;         //linha 2 jogador 0

    else if (matriz[2, 0] == 'X' && matriz[2, 1] == 'X' && matriz[2, 2] == 'X') return v = 1;         //linha 3 jogador 1
    else if (matriz[2, 0] == 'O' && matriz[2, 1] == 'O' && matriz[2, 2] == 'O') return v = 0;         //linha 3 jogador 0

    else if (matriz[0, 0] == 'X' && matriz[1, 0] == 'X' && matriz[2, 0] == 'X') return v = 1;         //coluna 1 jogador 1
    else if (matriz[0, 0] == 'O' && matriz[1, 0] == 'O' && matriz[2, 0] == 'O') return v = 0;         //coluna 1 jogador 0

    else if (matriz[0, 1] == 'X' && matriz[1, 1] == 'X' && matriz[2, 1] == 'X') return v = 1;         //coluna 2 jogador 1
    else if (matriz[0, 1] == 'O' && matriz[1, 1] == 'O' && matriz[2, 1] == 'O') return v = 0;         //coluna 2 jogador 0

    else if (matriz[0, 2] == 'X' && matriz[1, 2] == 'X' && matriz[2, 2] == 'X') return v = 1;         //coluna 3 jogador 1
    else if (matriz[0, 2] == 'O' && matriz[1, 2] == 'O' && matriz[2, 2] == 'O') return v = 0;         //coluna 3 jogador 0

    else if (matriz[0, 0] == 'X' && matriz[1, 1] == 'X' && matriz[2, 2] == 'X') return v = 1;         //seta esquerda superior para direita inferior jogador 1
    else if (matriz[0, 0] == 'O' && matriz[1, 1] == 'O' && matriz[2, 2] == 'O') return v = 0;         //seta esquerda superior para direita inferior jogador 0

    else if (matriz[0, 2] == 'X' && matriz[1, 1] == 'X' && matriz[2, 0] == 'X') return v = 1;         //seta direita inferior para esquerda superior jogador 1
    else if (matriz[0, 2] == 'X' && matriz[1, 1] == 'O' && matriz[2, 0] == 'O') return v = 0;         //seta direita inferior para esquerda superior jogador 0

    return v;
  }

  static char[,] Inserir(char[,] matriz)
  {

    for (int i = 0; i < 9; i++)
    {
      Console.Write("Informe a linha:");
      int linha = int.Parse(Console.ReadLine());


      Console.Write("Informe a coluna:");
      int coluna = int.Parse(Console.ReadLine());

      if (matriz[linha, coluna] != '.')
      {
        Console.WriteLine("\n\t[Posição ja ocupada <tente novamente>]\n");
        i--;
      }
      else
      {
        Console.Write("Insira X ou O:");
        matriz[linha, coluna] = char.Parse(Console.ReadLine().ToUpper());

        if (matriz[linha, coluna] == 'X' || matriz[linha, coluna] == 'O')
        {
          Console.Clear();

          ModeloDoJogo();

          Console.WriteLine($"Impressão da Jogada-> {i}");

          Console.WriteLine();
          ImpressaoTimeReal(ref matriz);
          Console.WriteLine();


        }
        else
        {
          Console.WriteLine("\n\t[So aceitamos X e O <tente novamente>]\n");
          i--;
          matriz[linha, coluna] = '.';
        }
      }
    }

    return matriz;
  }

  static void ImpressaoTimeReal(ref char[,] matriz)
  {

    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        Console.Write($"\t {matriz[i, j]}");

        if (i == 0 && j == 2 || i == 1 && j == 2 || i == 2 && j == 2)
        {
          Console.Write("\n");
        }

      }
    }

    Thread.Sleep(2000);

  }

  static char[,] OcuparMemoria()
  {
    int i, j;
    char[,] matriz = new char[3, 3];

    for (i = 0; i < 3; i++)
    {
      for (j = 0; j < 3; j++)
      {
        matriz[i, j] = '.';
      }
    }

    return matriz;

  }

  static void ModeloDoJogo()
  {
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("Modelo de posições:");
    Console.WriteLine("COLUNA  [0] [1] [2] ");
    Console.WriteLine("LINHA");
    Console.WriteLine("[0]\t . | . | . ");
    Console.WriteLine("\t-----------");
    Console.WriteLine("[1]\t . | . | . ");
    Console.WriteLine("\t-----------");
    Console.WriteLine("[2]\t . | . | . ");
    Console.WriteLine("---------------------------------------");

    Thread.Sleep(2500);

  }

  static void Menu()
  {
    Console.WriteLine("Instruções:");
    Console.WriteLine("1° - Informe quantas vezes vai jogar");
    Console.WriteLine("2° - Informe a linha que queira jogar");
    Console.WriteLine("2° - Informe a coluna que queira jogar");
    Console.WriteLine("3° - Jogue X ou O (letra o) na posição escolhida");
    Console.Write("4° - Caso queira ver o modelo do jogo digite (s) se não digite (n): ");
    char modelo = char.Parse(Console.ReadLine().ToLower());

    if (modelo == 's') ModeloDoJogo();

  }
}
