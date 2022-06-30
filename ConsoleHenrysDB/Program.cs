using System;
using System.Linq;
using Henrys_DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using HenrysDbLayer;

namespace ConsoleHenrysDB
{
    class Program
    {
        public static DBLogic dbLogic {get; set;} 
        public static ConsoleFunctions consoleFunc { get; set; }
        public static Action<string> OutPut = (s) => Console.WriteLine(s);
        public static List<string> Outputlist; 
        static void Main(string[] args)
        {
            var host = StartUp.CreateHostBuilder(args).Build();
            var service = host.Services;
            var myScope = service.CreateScope();
            //var myContext = myScope.ServiceProvider.GetRequiredService<HenrysDBContext>();
            dbLogic = myScope.ServiceProvider.GetRequiredService<DBLogic>();
            consoleFunc = new ConsoleFunctions();

            Outputlist = ConfigOutPut();
            Outputlist.ForEach(item => OutPut(item));

            var auswahl = Console.ReadKey();

            var check = Check(auswahl);
            
            if(check == RunType.Course)
            {
                var courses = dbLogic.GetCourses();
                consoleFunc.GetCourseNames(courses);
            }
          

            //switch (auswahl.Key)
            //{
            //    case ConsoleKey.D1 or ConsoleKey.NumPad1:
            //        consoleFunc.WriteEmptyLine();
            //        KurseAnzeigen();
            //        break;

            //    case ConsoleKey.D2 or ConsoleKey.NumPad2:
            //        consoleFunc.WriteEmptyLine();
            //        SchuelerHinzufuegen();                   
            //        break;

            //    case ConsoleKey.D3 or ConsoleKey.NumPad3:
            //        KursteilnehmerHinzufuegen();                   
            //        break;

            //    case ConsoleKey.D4 or ConsoleKey.NumPad4:
            //        LehrerHinzufuegen();
            //        break;

            //    case ConsoleKey.D5 or ConsoleKey.NumPad5:
            //        TagHinzufuegen();
            //        break;

            //    default:
            //        break;
            //}
        }

        public static RunType Check(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    return RunType.Course;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    return RunType.Schedule;

                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                    return RunType.Student;

                case ConsoleKey.D4 or ConsoleKey.NumPad4:
                    return RunType.StudentCourseMapping;

                case ConsoleKey.D5 or ConsoleKey.NumPad5:
                    return RunType.Tutor;

                default:
                    return RunType.Undefined;
            }
        }
    
        public static void KurseAnzeigen() 
        {
            var courses = dbLogic.GetCourses();
            consoleFunc.GetCourseNames(courses);     
            
            OutPut("Bitte Kurs auswählen: ");

            var eingabe = consoleFunc.GetInput();
            int eingabeNummer;
            bool isNumeric = int.TryParse(eingabe, out eingabeNummer);
            bool run = true;

            while (run)
            {
                if (isNumeric && eingabeNummer >= 0 && eingabeNummer <= 10)
                {
                    var courseMembers = dbLogic.GetCourseMembers(eingabeNummer);

                    consoleFunc.WriteEmptyLine();
                    consoleFunc.WriteCourseMembersOutput(courseMembers);
                    run = false;
                }

                else
                {
                    OutPut("Bitte eine gültige Id eingeben");
                }
            }
        }

        public static void SchuelerHinzufuegen()
        {
            consoleFunc.WriteEmptyLine();

            var schueler = new Student();

            OutPut("Gebe den Vornamen ein:");
            var eingabeVorname = consoleFunc.GetInput();

            OutPut("Gebe den Nachnamen ein:");
            var eingabeNachname = consoleFunc.GetInput();

            OutPut("Gebe das Alter ein:");
            var eingabeAlter = consoleFunc.GetInput();

            int eingabeAlterNummer;
            bool isNumeric = int.TryParse(eingabeAlter, out eingabeAlterNummer);

            if (isNumeric)
            {
                schueler.Age = eingabeAlterNummer;
                schueler.LastName = eingabeVorname;
                schueler.LastName = eingabeNachname;
                dbLogic.AddStudent(schueler);
            }

            else
            {
                OutPut("Bitte Nummer eingeben!");
            }
        }

