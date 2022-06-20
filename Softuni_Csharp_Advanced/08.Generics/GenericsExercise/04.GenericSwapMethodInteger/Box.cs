using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elementsList)
        {
        Elements = elementsList;
        }

        public T Element { get; }

        public List<T> Elements { get; }

        public void Swap(List<T> elements, int indexOne, int indexTwo)
        {
            T firstElement = elements[indexOne];
            elements[indexOne] = elements[indexTwo];
            elements[indexTwo] = firstElement;

        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (T element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();

            // return base.ToString();
            //return $"{typeof(T)}: {Element}";
        }
    }
}
