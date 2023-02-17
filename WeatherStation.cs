using System;
using StadClass;

namespace WeatherStation
{
    class Program
    {
        //gör en method med Linsok som söker bland stad listan
        static int Linsok(List<Stad> list, int Nyckel)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].temp == Nyckel)
                {
                    return i;
                }
            }
            return -1;
        }

        //gör bubblesort för att sorta listan av städer
        static void Bubblesort (List<Stad> städer)
        {

            //skapa en bubble sort algoritm med hjälp av for loopar och if statement
            int max = städer.Count - 1;
            
            for (int i = 0; i < max; i++)
            {
                int number = max - i;

                for (int j = 0; j < number; j++)
                {
                    if (städer[j].temp > städer[j + 1].temp)
                    {
                        Stad tmp = städer[j];
                        städer[j] = städer[j + 1];
                        städer[j + 1] = tmp;
                    }     
                }

            }
            //utskrivt av städer och dess temperatur
            for (int i = 0; i < städer.Count; i++)
                Console.WriteLine("Stad: " + städer[i] + "ºC");
        }

        static void Main(string[] args)
        {
            //starta programmet med et välkomstmeddelande samt beskriva vad programmet gör
            Console.WriteLine("--------------------");
            Console.WriteLine("Hej och Välkommen!");
            Console.WriteLine("--------------------");
            Console.WriteLine("Det här är ett program som kommer att simulera en väderstation där du kan infoga städer\nsamt ange tempraturer till städerna. Du kommer även kunna att sortera och söka efter\nspecifika tempraturer mellan länderna.");
            Console.WriteLine("--------------------");

            //skapa en list för Stad där alla städer med tempraturer kommer att hamna
            List <Stad> stadList = new List <Stad>();

            //boolean loop för att kontrolera while loop
            bool runLoop = true;

            //gör en while loop för att repetera kontrollcenter
            while (runLoop)
            {
                Console.WriteLine("");
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("--------------------");

                Console.WriteLine("[1] Skapa en ny stad med tempratur");
                Console.WriteLine("[2] Sök efter tempratur mellan städer");
                Console.WriteLine("[3] Sortera städerna");
                Console.WriteLine("[4] Avsluta Program");
                
                //beroende på vad använderan vill göra så kommer integer action att bestämma vilket case switch satsen ska utföra
                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    //case 1 ska ta emot stad samt tempratur
                    case 1:

                        System.Console.Write("Vad för stad vill du lägga till? ");
                        string namn = Console.ReadLine();
                        System.Console.Write("Ange " + namn + "s tempratur (Celsius): ");
                        int temp = int.Parse(Console.ReadLine());

                        //skapa en stad med hjälp av de två värderna (namn, temp)
                        Stad stad = new Stad(namn, temp);

                        //sätt en spärr för lämplig temp så värdet inte kan överstiga eller gå under specifika värden.
                        if (temp <= -60 || temp >= 60)
                            Console.WriteLine("Ange en tempratur mellan -60ºC till +60ºC");
                        else
                            //om temperaturen är lämplig så ska konsolen visa vad man lagt till samt lägga till staden till stadList
                            Console.WriteLine("Du har lagt till " + namn + " med tempraturen: " + temp + "ºC");
                            stadList.Add(stad);
                        break;

                        //case 2 så ska användaren kunna söka efter en temperatur bland städer
                    case 2:

                        //convert user input så att de kan bestämma värdet för nyckeln in Linsok methoden
                        Console.WriteLine("Vad för temperatur vill du söka efter bland städer (Celsius)? ");
                        string search = Console.ReadLine();
                        int Nyckel = Convert.ToInt32(search);
                        
                        //kalla på Linsok methoden
                        int index = Linsok(stadList, Nyckel);

                        //om methoden fick ut index == -1 så ska felmeddelande komma upp
                        if (index == -1)
                            Console.WriteLine("Det finns ingen stad som har den här temperaturen!");

                        //om methoden hittar en stad inom listan med den temperaturen så ska den visa vilken stad det är
                        else
                            Console.WriteLine(stadList[index].Namn + " har temperaturen " + Nyckel + "ºC");


                        break;

                        //case 3 ska bubblesorta / sortera städerna gradvis
                    case 3:

                        //kalla bubblesort methoden
                        Bubblesort(stadList);

                        break;

                        //case 4 ska avsluta simulationen och samt komma med ett hejdå meddelande
                    case 4:

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Tack för att du använde min väderstations simulator!");
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Tryck på vilken knapp som helst för att komma vidare...");
                        Console.ReadLine();
                        Console.WriteLine("Hejdå!");
                        Console.WriteLine("Av: Robin Raczkiewicz");

                        //runloop ska bli falsk och stänga av kommand center loopen
                        runLoop = false;
                        break;

                    //om fel kommando skrivs in vid kommand centret så ska felmeddelande komma upp och starta om loopen
                    default:
                        Console.WriteLine("Ange ett giltigt kommand (1-4) och försök igen");
                        Console.WriteLine(" ");
                        break;
                }

            }

            Console.ReadLine();
        }
    }
}