        public static void KursteilnehmerHinzufuegen()
        {
            bool run = true;           

            while (run == true)
            {
                var ids = dbLogic.GetStudentIds();

                consoleFunc.WriteEmptyLine();

                consoleFunc.WriteStudentIds(ids);

                OutPut("Geben sie die Id des Schülers ein: ");

                var eingabeId = consoleFunc.GetInput();

                var course = dbLogic.GetCourseDetails();

                consoleFunc.WriteCourseDetails(course);

                    OutPut("Wähle eine KursId: ");

                    var eingabeKurs = consoleFunc.GetInput();
                    var mapping = new StudentCourseMapping();

                    mapping.StudentId = Int32.Parse(eingabeId);
                    mapping.CourseId = Int32.Parse(eingabeKurs);

                dbLogic.AddSCMapping(mapping);

                OutPut("Weitere Kurse eintragen?");
                OutPut("Drücke '+' falls ja");

                var antwort = Console.ReadKey();

                if(antwort.Key == ConsoleKey.OemPlus)
                {
                    run = true;
                }

                else
                {
                    run = false;
                } 
            }
        }

        public static void LehrerHinzufuegen()
        {
            Console.WriteLine();

            var tutor = new Tutor();
            
                Console.WriteLine("Gebe den Namen ein:");

                var name = Console.ReadLine();
                tutor.LastName = name;

            dbLogic.AddTutor(tutor);            
        }

        public static void TagHinzufuegen()
        {
            DateTime tag;
            bool run = true; 

            Console.WriteLine();

            while (run == true)
            {
                var slot1 = new Schedule();
                var slot2 = new Schedule();
                var slot3 = new Schedule();
                var slot4 = new Schedule();
                var slot5 = new Schedule();

                Console.WriteLine("Gebe das Datum ein:      z.B.: 2022-01-21");
                    var eingabeTag = Console.ReadLine();

                bool isDate = DateTime.TryParse(eingabeTag, out tag);

                if (isDate == true)
                {
                    slot1.DateDay = tag;
                    slot2.DateDay = tag;
                    slot3.DateDay = tag;
                    slot4.DateDay = tag;
                    slot5.DateDay = tag;

                    TimeSpan ts1 = new TimeSpan(8, 0, 0);
                    TimeSpan ts2 = new TimeSpan(9, 30, 0);
                    TimeSpan ts3 = new TimeSpan(9, 50, 0);
                    TimeSpan ts4 = new TimeSpan(11, 20, 0);
                    TimeSpan ts5 = new TimeSpan(11, 40, 0);
                    TimeSpan ts6 = new TimeSpan(13, 10, 0);
                    TimeSpan ts7 = new TimeSpan(14, 0, 0);
                    TimeSpan ts8 = new TimeSpan(15, 30, 0);
                    TimeSpan ts9 = new TimeSpan(15, 30, 0);
                    TimeSpan ts10 = new TimeSpan(17, 0, 0);

                    slot1.TimeCourseBeginning = slot1.DateDay + ts1;
                    slot1.TimeCourseEnd = slot1.DateDay + ts2;

                    slot2.TimeCourseBeginning = slot2.DateDay + ts3;
                    slot2.TimeCourseEnd = slot2.DateDay + ts4;

                    slot3.TimeCourseBeginning = slot3.DateDay + ts5;
                    slot3.TimeCourseEnd = slot3.DateDay + ts6;

                    slot4.TimeCourseBeginning = slot4.DateDay + ts7;
                    slot4.TimeCourseEnd = slot4.DateDay + ts8;

                    slot5.TimeCourseBeginning = slot5.DateDay + ts9;
                    slot5.TimeCourseEnd = slot5.DateDay + ts10;

                    dbLogic.AddScheduleDay(slot1);
                    dbLogic.AddScheduleDay(slot2);
                    dbLogic.AddScheduleDay(slot3);
                    dbLogic.AddScheduleDay(slot4);
                    dbLogic.AddScheduleDay(slot5);

                    run = false;
                }

                else
                {
                    Console.WriteLine("Bitte ein richtiges Datum eingeben!");
                    run = true;
                }
            }
        }

        public static List<string> ConfigOutPut()
        {
            return new List<string>()
            {
                "Kurse anzeigen:                  1",
                "Schüler hinzufügen:              2",
                "Kursteilnehmer hinzufügen:       3",
                "Lehrer hinzufügen:               4",
                "Tag hinzufügen:                  5"
            };
        }
    }
}
