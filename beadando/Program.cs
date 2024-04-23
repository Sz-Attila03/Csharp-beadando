using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> gyujtemeny = new BlockingCollection<string>();
            string[] kiir;

            gyujtemenyhezAdd( gyujtemeny, "Nissan", "Toyota", "Ferrari", "Subaru" );
            gyujtemenyhezAdd( gyujtemeny, "Audi", "Ford" );
            gyujtemenyhezAdd( gyujtemeny, "Bugati", "Lexus", "Mazda", "Cadillac", "Honda", "Acura", "Dodge", "Alfa Romeo", "Daihatsu", "Infiniti");
            gyujtemenyhezAdd( gyujtemeny, "Mitsubishi", "Shelby", "Mclaren", "Mazerati");

            kiir = gyujtemeny.ToArray();

            tombKiiras( kiir );

            Console.WriteLine( "\n\nA gyüjteményben " + gyujtemeny.Count + " elem tatalhato." );

            tombElsoEleme( gyujtemeny );

            Console.WriteLine( "\nA gyujtemény legnyagyobb erteke: " + gyujtemeny.Max() );
            Console.WriteLine( "\nA gyujtemény legkissebb erteke: " + gyujtemeny.Min() );


            Console.ReadLine();
        }

        static void tombKiiras( string[] kiir )
        {
            Console.WriteLine("\nkiir tomb elemei:");
            for (int i = 0; i < kiir.Length; i++)
            {
                Console.Write(kiir[i] + ", ");
            }
        }

        static void gyujtemenyhezAdd( BlockingCollection<string> gyujtemeny, params string[] elem )
        {
            foreach ( string e in elem )
            {
                gyujtemeny.Add(e);
            }
        }

        static void tombElsoEleme( BlockingCollection<string> gyujtemeny )
        {
            Console.WriteLine( "\nA gyujtemeny elso eleme " + gyujtemeny.Take() );
        }
    }
}
