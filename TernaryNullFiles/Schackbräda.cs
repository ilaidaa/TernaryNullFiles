using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernaryNullFiles
{
    internal class Schackbräda
    {


        public static void Show()
        {
            //Skapa en matris för schackbrädan
            long[,] chess = new long[8, 8];

            //Skapa en räknarvariabel som ska räkna antal riskorn
            //det är double för när man fortsätter gångra med 2 längre ner så blir siffrorna för stora. int har inte lika många siffror som long
            long riceCorn = 1; //Börja från 1 hade kraven vari börja från 0 hade du skrivit 0

            for(int i = 0; i < chess.GetLength(0); i++)
            {
                for(int j = 0; j < chess.GetLength(1); j++)
                {
                    chess[i, j] = riceCorn; //Denna står här för när loopen körs och 2 har plussat från förra loppen ska det skrivas ut då måste värdet ha ökat sen innan.
                                            //Skrivs detta efter cConsole.Write har inte matrisen uppdaterats 

                    Console.Write(chess[i, j] + "\t");
                    riceCorn *= 2;
                }
                Console.WriteLine();
            }
        }
    }
}
