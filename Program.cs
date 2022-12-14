﻿namespace JogoDaVelha;
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

    char[,] matriz = OcuparMemoria();



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
    Console.WriteLine("1° - Informe quantas vezes vai querer jogar");
    Console.WriteLine("2° - Informe a linha que queira jogar");
    Console.WriteLine("2° - Informe a coluna que queira jogar");
    Console.WriteLine("3° - Jogue X ou O (letra o) na posição escolhida");
    Console.Write("4° - Caso queira ver o modelo do jogo digite (s) se não digite (n): ");
    char modelo = char.Parse(Console.ReadLine());

    if (modelo == 's') ModeloDoJogo();

  }



}
