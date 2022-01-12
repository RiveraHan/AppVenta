using System;
using AppVenta.Infrastructure.Data.Contexts;
namespace AppVenta.Infrastructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("creating db!");
            SaleContext db = new SaleContext();
            db.Database.EnsureCreated();
            Console.WriteLine("Ready");
            Console.ReadKey();
        }
    }
}
