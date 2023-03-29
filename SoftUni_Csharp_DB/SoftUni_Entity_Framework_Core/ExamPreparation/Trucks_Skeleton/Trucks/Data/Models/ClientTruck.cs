namespace Trucks.Data.Models
{
    public class ClientTruck
    {

        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;

        public int TruckId { get; set; }

        public virtual Truck Truck { get; set; } = null!;
    }
}
