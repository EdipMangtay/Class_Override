using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace poli_evam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hamper Sepet = new Hamper();

            Phone p1 = new Phone() { Price = 400, Product = "İphone" };
            Sepet.add(p1);
            Textile t = new Textile() { size = "Xl", Price = 300, Material = "Iron", Company = "ADL" };
            Sepet.add(t);
            Pc c = new Pc() { Intel = "i7", Price = 30000, Product = "Monster notebook", Ram = "16 GB", Ssd = "512 GB" };
            Sepet.add(c);

            Console.WriteLine(c.Ram);
            Console.WriteLine(c.Ssd);
            Console.WriteLine(c.Product);
            Console.WriteLine(c.Price);
            Console.WriteLine("Above of these are Notebooks property");
            

            Console.WriteLine("Total Price " + Sepet.Total());
            Console.ReadLine();


        }
    }
    class Urun
    {
        public string Product { get; set; }
        public double Price { get; set; }

        public virtual double KDV()
        {
            return Price * 1.20;
        }
    }
    class Textile : Urun
    {
        public string Material;
        public string size;
        public string Company;
        //KDV oranı 1.20 olduğu için methodu override etmedik.

    }
    class Phone : Urun
    {
        
        public string Prop;

    }
    class Pc : Urun
    {
        public string Ram;
        public string Ssd;
        public string Intel;
        public override double KDV()
        {
            return Price * 1.8;

        }
    }
    class Hamper: Urun
    {
        private List<Urun> cart = new List<Urun>();

        public double Total()
        {
            double total = 0;
            foreach (Urun item in cart)
            {
                total += item.KDV();

            }
            return total;
           
        }
        public void add(Urun newurun)
        {
            cart.Add(newurun);

        }

    }

}
