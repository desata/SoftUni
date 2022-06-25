namespace Zoo
{
    public class Animal
    {
 
        public Animal(string species, string diet, double weight, double length)
        {
            Species = species;
            Diet = diet;
            Weigth = weight;
            Length = length;
        }


        public string Species { get; set; }

        public string Diet { get; set; }

        public double Weigth { get; set; }
        
        public double Length { get; set; }


        //Override ToString() method: "The {animal specie} is a {diet} and weighs {weight} kg."

        public override string ToString()
        {
            return $"The {Species} is a {Diet} and weighs {Weigth} kg.";
        }

    }
}
