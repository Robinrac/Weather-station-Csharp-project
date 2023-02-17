using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadClass
{
    class Stad
    {
        //använd public string namn med hjälp av get och set för att tillåta att få in och bestämma ett värde.
        public string namn { get; set; }
        public int temp { get; set; }

        //skapa en method stad
        public Stad(string namn, int temp)
        {
            this.namn = namn;
            this.temp = temp;
        }

        //ge classen stad stadens namn och bestäm värde (värde = namn)
        public string Namn
        {
            get { return this.namn; }
            set { namn = value; }
        }
        //ge classen stad stadens temperatur och bestäm värde (värde = temperatur)
        public int tempratur
        {
            get { return temp; }
            set { temp = value; }
        }
        //gör en method som så att värdet returnar som string
        public override string ToString()
        {
            return namn + " " + temp;
        }
    }
}
