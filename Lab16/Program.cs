using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Lab16
{

    // Моделирование объекта «Товар» в файл «Products.json».
    class Program
    {
        static void Main(string[] args)
        {
            Product[] product = new Product[5];
            {
                for (int i = 0; i < 5; i++)
                {
                    product[i] = new Product();
                    Console.WriteLine("Введите данные {0} продукта", i + 1);
                    Console.WriteLine("Введите код товара");
                    product[i].Code = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите название товара");
                    product[i].Title = Console.ReadLine();
                    Console.WriteLine("Введите цену товара");
                    product[i].Price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\n");
                }
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string jsonStringProducts = JsonSerializer.Serialize(product, options);
            StreamWriter jsonWriteFileProducts = new StreamWriter("Products.json", false);
            jsonWriteFileProducts.Write(jsonStringProducts);
            jsonWriteFileProducts.Close();
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
