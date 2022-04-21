using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    public class Item
    {
        //Define a class Item, which contains these properties: Name and Price.
        public string ItemName { get; set; }

        public double ItemPrice { get; set; }
                
    }
    public class Box 
    {

        //Define a class Box, which contains these properties: Serial Number, Item, Item Quantity, and Price for a Box.
        public string BoxSerialNumber { get; set; }

        public Item BoxItem { get; set; }

        public int BoxItemQty { get; set; }

        public double BoxPrice { get; set; }
    }   

    internal class Program
    {
        static void Main(string[] args)
        {
            //Until you receive "end", you will be receiving data in the following format: "{Serial Number} {Item Name} {Item Quantity} {itemPrice}"
            //The Price of one box has to be calculated: itemQuantity * itemPrice.
            //Print all the boxes, ordered descending by price for a box, in the following format: 
            //{ boxSerialNumber}
            //-- { boxItemName} – ${ boxItemPrice}: { boxItemQuantity}
            //-- ${ boxPrice}
            //The price should be formatted to the 2nd digit after the decimal separator.

            List<Box> storeBoxes = new List<Box>();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] arguments = command.Split();
 
                int itemQty = Convert.ToInt32(arguments[2]);
                double itemPrice = Convert.ToDouble(arguments[3]);
                double boxPrice = itemQty * itemPrice;

                Box boxes = new Box();
                Item items = new Item();

                items.ItemName = arguments[1];
                items.ItemPrice = itemPrice;
                boxes.BoxItem = items;
                boxes.BoxSerialNumber = arguments[0]; 
                boxes.BoxItemQty = itemQty;
                boxes.BoxPrice = boxPrice;
               
                storeBoxes.Add(boxes);

                command = Console.ReadLine();
            }

            foreach (Box stbox in storeBoxes.OrderByDescending(x => x.BoxPrice))
            {
                Console.WriteLine($"{stbox.BoxSerialNumber}\n-- {stbox.BoxItem.ItemName} - ${stbox.BoxItem.ItemPrice:F2}: {stbox.BoxItemQty}\n-- ${stbox.BoxPrice:F2}");
            }

        }

    }

}
