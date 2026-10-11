namespace Лабораторна4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===  РОЗРАХУНОК ДНЯ ТИЖНЯ ТА РОЗКЛАДУ ПАР ===\n");

            // --- 1. ВВЕДЕННЯ ДАНИХ ТА ПЕРЕВІРКА КОРЕКТНОСТІ (TryParse) ---
            Console.Write("Введіть номер дня тижня (1-7): ");
            bool okDay = int.TryParse(Console.ReadLine(), out int dayNumber);

            Console.Write("Введіть номер пари (1-6): ");
            bool okPair = int.TryParse(Console.ReadLine(), out int pairNumber);

            // Перевіряємо, чи зчиталися числа і чи входять вони в допустимі межі
            if (!okDay || !okPair || dayNumber < 1 || dayNumber > 7 || pairNumber < 1 || pairNumber > 6)
            {
                Console.WriteLine("\n[ПОМИЛКА] Введено некоректні дані! Номер дня має бути від 1 до 7, а пара від 1 до 6.");
                return; // Зупиняємо програму в разі помилки
            }

            // --- 2. РІВЕНЬ А: КЛАСИЧНИЙ ОПЕРАТОР SWITCH (для дня тижня) ---
            string dayName = "";
            bool isWeekend = false;

            switch (dayNumber)
            {
                case 1:
                    dayName = "Понеділок";
                    isWeekend = false;
                    break;
                case 2:
                    dayName = "Вівторок";
                    isWeekend = false;
                    break;
                case 3:
                    dayName = "Середа";
                    isWeekend = false;
                    break;
                case 4:
                    dayName = "Четвер";
                    isWeekend = false;
                    break;
                case 5:
                    dayName = "П'ятниця";
                    isWeekend = false;
                    break;
                case 6:
                    dayName = "Субота";
                    isWeekend = true;
                    break;
                case 7:
                    dayName = "Неділя";
                    isWeekend = true;
                    break;
                default:
                    dayName = "Невідомий день";
                    break;
            }

            // --- 3. РІВЕНЬ А: ВИРАЗ SWITCH (C# 8+) (для часу початку пари) ---
            string pairTime = pairNumber switch
            {
                1 => "8:30",
                2 => "10:05",
                3 => "12:00",
                4 => "13:35",
                5 => "15:10",
                6 => "16:45",
                _ => "Невідомий час"
            };

            // --- 4. РІВЕНЬ Б: ВИРАЗ SWITCH ІЗ РЕЛЯЦІЙНИМИ ЗРАЗКАМИ ТА УМОВОЮ WHEN ---
            string dayCategory = pairNumber switch
            {
                >= 1 and <=2 when isWeekend => "Консультація / Відпрацювання у вихідних",
                >= 1 and <=2 => "Легкий навчальний день (1-2 пари)",
                >= 3 and <=4 => "Середній навчальний день (3-4 пари)",
                >= 5 and <=6 => "Інтенсивний навчальний день (5-6 пар)",
                _ => "Невизначена категорія"
            };

            // --- 5. ВИВЕДЕННЯ РЕЗУЛЬТАТІВ ---
            Console.WriteLine("\n┌─────────────────────────┬──────────────────────────────────────────┐");
            Console.WriteLine($"│ {"Показник",-23} │ {"Значення",-40} │");
            Console.WriteLine("├─────────────────────────┼──────────────────────────────────────────┤");
            Console.WriteLine($"│ {"День тижня",-23} │ {dayName,-40} │");
            Console.WriteLine($"│ {"Статус дня",-23} │ {(isWeekend ? "Вихідний день" : "Робочий день"),-40} │");
            Console.WriteLine($"│ {"Початок пари №" + pairNumber,-23} │ {pairTime + " год",-40} │");
            Console.WriteLine($"│ {"Категорія навантаження",-23} │ {dayCategory,-40} │");
            Console.WriteLine("└─────────────────────────┴──────────────────────────────────────────┘");
        }
    }
   }

