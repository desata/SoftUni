using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgnValidatorProgram
{
    public class InvalidCityException : Exception
    {
        public InvalidCityException(string cityName)
        {
            CityName = cityName;
        }

        public string CityName { get; }
    }
}
