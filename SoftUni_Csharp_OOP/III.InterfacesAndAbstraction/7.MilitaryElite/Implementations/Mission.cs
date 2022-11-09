using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementations
{
    public class Mission : IMission
    {
        public Mission(string codeName, Status status)
        {
            CodeName = codeName;
            Status = status;
        }

        public string CodeName { get; set;  }
        public Status Status { get; set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {Status}";
        }
    }
}
