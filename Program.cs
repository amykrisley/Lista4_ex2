using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista4_ex002
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int b, c, d;
            bool hasAWinner = false;

            Console.Write("Escolha quantas pessoas irao participar: \n");
            b = int.Parse(Console.ReadLine());
            Console.Write("Quantas chances cada jogador tem: \n");
            c = int.Parse(Console.ReadLine());
            string[] a;
            a = new string[b];
            int[] y;
            y = new int[b];
            int[] chances;
            chances = new int[b];
            Random r = new Random();
            int playerQtd = b;
            int rodada = 0;

            //Da uma quantidade igual de chances para cada jogador
            for (int i = 0; i < b; i++)
            {
                chances[i] = c;
            }

            for (int i = 0; i < b; i++)
            {
                int tempN = i + 1;

                Console.Write("Digite o nome da " + tempN.ToString() + "º Pessoa: \n\n");
                a[i] = Console.ReadLine();

            }
            Console.WriteLine("\n\nVamos começar!\n\n");

            while (!hasAWinner)
            {
                d = r.Next(6);
                rodada++;

                Console.WriteLine("\n\n\n==========RODADA {0}!==========\n\n", rodada);
                //Os jogadores escolhem um numero
                for (int i = 0; i < b; i++)
                {
                    if (a[i] != " X ")
                    {
                        Console.WriteLine("\n\nE a vez do {0}", a[i]);
                        Console.Write("Qual numero deseja jogar?");
                        y[i] = int.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("\n\nO numero aleatorio era {0}", d);
                //Verifica se o numero escolhido e igual ao numero aleatorio
                for (int i = 0; i < b; i++)
                {
                    if (y[i] == d)
                    {
                        if (chances[i] > 0)
                        {
                            chances[i]--;
                            Console.WriteLine("\n\nO jogador {0} perdeu uma chance.\n{1} chances restantes", a[i], chances[i]);
                        }
                        else
                        {
                            Console.WriteLine("\n\nO seguinte jogador foi eliminado: {0}. Mais sorte da proxima vez...", a[i]);
                            a[i] = " X ";
                            playerQtd--;
                        }
                    }
                }

                //Verifica se ja ha um vencedor
                if (playerQtd == 1)
                {
                    for (int i = 0; i < b; i++)
                    {
                        if (a[i] != " X ")
                        {
                            Console.WriteLine("\n\nO jogador {0} e o vencedor!!", a[i]);
                            hasAWinner = true;
                        }
                    }
                }
                else if (playerQtd <= 0)
                {
                    Console.WriteLine("\n\nTodos perderam...");
                    hasAWinner = true;
                }
            }
        }
    }
}
