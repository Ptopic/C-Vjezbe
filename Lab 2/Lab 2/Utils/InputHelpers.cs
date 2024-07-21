using System;
using static Bogus.DataSets.Name;
using System.Text.RegularExpressions;

namespace Lab_2
{
	public class InputHelpers
	{
        public static int InputNumberChoice(int minValue, int maxValue, string message = "\nEnter your choice:")
        {
            do
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out int numberChoice)
                    && numberChoice >= minValue && numberChoice <= maxValue)
                {
                    return numberChoice;
                }

                Console.WriteLine("Wrong input!");
            } while (true);
        }

        public static string InputValue(string inputType)
        {
            do
            {
                Console.WriteLine($"{inputType}:");

                var input = Console.ReadLine().Trim();

                if (ValidateInput(input, inputType)) return input;

                Console.WriteLine("Input is invalid!");
            } while (true);
        }

        public static bool ValidateInput(string input, string inputType)
        {
            switch (inputType)
            {
                case "OIB":
                    return ValidateOib(input);
                case "MBO":
                    return ValidateMbo(input);
                case "Gender":
                    return ValidateGender(input);
                case "First name":
                case "Last name":
                case "Diagnosis":
                    return input.Length > 0;
                default: return false;
            }
        }

        public static bool ValidateOib(string input)
        {
            return Regex.IsMatch(input, "^[0-9]{11}$");
        }

        public static bool IsOibUnique(string oib, List<Patient> patients)
        {
            return !patients.Any(p => p.OIB == oib);
        }

        public static string InputUniqueOib(List<Patient> patients)
        {
            string oib;
            bool isOibUnique;

            do
            {
                oib = InputValue("OIB");

                isOibUnique = IsOibUnique(oib, patients);
                if (!isOibUnique)
                {
                    Console.WriteLine("Patient with that OIB already exists. Please retry.");
                }
            } while (!isOibUnique);

            return oib;
        }

        public static bool ValidateMbo(string input)
        {
            return Regex.IsMatch(input, "^[0-9]{9}$");
        }

        public static bool IsMboUnique(string mbo, List<Patient> patients)
        {
            return !patients.Any(p => p.MBO == mbo);
        }

        public static string InputUniqueMbo(List<Patient> patients)
        {
            string mbo;
            bool isMboUnique;

            do
            {
                mbo = InputValue("MBO");

                isMboUnique = IsMboUnique(mbo, patients);
                if (!isMboUnique)
                {
                    Console.WriteLine("Patient with that MBO already exists. Please retry.");
                }
            } while (!isMboUnique);

            return mbo;
        }

        public static bool ValidateGender(string input)
        {
            if (input.Equals("M") || input.Equals('F'))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static DateTime InputDateOfBirth()
        {
            do
            {
                Console.WriteLine($"Date of birth:");

                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth) && dateOfBirth < DateTime.Now)
                {
                    return dateOfBirth;
                }

                Console.WriteLine("Input is invalid!");
            } while (true);
        }

        public static ActionOptions ConfirmAction()
        {
            Console.WriteLine(@"
---------------------
0 - Cancel
1 - Confirm
---------------------");
            return (ActionOptions)InputHelpers.InputNumberChoice(
                Enum.GetValues(typeof(ActionOptions)).Cast<int>().Min(),
                Enum.GetValues(typeof(ActionOptions)).Cast<int>().Max());
        }
    }
}

