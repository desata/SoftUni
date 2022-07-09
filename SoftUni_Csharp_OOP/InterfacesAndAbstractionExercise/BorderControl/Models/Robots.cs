using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robots : IIdentifieble
    {
        public Robots(string model, string id)
        {
            this.Model = model;
            
            this.Id = id;
        }

        public string Model { get; private set; }
        public string Id { get; set; }
    }
}
