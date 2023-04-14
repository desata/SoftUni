using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{

    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private IBakedFood food;
        private IDrink drink;
        private ITable table;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }

            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);

            return $"Added {name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            return $"Added table number {tableNumber} in the bakery";
        }


        public string GetFreeTablesInfo()
        {
            List<string> freeTables = new List<string>();

            foreach (var table in tables)
            {
                if (!table.IsReserved)
                {
                    freeTables.Add(table.GetFreeTableInfo());
                }
                
            }

            return string.Join("\r\n", freeTables);
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {

            var tableForLeaving = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal finalBill = tableForLeaving.GetBill();
            finalBill += tableForLeaving.Price;
            totalIncome += finalBill;

            tableForLeaving.Clear();

            return $"Table: {tableNumber}\r\n" + $"Bill: {finalBill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var tableForOrder = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drinkForOrder = drinks.FirstOrDefault(f => f.Name == drinkName && f.Brand == drinkBrand);

            if (tableForOrder == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drinkForOrder == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            tableForOrder.OrderDrink(drinkForOrder);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var tableForOrder = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var foodForOrder = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (tableForOrder == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (foodForOrder == null)
            {
                return $"No {foodName} in the menu";
            }

            tableForOrder.OrderFood(foodForOrder);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var tableForReservation = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (tableForReservation == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            tableForReservation.Reserve(numberOfPeople);

            return $"Table {tableForReservation.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
