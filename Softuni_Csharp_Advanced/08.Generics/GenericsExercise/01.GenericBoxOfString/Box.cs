using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;  
        }

        public T Element { get; }

        public override string ToString()
        { 
           // return base.ToString();
            return $"{typeof(T)}: {Element}";
        }

    }
}
