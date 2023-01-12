using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Core.Contracts
{
    public class Controller : IController
    {
        public string AddBooth(int capacity)
        {
            throw new NotImplementedException();
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            throw new NotImplementedException();
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            throw new NotImplementedException();
        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string ReserveBooth(int countOfPeople)
        {
            throw new NotImplementedException();
        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }
    }
}
