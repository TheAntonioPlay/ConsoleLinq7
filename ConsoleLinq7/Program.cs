using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleLinq7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army();
            army.OpenProgram();
        }
    }

    class Army
    {
        private List<Soldier> _soldiers1 = new List<Soldier>
        {
            new Soldier("Баранов Игорь Петрович"),
            new Soldier("Будько Иван Степанович"),
            new Soldier("Иванов Андрей Владимирович")
        }; 

        private List<Soldier> _soldiers2 = new List<Soldier>
        { 
            new Soldier("Смирнов Александр Семёнович"), 
            new Soldier("Павлов Семён Игоревич")
        };

        public void OpenProgram()
        {
            Console.WriteLine("Список всех солдат из отряда 1:");
            ShowAllSoldiers(_soldiers1);
            Console.WriteLine("\nСписок всех солдат из отряда 2:");
            ShowAllSoldiers(_soldiers2);
            RelocateSoldiers();
            Console.ReadKey();
            Console.WriteLine("\nОбновлённый список солдат из отряда 1:");
            ShowAllSoldiers(_soldiers1);
            Console.WriteLine("\nОбновлённый список солдат из отряда 2:");
            ShowAllSoldiers(_soldiers2);
            Console.ReadKey();
        }

        private void RelocateSoldiers()
        {
            var filteredSoldiers = _soldiers1.Where(soldier => soldier.FullName.StartsWith("Б"));

            _soldiers2 = _soldiers2.Union(filteredSoldiers).ToList();
            _soldiers1 = _soldiers1.Except(filteredSoldiers).ToList();
        }

        private void ShowAllSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }
        }
    }

    class Soldier
    {
        public string FullName { get; private set; }

        public Soldier(string fullName)
        {
            FullName = fullName;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Полное имя солдата: {FullName}");
        }
    }
}
