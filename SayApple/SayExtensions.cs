using System;
using System.Collections.Generic;

namespace SayApple
{
    public static class SayExtensions
    {
        /// <summary>
        /// Filters on the given country-code.
        /// </summary>
        /// <param name="speeches">The list of speeches to go through.</param>
        /// <param name="countryCode">The country code as apple writes it. This is not case-sensitive.</param>
        /// <returns></returns>
        public static List<Speech> GetByCountryCode(this List<Speech> speeches, string countryCode)
        {
            var result = new List<Speech>();
            foreach(var speech in speeches)
            {
                if (speech.CountryCode.ToLower() == countryCode.ToLower())
                {
                    result.Add(speech);
                }
            }
            return result;
        }

        public static List<string> GetCountryCodes(this List<Speech> speeches)
        {
            var result = new List<string>();
            foreach (var speech in speeches)
            {
                if (!result.Contains(speech.CountryCode))
                {
                    result.Add(speech.CountryCode);
                }
            }
            return result;
        }
    }
}

