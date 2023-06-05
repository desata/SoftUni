using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        //  private DelicacyRepository delicasies;
        //  private CocktailRepository cocktails;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;

            IBooth boot = new Booth(boothId, capacity);
            booths.AddModel(boot);
            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            ICocktail cocktail;

            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }
            if (booths.Models.Any(b => b.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size)))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }
            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicasy;
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            if (delicacyTypeName != "Stolen" && delicacyTypeName != "Gingerbread")
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }
            if (booths.Models.Any(b => b.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            if (delicacyTypeName == "Stolen")
            {
                delicasy = new Stolen(delicacyName);
            }
            else
            {
                delicasy = new Gingerbread(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicasy);
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";

        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.Charge();
            booth.ChangeStatus();

            return $"Bill {booth.Turnover:f2} lv\nBooth {boothId} is now available!";

        }

        public string ReserveBooth(int countOfPeople)
        {

            var freeBooth = booths.Models.OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).FirstOrDefault(b => b.IsReserved == false && b.Capacity >= countOfPeople);       

            if (freeBooth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            freeBooth.ChangeStatus();
            return $"Booth {freeBooth.BoothId} has been reserved for {countOfPeople} people!";

        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            List<string> itemTypes = new List<string>() { "Stolen", "Gingerbread", "Hibernation", "MulledWine" };

            string itemTypeName = order.Split('/')[0];
            string itemName = order.Split("/")[1];
            int pieces = int.Parse(order.Split("/")[2]);

            if (!itemTypes.Contains(itemTypeName))
            {
                return $"{itemTypeName} is not recognized type!";
            }
            if ((!booth.DelicacyMenu.Models.Any(d => d.Name == itemName)) && (!booth.CocktailMenu.Models.Any(d => d.Name == itemName)))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            //Cocktail
            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string size = order.Split("/")[3];
                ICocktail coctail = booth.CocktailMenu.Models.FirstOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName && d.Size == size);

                if (coctail == null)
                {
                    return $"There is no {size} {itemName} available!";
                }

                double amount = coctail.Price * pieces;
                booth.UpdateCurrentBill(amount);

                
            }
            //Delicasy
            if (itemTypeName == "Stolen" || itemTypeName == "Gingerbread")
            {
                
                IDelicacy delicasy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName);

                if (delicasy == null)
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                double amount = delicasy.Price * pieces;
                booth.UpdateCurrentBill(amount);

                
            }

            return $"Booth {boothId} ordered {pieces} {itemName}!";

        }
    }
}
