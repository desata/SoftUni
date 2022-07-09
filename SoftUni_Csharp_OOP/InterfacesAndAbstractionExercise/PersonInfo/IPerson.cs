using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPerson
    {
        //Define an interface IPerson with properties for Name and Age

        string Name { get; set; }
        int Age { get; set; }

    }
}
