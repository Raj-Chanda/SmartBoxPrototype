﻿namespace ConsoleConsumer
{
    public class NumberToWords
    {
        private static readonly string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] Thousands = { "", "Thousand", "Million", "Billion", "Trillion" };

        public static String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return ConvertToWords(amount_int);
                }
                else
                {
                    return ConvertToWords(amount_int) + " and " + ConvertToWords(amount_dec) + " paisa";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }

        public static string ConvertToWords(long number)
        {
            if (number == 0)
                return "Zero";

            string words = "";

            for (int i = 0; number > 0; i++)
            {
                if (number % 1000 != 0)
                    words = ConvertHundreds(number % 1000) + Thousands[i] + " " + words;

                number /= 1000;
            }

            return words.Trim();
        }

        private static string ConvertHundreds(long number)
        {
            string words = "";

            if (number >= 100)
            {
                words += Ones[number / 100] + " Hundred ";
                number %= 100;
            }

            if (number >= 10 && number <= 19)
            {
                words += Teens[number % 10] + " ";
            }
            else
            {
                words += Tens[number / 10] + " ";
                words += Ones[number % 10] + " ";
            }

            return words;
        }
    }
}

