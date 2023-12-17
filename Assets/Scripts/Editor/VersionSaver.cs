using System;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [InitializeOnLoad]
    public class AutoVersionUpdateOnSave
    {
        static AutoVersionUpdateOnSave()
        {
            EditorApplication.projectChanged += UpdateVersionNumber;
        }

        public static void UpdateVersionNumber()
        {
            DateTime now = DateTime.Now;
            int yearsSince2016 = now.Year - 2016;
            int dayOfYear = now.DayOfYear;
            int hourOfDay = now.Hour;
            int secondOfMinute = now.Second;

            string version = $"{yearsSince2016}.{dayOfYear}.{hourOfDay}.{secondOfMinute}";
            PlayerSettings.bundleVersion = version;
            Debug.Log("Updated version number to: " + version);
        }

        private static string IntToRoman(int num)
        {
            string[] thousands = { "", "M", "MM", "MMM", "MMMM", "MMMMM", "MMMMMM", "MMMMMMM", "MMMMMMMM", "MMMMMMMMM", "MMMMMMMMMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return thousands[num / 1000] + hundreds[(num % 1000) / 100] + tens[(num % 100) / 10] + ones[num % 10];
        }
    }
}