using Calendar.Days;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calendar
{
    public class CalendarMenu
    {
        public static void CreateCalendar()
        {
            Console.Clear();
            var monthLevel = new MonthLevel();
            var createCalendar = new CreateCalendar();
            var calendarDrawer = new CalendarDrawer();

            var specialList = new ListForNotes();
            specialList.UserDay = new List<SpecialDay>();
            var cheker = new MonthLevel();

            var allMonthes = new AddYear();
            var oldMonth = monthLevel.MonthNumber;

            bool stillWatch = true;
            var noNotes = "No notes for today.";
            while (stillWatch)
            {
                var creater = createCalendar.Create(monthLevel.DaysInWeek, monthLevel.WeeksInMonth, monthLevel.DayNumber,
                    monthLevel.EmptyDays, monthLevel.MonthNumber, monthLevel.Year);
                List<SpecialDay> count = specialList.UserDay.FindAll(cell => cell.Year == creater.Year && cell.Month == creater.MonthNumber);
                if (count.Count != 0)
                {
                    creater = CheckCalendar(specialList, creater, noNotes);
                }
                calendarDrawer.Draw(creater);
                calendarDrawer.AddCountOfWeekendsAndWorkDays(monthLevel);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("use 'Q' or 'E' to scrolling monthes");
                Console.WriteLine("use 'A' or 'D' to scrolling years");
                Console.WriteLine("Use 'Space' for enter date.");
                Console.WriteLine("use 'DownArrow' to watch all monthes in current Year");
                Console.ForegroundColor = ConsoleColor.White;
                var key = Console.ReadKey();
                switch (key.Key)
                {

                    case ConsoleKey.Q:

                        Console.Clear();
                        monthLevel.MonthNumber--;
                        if (monthLevel.MonthNumber < 1)
                        {
                            monthLevel.MonthNumber = 12;
                            monthLevel.Year--;
                        }
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        monthLevel.MonthNumber++;
                        if (monthLevel.MonthNumber > 12)
                        {
                            monthLevel.MonthNumber = 1;
                            monthLevel.Year++;
                        }
                        break;

                    case ConsoleKey.Spacebar:
                        bool boolForNote1 = true;
                        bool boolForNote2 = true;
                        var mess = "\nEnter date in format dd.mm.yyyy:\n";
                        var userDate = EnterDate(mess);
                        Console.Clear();
                        monthLevel.MonthNumber = userDate.Month;
                        monthLevel.Year = userDate.Year;
                        var monthLevelForNote = createCalendar.Create(monthLevel.DaysInWeek, monthLevel.WeeksInMonth, monthLevel.DayNumber,
                        monthLevel.EmptyDays, monthLevel.MonthNumber, monthLevel.Year);
                        while (boolForNote1)
                        {
                            monthLevelForNote = CheckCalendar(specialList, monthLevelForNote, noNotes);
                            var noteDay = monthLevelForNote.Month.Find(x => x.Symbol == userDate.Day.ToString());
                            Console.Clear();
                            Console.Write($"Your choosed: {userDate.ToShortDateString()}.  \n{noteDay.Note}\n\n");
                            Console.Write("Add note for this day?  \nPress \"Y\" .... \"N\"....\"X\".\n");
                            boolForNote2 = true;
                            while (boolForNote2)
                            {
                                var key2 = Console.ReadKey();
                                switch (key2.Key)
                                {
                                    case ConsoleKey.Y:
                                        Console.Clear();
                                        Console.Write("Enter your note: \n");
                                        var note = Console.ReadLine();
                                        specialList = AddNotes(specialList, userDate, note, noNotes);
                                        monthLevel.MonthNumber = DateTime.Now.Month;
                                        monthLevel.Year = DateTime.Now.Year;
                                        boolForNote1 = false;
                                        boolForNote2 = false;
                                        Console.Clear();
                                        break;
                                    case ConsoleKey.N:
                                        Console.Clear();
                                        monthLevel.MonthNumber = DateTime.Now.Month;
                                        monthLevel.Year = DateTime.Now.Year;
                                        boolForNote1 = false;
                                        boolForNote2 = false;
                                        break;
                                    case ConsoleKey.X:
                                        specialList.UserDay.RemoveAll(x => x.Day == userDate.Day &&
                                        x.Month == userDate.Month && x.Year == userDate.Year);
                                        boolForNote2 = false;
                                        break;

                                }

                            }
                        }

                        break;


                    case ConsoleKey.A:
                        Console.Clear();
                        monthLevel.Year--;
                        if (monthLevel.Year <= 0)
                        {
                            Console.WriteLine("I can't show u calendar for -1 Year");
                            monthLevel.Year++;
                        }
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        monthLevel.Year++;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        bool stillWatchYear = true;
                        while (stillWatchYear == true)
                        {
                            oldMonth = monthLevel.MonthNumber;
                            allMonthes.DrawYear(monthLevel);
                            allMonthes.AddCountForWeekendsAndWorkDaysInYear(monthLevel);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("use 'UpArrow' for back to watching month");
                            Console.WriteLine("use 'A' or 'D' to scrolling years");
                            Console.ForegroundColor = ConsoleColor.White;
                            var key3 = Console.ReadKey();
                            switch (key3.Key)
                            {
                                case ConsoleKey.UpArrow:
                                    Console.Clear();
                                    monthLevel.MonthNumber = oldMonth;
                                    stillWatchYear = false;
                                    break;
                                case ConsoleKey.A:
                                    Console.Clear();
                                    monthLevel.Year--;
                                    if (monthLevel.Year <= 0)
                                    {
                                        Console.WriteLine("I can't show u calendar for -1 Year");
                                        monthLevel.Year++;
                                    }
                                    break;
                                case ConsoleKey.D:
                                    Console.Clear();
                                    monthLevel.Year++;
                                    break;
                            }
                        }
                        break;
                    

                    case ConsoleKey.Escape:
                        stillWatch = false;
                        break;

                }
            }


        }

        private static ListForNotes AddNotes(ListForNotes List, DateTime Date, string note, string noNotes)
        {
            var specialList = List;
            List<SpecialDay> findNote = specialList.UserDay.FindAll(x => x.Day == Date.Day &&
                                x.Month == Date.Month && x.Year == Date.Year && x.Note != noNotes);
            if (findNote.Count != 0)
            {
                findNote[0].Note += "\n" + note;
                findNote[0].Color = ConsoleColor.Green;
            }
            else
            {
                var datee = new SpecialDay()
                {
                    Day = Date.Day,
                    Month = Date.Month,
                    Year = Date.Year,
                    Note = note
                };
                specialList.UserDay.Add(datee);
            }
            return specialList;
        }

        public static MonthLevel CheckCalendar(ListForNotes list, MonthLevel crea, string noNotes)
        {
            var creator = crea;
            var specialList = list;
            for (int i = 0; i < crea.Month.Count; i++)
            {
                crea.Month[i].Note = noNotes;
            }
            List<SpecialDay> count = specialList.UserDay.FindAll(cell => cell.Year == creator.Year && cell.Month == creator.MonthNumber);
            if (count.Count != 0)
            {
                for (int x = 0; x < count.Count; x++)
                {
                    for (int y = 0; y < creator.Month.Count; y++)
                    {
                        if (count[x].Day.ToString() == creator.Month[y].Symbol)
                        {
                            creator.Month[y].Note = count[x].Note;
                            creator.Month[y].Color = count[x].Color;
                        }

                    }
                }
            }
            return count.Count == 0 ? crea : creator;
        }

        private static DateTime EnterDate(string mess)
        {
            DateTime date;
            string input;
            int i = 0;
            do
            {
                do
                {
                    if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nOops...Something seems to have gone wrong! \nDon't look into the past, Bunny. And enter the date in the correct format dd.mm.yyyy:\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(mess);
                    }
                    input = Console.ReadLine();
                    i++;
                }while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out date));
            } while (date.Year < DateTime.Now.Year || date.Month < DateTime.Now.Month);
            return date;
        }
    }
}
