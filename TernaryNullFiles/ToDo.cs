using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernaryNullFiles
{
    internal class ToDo
    {

        public static void Show()
        {
            //Börja med att skapa en lista där alla viktiga saker du ska göra ska finnas
            List<string> toDo = new List<string>
            {
            "1. Boka resa",
            "2. Köp större resväska",
            "3. Besök Nagelsallong",
            "4. Beställ sommarkläder"
            };


            


           






            //Hantera det som händer när användaren skriver in en siffra
            //Börja med att lägga in allt i en while-loop så att listan kan redigeras oändigt
            while (true)
            {

                Console.Clear(); // Rensa skärmen för att uppdatera listan




                //Rubrik på Listan
                Console.WriteLine("Min ToDo Lista");

                //Skriv ut listan använd inte foreach för du kommer att behöva indexen
                for (int i = 0; i < toDo.Count; i++)
                {
                    Console.WriteLine(toDo[i]);
                }






                //Ge användaren instruktioner kring vad hen behöver göra
                Console.WriteLine(); // Mellanslag mellan listan och frågan
                Console.WriteLine("----------------------------------------------------------"); //Design
                Console.WriteLine(); // Mellanslag för design

                Console.Write("När du är klar med en uppgift, skriv in siffran på raden: ");






                //Spara användarens inmatning
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if(input <= 4 && input >= 0)
                    {
                        //eftersom att lista börjar på 0 och användaren ska skriva in ett tal från 1-4 gör en hjäp variabel och skriv -1 på den så att den blir lika mycket som listans index
                        int index = input - 1;
                        //index variabeln som nu matchar listans index som användaren vill nå kan ändras
                        toDo[index] = toDo[index].Replace(".", ". KLAR | ");
                    }

                    else
                    {
                        Console.WriteLine("Skriv in ett heltal mellan 1-4. Inte mer eller mindre.");
                        Console.ReadKey(); //Så att programmet pausar lite och användaren kan se meddelandet
                        continue;
                    }
                }




                else
                {
                    Console.WriteLine("Fel inmatning skriv in en siffra inget tecken eller sträng.");
                    Console.ReadKey(); //Så att programmet pausar lite och användaren kan se meddelandet ovan
                }
            }
 
        }
    }
}
