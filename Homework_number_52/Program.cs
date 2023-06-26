using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_number_52
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();

            string crimeCoveredByAmnesty = "Антиправительственное";

            prison.ShowAllPrisoners();

            Console.WriteLine("Для того что бы объявить амнистию нажмите любую клавишу.");
            Console.ReadKey();

            prison.DeclareAmnesty(crimeCoveredByAmnesty);

            prison.ShowAllPrisoners();

            Console.ReadLine();
        }
    }
    class Prisoner
    {
        public Prisoner(string surname, string name, string patronymic, string crime)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Crime = crime;
        }

        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public string Crime { get; private set; }
    }

    class Prison
    {
        private List<Prisoner> _prisoners = new List<Prisoner>();

        public Prison()
        {
            Fill();
        }

        public void DeclareAmnesty(string crime)
        {
            _prisoners = _prisoners.Where(Prisoner => Prisoner.Crime != crime).ToList();
        }

        public void ShowAllPrisoners()
        {
            for (int i = 0; i < _prisoners.Count; i++)
            {
                Console.WriteLine($"Фамилия: {_prisoners[i].Surname}");
                Console.WriteLine($"Имя: {_prisoners[i].Name}");
                Console.WriteLine($"Отчество: {_prisoners[i].Patronymic}");
                Console.WriteLine($"Преступление: {_prisoners[i].Crime}");
                Console.WriteLine();
            }
        }

        private void Fill()
        {
            Random random = new Random();

            List<string> surnames = new List<string>
           {
            "Иванов",
            "Петров",
            "Сидоров",
            "Смирнов",
            "Козлов",
            "Макаров",
            "Павлов",
            "Соколов",
            "Петрова",
            "Иванова"
           };
            List<string> names = new List<string>
           {
            "Иван",
            "Петр",
            "Алексей",
            "Ольга",
            "Андрей",
            "Максим",
            "Екатерина",
            "Игорь",
            "Анна",
            "Мария"
           };
            List<string> patronymics = new List<string>
            {
            "Иванович",
            "Петрович",
            "Васильевич",
            "Петровна",
            "Сергеевич",
            "Игоревич",
            "Александровна",
            "Сергеевич",
            "Владимировна",
            "Ивановна"
            };
            List<string> crimes = new List<string>
            {
            "Кража",
            "Мошенничество",
            "Нарушение правил дорожного движения",
            "Незаконное оборотное оружие",
            "Антиправительственное"
            };

            int quantityPrisoners = 10;

            for (int i = 0; i < quantityPrisoners; i++)
            {
                _prisoners.Add(new Prisoner(surnames[random.Next(surnames.Count)],
                                            names[random.Next(names.Count)],
                                            patronymics[random.Next(patronymics.Count)],
                                            crimes[random.Next(crimes.Count)]));
            }
        }
    }
}
