using System.Runtime.CompilerServices;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
    Species = "Flax",
    LightNeeds = 2,
    AskingPrice = 21.99M,
    City = "Wakanda",
    ZIP = 12345,
    Sold = false
    },
    new Plant()
    {
    Species = "Astragalus jaegerianus",
    LightNeeds = 5,
    AskingPrice = 1000.55M,
    City = "Narnia",
    ZIP = 43567,
    Sold = false
    },
    new Plant()
    {
    Species = "Allium munzii",
    LightNeeds = 1,
    AskingPrice = 10344.00M,
    City = "Atlantis",
    ZIP = 27290,
    Sold = false
    },
    new Plant()
    {
    Species = "Brodiaea filifolia",
    LightNeeds = 5,
    AskingPrice = 1499.99M,
    City = "Kansas City",
    ZIP = 54907,
    Sold = true
    },
    new Plant()
    {
    Species = "Dimorphandra wilsonii",
    LightNeeds = 3,
    AskingPrice = 199.99M,
    City = "Springfield",
    ZIP = 89102,
    Sold = false
    }
};

string greeting = @"Welcome to Extravert
Your one-stop shop for all things plant related";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
0. Exit
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. Delist a plant
");

    if (int.TryParse(Console.ReadLine(), out int userChoice))   //Tryparse converts string to number
    {                                                           // out keyword indicates the param is passed by reference and that it will be modified by the method
        Console.Clear();    //console clears every time user makes a choice

        switch (userChoice)      //using switch statement instead of try catch
        {

            case 0:
                Console.WriteLine("Adios Bradda!");
                Environment.Exit(0); // This exits the entire application.
                break;  //return exits the program

            case 1:
                ListPlants();
                break; ; //break exits the switch statement if case is matched

            case 2:
                PostPlantForAdoption();
                break;
            case 3:
                throw new NotImplementedException("Display all plants");

            case 4:
                throw new NotImplementedException("Display all plants");

            case 5:
                throw new NotImplementedException("Display all plants");

        }
    }
    else
    {
        Console.WriteLine("That is not a valid input. Please enter a number between 0 and 5.");

    }
}

void ListPlants()
{
    Console.WriteLine("All The Plants:");
    foreach (Plant plant in plants)
    {
        Console.WriteLine(@$" 
        {plant.Species} is in {plant.City} and {(plant.Sold ? "is not available." : $"is available for {plant.AskingPrice} dollars.")}");
    }
}

void PostPlantForAdoption()
{
    // List<Plant> plants =  List <Plant>();
    
    Plant newPlant = new Plant();

    //properties of the plant
    Console.WriteLine("Enter Species:");
    newPlant.Species = Console.ReadLine();

    Console.WriteLine("Enter Light Needs:");
    if (int.TryParse(Console.ReadLine(), out int LightNeeds))
    {
        newPlant.LightNeeds = LightNeeds;
    }
    Console.WriteLine("Enter Asking Price:");
    if (decimal.TryParse(Console.ReadLine(), out decimal AskingPrice))
    {
        newPlant.AskingPrice = AskingPrice;
    }
    Console.WriteLine("Enter City:");
    newPlant.City = Console.ReadLine();

    Console.WriteLine("Enter Zip Code:");
    if (int.TryParse(Console.ReadLine(), out int ZIP))
    {
        newPlant.ZIP = ZIP;
    }

    // Console.WriteLine("Sold? :");
    newPlant.Sold = false;

    plants.Add(newPlant);
}

