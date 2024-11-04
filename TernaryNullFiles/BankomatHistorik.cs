using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;

namespace TernaryNullFiles
{

    internal class BankomatHistorik
    {
        //Skapa en global variabel för att räkna insättning och uttag
        public static int counter = 0;

        //Skapa en global array för att spara transaktionerna i en array
        public static string[] historyIndex = new string[10];

        //historyCounter används för att hålla reda på hur många transaktioner som har gjorts totalt (oavsett om de är nya eller gamla).
        //Den ökas varje gång en ny transaktion läggs till.
        public static int historyCounter = 0;




        //Meny för att visa alternativen man kan välja i vyn dessa ska fyllas å med submetoder längre ner.
        public static void ShowMeny()
        {

            //Låt programmet köra hela tiden
            while (true)
            {
                Console.Clear();


                //Sjlva menyn
                Console.WriteLine("Hej Välkmmen till Bankomaten. Välj en funktion nedan genom att skriva in respektive siffra.");
                Console.WriteLine();
                Console.WriteLine("1. Insättning");
                Console.WriteLine("2. Uttag");
                Console.WriteLine("3. Saldo");
                Console.WriteLine("4. Historik");
                Console.WriteLine("5. Avsluta");


                //Ta emot användarens val
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    //Hantera användarens input mellan 1-5
                    switch (choice)
                    {
                        case 1:
                            Deposit();
                            break;
                        case 2:
                            Withdrawl();
                            break;
                        case 3:
                            Balance();
                            break;
                        case 4:
                            History();
                            break;
                        case 5:
                            Console.WriteLine("Avslutar programmet ... ");
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Ogiltig inmatning. Skriv in ett heltal mellan 1-5. Inte mer eller mindre.");
                            Console.ReadKey();
                            break;

                    }

                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Skriv in ett heltal inte string eller char");
                    Console.ReadKey();
                    continue;
                }
            }

        }








        //Metod 1 för att hantera inmatning 
        public static void Deposit()
        {
            Console.Write("Var god knappa in summan du vill sätta in. Det kan inte vara mer än 10.000kr :  ");

            if(int.TryParse(Console.ReadLine(), out int input))
            {
                if(input <= 10000 && input > 0)
                {
                    counter += input;
                    Console.WriteLine("Godkänd insättning. Nuvarande saldo är: " + counter + ":-");

                    //Lägg till transaktionerna i historik
                    historyIndex[historyCounter % 10] = "Insättning : " + input + ":-"; //Lägg till transaktionen i historiken med modulus för cirkulär rotation
                    historyCounter++;
                   
                }
                else
                {
                    Console.WriteLine("Nekad insättning. Summan får inte vara mindre än 0:- eller överstiga 10.000:- ");
                }
            }
            else
            {
                Console.WriteLine("Nekad insättning. Skriv in ett heltal, inte en string eller char.");
            }

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Tryck på valfri tangent för att återvända till huvudmenyn . . .");
            Console.ReadKey();
        }








        //Metod för att hantera uttag
        public static void Withdrawl()
        {
            Console.Write("Skriv in summan du vill ta ut: ");

            if(int.TryParse(Console.ReadLine(), out int withDrawl))
            {
                if(withDrawl <= counter && withDrawl > 0)
                {
                    counter -= withDrawl;
                    Console.WriteLine("Godkänd uttag. Ditt nuvarandre saldo är: " + counter + ":-");

                    //Lägg till transaktion i historik
                    historyIndex[historyCounter % 10] = "Uttag : " + withDrawl + ":-";  // Lägg till transaktionen i historiken med modulus för cirkulär rotation
                    historyCounter++;

                }
                else
                {
                    Console.WriteLine("Nekad uttag. Du kan inte dra ut mer än ditt nuvarande saldo");
                }
            }
            else
            {
                Console.WriteLine("Nekad uttag. Skriv in ett heltal, inte en string eller char.");
            }


            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Tryck på valfri tangent för att återvända till huvudmenyn . . .");
            Console.ReadKey();
        }

   
    




        //Metod för att visa saldo
        public static void Balance()
        {
            Console.WriteLine("Ditt nuvarande saldo är " + counter + ":-");


            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Tryck på valfri tangent för att återvända till huvudmenyn . . .");
            Console.ReadKey();
        }






        //Metod för att visa historik på senaste 10 transaktioner 
        public static void History()
        {
            //Rubrik
            Console.WriteLine("Historik över de 10 senaste transaktionerna: ");
            Console.WriteLine("---------------------------------------------");

            for (int i = 0; i < 10; i++) //Detta är en for-loop som körs 10 gånger, en gång för varje transaktion i historyIndex.
            {
                int index = (historyCounter + i) % 10; // Hanterar Cirkulär rotation
                                                       // historyCounter är ett tal som visar hur många transaktioner vi har gjort totalt.
                                                       // i är räknaren som går från 0 till 9, ett steg i taget.
                                                       // % 10(modulusoperatorn) gör att vi alltid hamnar på en plats mellan 0 och 9, även om historyCounter är ett stort tal.


                if (historyIndex[index] != null)  //Här kollar vi om platsen index faktiskt innehåller något.
                                                  //Om platsen är tom(null), hoppar vi över den så att inget skrivs ut.
                                                  
                {
                    Console.WriteLine(historyIndex[index]); // Om det finns en transaktion på plats index, skriver vi ut den.
                                                            // Detta görs för varje transaktion vi har i de senaste 10 platserna, så vi ser dem i rätt ordning.
                }
            }


            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Tryck enter för att återvända till huvudmenyn");
            Console.ReadKey();
        }

    }
}
