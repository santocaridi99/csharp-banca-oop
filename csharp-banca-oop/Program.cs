using System;

namespace csharp_banca_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banca MiaBanca = new Banca("Banco di Napoli");
            Cliente cliente = new Cliente("CICCIO" , "Pasticcio" ,"ccccccc",22);
            Console.WriteLine(cliente.ToString());

        }
    }
}