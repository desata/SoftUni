using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class DarkKnight : Knight
    {
        public DarkKnight(string username, int level) : base(username, level)
        {
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
