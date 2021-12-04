using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Lab16._1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Необходимо разработать программу для получения информации о товаре из json-файла.
            Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/

            StreamReader jsonReadFileProducts = new StreamReader("Products.json");
            string jsonStringProduct = jsonReadFileProducts.ReadToEnd();
            Product[] product = new Product[5];
            product = JsonSerializer.Deserialize<Product[]>(jsonStringProduct);
            string dearestTitelProduct = "";
            double dearestPriceProduct = 0;
            for (int i = 0; i < 5; i++)
            {
                if(product[i].Price> dearestPriceProduct)
                    {
                    dearestTitelProduct = product[i].Title;
                    dearestPriceProduct = product[i].Price;
                }
            }
            Console.WriteLine(dearestTitelProduct);
            Console.ReadKey();
        }
    }
    public class Product
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
