using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public struct Human
    {
        public char Sex;
        public int Age;
    }

    public struct Cinema
    {
        public Human[,] humans;
        public Random random;
        public int countOfPeople;
        public char[] sexes;
        List<Human> listOfHumans;

        public Cinema(int x, int y, int countOfPeole)
        {
            humans = new Human[x, y];
            random = new Random();
            this.countOfPeople = countOfPeole;
            sexes = new char[2] { 'M', 'F' };
            listOfHumans = new List<Human>();
        }

        public void SetPeople()
        {
            int x, y;

            for (int i = 0; i < countOfPeople; i++)
            {
                while (true)
                {
                    x = random.Next(0, humans.GetLength(0));
                    y = random.Next(0, humans.GetLength(1));

                    if (humans[x, y].Age == 0)
                    {
                        humans[x, y] = new Human { Age = random.Next(16, 90), Sex = sexes[random.Next(0, 2)] };
                        listOfHumans.Add(humans[x, y]);
                        break;
                    }
                }
            }
        }


        //    public void PrintCinema()
        //{
        //    for (int i = 0; i < humans.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < humans.GetLength(1); j++)
        //        {
        //            if (humans[i, j].Age != 0)
        //            {
        //                Console.Write($" {humans[i, j].Sex} ");
        //            }
        //            else
        //                Console.Write(" - ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public int GetNumberOfSpectators()
        {

            int numberOfSpec = 0;
            foreach (var item in listOfHumans)
            {
                if (item.Age != 0)
                    numberOfSpec++;
            }
            return numberOfSpec;
        }

        public int GetNumberOfMaleSpectators()
        {

            int numberOfMaleSpec = 0;
            foreach (var item in listOfHumans)
            {
                if (item.Sex == 'M')
                    numberOfMaleSpec++;
            }
            return numberOfMaleSpec;
        }

        public int GetNumberOfFemaleSpectators()
        {

            int numberOfFemaleSpec = 0;
            foreach (var item in listOfHumans)
            {
                if (item.Sex == 'F')
                    numberOfFemaleSpec++;
            }
            return numberOfFemaleSpec;
        }


        public float GetAverageAge()
        {

            float averageAge = 0;
            foreach (var item in listOfHumans)
            {
                averageAge += item.Age;
            }
            return averageAge / listOfHumans.Count;
        }

        public float GetAverageAgeM()
        {

            float averageAgeM = 0;
            int count = 0;
            foreach (var item in listOfHumans)
            {
                if (item.Sex == 'M')
                {
                    count++;

                    averageAgeM += item.Age;
                }
            }
            return averageAgeM / count;
        }
        public float GetAverageAgeF()
        {

            float averageAgeF = 0;
            int count1 = 0;
            foreach (var item in listOfHumans)
            {
                if (item.Sex == 'F')
                {
                    count1++;

                    averageAgeF += item.Age;
                }
            }
            return averageAgeF / count1;
        }

    }
    

    

    class Program
    {
        static void PrintCinema(Cinema cinema)
        {
            for (int i = 0; i < cinema.humans.GetLength(0); i++)
            {
                for (int j = 0; j < cinema.humans.GetLength(1); j++)
                {
                    if (cinema.humans[i, j].Age != 0)
                    {
                        Console.Write($" {cinema.humans[i, j].Sex} ");
                    }
                    else
                        Console.Write(" - ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Cinema cinema = new Cinema(8, 7, 50);
            cinema.SetPeople();
            //cinema.PrintCinema();
            PrintCinema(cinema);
            Console.WriteLine($"Number of Spectators: {cinema.GetNumberOfSpectators()}");
            Console.WriteLine($"Average Age of All Spectators: {cinema.GetAverageAge()}");
            Console.WriteLine($"Number of Male Spectators: {cinema.GetNumberOfMaleSpectators()}");
            Console.WriteLine($"Average Age of Male Spectators: {cinema.GetAverageAgeM()}");
            Console.WriteLine($"Number of Female Spectators: {cinema.GetNumberOfFemaleSpectators()}");
            Console.WriteLine($"Average Age of Female Spectators: {cinema.GetAverageAgeF()}");
            Console.WriteLine();

            Cinema cinema1 = new Cinema(5, 5, 10);
            cinema1.SetPeople();
            PrintCinema(cinema1);
            Console.WriteLine($"Number of Spectators: {cinema1.GetNumberOfSpectators()}");
            Console.WriteLine($"Average Age of All Spectators: {cinema1.GetAverageAge()}");
            Console.WriteLine($"Number of Male Spectators: {cinema1.GetNumberOfMaleSpectators()}");
            Console.WriteLine($"Average Age of Male Spectators: {cinema1.GetAverageAgeM()}");
            Console.WriteLine($"Number of Female Spectators: {cinema1.GetNumberOfFemaleSpectators()}");
            Console.WriteLine($"Average Age of Female Spectators: {cinema1.GetAverageAgeF()}");
            Console.WriteLine();
        }
    }
}
