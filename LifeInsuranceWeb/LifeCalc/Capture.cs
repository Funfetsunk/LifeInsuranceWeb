﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsurance
{
    public class Capture
    {
        // Capture and validate client age.
        public static int CaptureAge(string DateOfBirth)
        {
            bool Redisp = true;
            DateTime dateofbirth;
            int Age = 0;
            while (Redisp)
            {
                if (DateTime.TryParse(DateOfBirth, out dateofbirth))
                {
                    Redisp = false;

                    Age = DateTime.Now.Year - dateofbirth.Year;
                    if (DateTime.Now.DayOfYear < dateofbirth.DayOfYear)
                        Age = Age - 1;
                }
                else
                {
                    Console.WriteLine("Please use format \"DD/MM/YYY\"");
                    Console.WriteLine("What is your date of birth (DD/MM/YYY)?");
                    DateOfBirth = Console.ReadLine();
                }
            }
            return Age;
        }

        // Capture and validate client gender
        public static string CaptureGender(String Gender)
        {
            bool Redisplay = true;

            while (Redisplay)
            {
                Gender = Gender.ToUpper();
                switch (Gender)
                {
                    case "M":
                        Redisplay = false;
                        break;

                    case "F":
                        Redisplay = false;
                        break;

                    default:
                        Redisplay = true;
                        Console.WriteLine("Please enter M or F.");
                        Console.WriteLine("What is your gender? (M/F)");
                        Gender = Console.ReadLine();
                        break;
                }
            }

            return Gender;
        }

        // Capture and validate smoker details.
        public static string CaptureSmoker(String Smoker)
        {
            bool Redisplay = true;

            while (Redisplay)
            {
                Smoker = Smoker.ToUpper();
                switch (Smoker)
                {
                    case "Y":
                        Redisplay = false;
                        break;

                    case "N":
                        Redisplay = false;
                        break;

                    default:
                        Redisplay = true;
                        Console.WriteLine("Please enter Y or N.");
                        Console.WriteLine("Are you a smoker? (enter Y/N)");
                        Smoker = Console.ReadLine();
                        break;
                }
            }
            return Smoker;
        }

        // Capture and validate client exercise details
        public static int CaptureExercise(int Exercise)
        {
            //bool Redisplay = true;
            //int exercise;
            //while (Redisplay)
            //{
            //    if (int.TryParse(Exercise, out exercise))
            //    {
            //        Redisplay = false;
            //    }
            //    else
            //    {
            //        Redisplay = true;
            //        Console.WriteLine("Please enter a whole number");
            //        Console.WriteLine("How many hours exercise do you do per week?");
            //        Exercise = Console.ReadLine();
            //    }
            //}
            return Exercise;
        }

        // Capture and validate children details
        public static string CaptureChildren(string Children)
        {
            bool Redisplay = true;

            while (Redisplay)
            {
                Children = Children.ToUpper();
                switch (Children)
                {
                    case "Y":
                        Redisplay = false;
                        break;

                    case "N":
                        Redisplay = false;
                        break;

                    default:
                        Redisplay = true;
                        Console.WriteLine("Please enter Y or N.");
                        Console.WriteLine("Do you have any children? (enter Y/N)");
                        Children = Console.ReadLine();
                        break;
                }
            }
            return Children;
        }
    }
}
