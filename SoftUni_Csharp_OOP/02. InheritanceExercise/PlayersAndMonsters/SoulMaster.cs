using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string username, int level) : base(username, level)
        {
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
