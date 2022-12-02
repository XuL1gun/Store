using System;
using МагазинМузыкальныхДисков;

namespace Magazin
{
    public class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store("Wasp", "Город Морковный. Улица Свекольная, дом 555, квартира 444");

            Audio disc1 = new Audio("Leps", "RadioDacha", 2, "Dacha", "pop");

            Audio disc2 = new Audio("Tree", "Forest", 5, "Oak", "Rock");

            DVD dvd1 = new DVD("Tarantino", "Band part", 180, "desperate", "triller");

            DVD dvd2 = new DVD("Lasseter", "Pixar", 120, "Cars", "movies");

            store.AddAudio(disc1, disc2);

            store.AddDVD(dvd1, dvd2);

            store.ToString();

            dvd1.Burn("Ferrada", "Netflix", "Klaus", "movies");

            Console.WriteLine($"Название: {disc1._name}, жанр: {disc1.DiscSize}");
            Console.WriteLine($"Название: {disc2._name}, жанр: {disc2.DiscSize}");

            Console.WriteLine($"Название: {dvd1._name}, жанр: {dvd1.DiscSize}");
            Console.WriteLine($"Название: {dvd2._name}, жфнр: {dvd2.DiscSize}");
        }
    }
}


