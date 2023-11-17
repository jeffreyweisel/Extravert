using System.Runtime.CompilerServices;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
    Species = "Flax",
    LightNeeds = 2,
    AskingPrice = 21.99M,
    City = "Nashville",
    ZIP = 12345,
    Sold = false,
    AvailableUntil = new DateTime(2023, 12, 11)
    },
    new Plant()
    {
    Species = "Astragalus jaegerianus",
    LightNeeds = 5,
    AskingPrice = 99.99M,
    City = "Memphis",
    ZIP = 43567,
    Sold = false,
    AvailableUntil = new DateTime(2023, 11, 23)
    },
    new Plant()
    {
    Species = "Allium munzii",
    LightNeeds = 1,
    AskingPrice = 144.00M,
    City = "Atlanta",
    ZIP = 27290,
    Sold = false,
    AvailableUntil = new DateTime(2023, 11, 20)
    },
    new Plant()
    {
    Species = "Brodiaea filifolia",
    LightNeeds = 5,
    AskingPrice = 149.99M,
    City = "Kansas City",
    ZIP = 54907,
    Sold = true,
    AvailableUntil = new DateTime(2023, 12, 2)
    },
    new Plant()
    {
    Species = "Dimorphandra wilsonii",
    LightNeeds = 3,
    AskingPrice = 199.99M,
    City = "Springfield",
    ZIP = 89102,
    Sold = false,
    AvailableUntil = new DateTime(2023, 11, 30)
    },
    new Plant()
    {
    Species = "Ficus elastica",
    LightNeeds = 3,
    AskingPrice = 24.99M,
    City = "San Francisco",
    ZIP = 12345,
    Sold = false,
    AvailableUntil = new DateTime(2023, 12, 20)
    },
    new Plant()
    {
    Species = "Monstera deliciosa",
    LightNeeds = 2,
    AskingPrice = 189.99M,
    City = "Seattle",
    ZIP = 90556,
    Sold = false,
    AvailableUntil = new DateTime(2023, 11, 25)
    },
    new Plant()
    {
    Species = "Spathiphyllum spp",
    LightNeeds = 3,
    AskingPrice = 144.00M,
    City = "Panama City",
    ZIP = 27290,
    Sold = true,
    AvailableUntil = new DateTime(2023, 11, 30)
    },
    new Plant()
    {
    Species = "Rosa spp",
    LightNeeds = 4,
    AskingPrice = 19.99M,
    City = "Chattanooga",
    ZIP = 54907,
    Sold = false,
    AvailableUntil = new DateTime(2023, 12, 25)
    },
    new Plant()
    {
    Species = "Lavandula spp",
    LightNeeds = 3,
    AskingPrice = 19.99M,
    City = "Dubai",
    ZIP = 89102,
    Sold = true,
    AvailableUntil = new DateTime(2023, 11, 12)
    }
};

Random random = new Random();
DateTime now = DateTime.Now;    //declaring now as DateTime type and setting it to current DateTime

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
5. Plant of the day
6. Search for plants based off of light needs
7. Statistics for plants 
");

    if (int.TryParse(Console.ReadLine(), out int userChoice))   //Tryparse converts string to number
    {                                                           // out keyword indicates the param is passed by reference and that it will be modified by the method
        Console.Clear();    //console clears every time user makes a choice

        switch (userChoice)      
        {

            case 0:
                Console.WriteLine("See ya!");
                Environment.Exit(0); //exits the entire application.
                break;

            case 1:
                ListPlants();
                break; ; //break exits the switch statement if case is matched

            case 2:
                PostPlantForAdoption();
                break;
            case 3:
                AdoptAPlant();
                break;
            case 4:
                RemovePlantFromList();
                break;

            case 5:
                PlantOfTheDay();
                break;

            case 6:
                SearchPlants();
                break;

            case 7:
                PlantStats();
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Enter a number between 0 and 7.");

    }
}

void ListPlants()
{
    Console.WriteLine("All The Plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        TimeSpan timeLeftInStock = plants[i].AvailableUntil - DateTime.Now;
        Console.WriteLine(@$"{i + 1}. {plants[i].Species} is in {plants[i].City} and {(plants[i].Sold ? "is not available." : $"is available for {plants[i].AskingPrice} dollars. It will be on shelves for another {(plants[i].Sold ? "" : $"{timeLeftInStock.Days}")} days.")}");
    }
}

void PostPlantForAdoption()
{
    Plant newPlant = new Plant();

    //Species
    Console.WriteLine("Species:");
    newPlant.Species = Console.ReadLine();

    //Light Needs
    Console.WriteLine("Light Needs (Scale of 1-5):");
    if (int.TryParse(Console.ReadLine(), out int LightNeeds))
    {
        newPlant.LightNeeds = LightNeeds;
    }
    //Asking Price
    Console.WriteLine("Asking Price:");
    if (decimal.TryParse(Console.ReadLine(), out decimal AskingPrice))
    {
        newPlant.AskingPrice = AskingPrice;
    }
    //City
    Console.WriteLine("City:");
    newPlant.City = Console.ReadLine();

    //Zip Code
    Console.WriteLine("Zip Code:");
    if (int.TryParse(Console.ReadLine(), out int ZIP))
    {
        newPlant.ZIP = ZIP;
    }

    //Available Until Date
    bool validInput = false;

    while (!validInput)
    {
        Console.WriteLine("Enter the last day available date (MM/DD/YYYY):");
        string response = Console.ReadLine();

        try
        {
            if (response.Length == 10)
            {
                DateTime AvailableUntil = DateTime.Parse(response);
                newPlant.AvailableUntil = AvailableUntil;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input playa. Use MM/DD/YYYY format.");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Invalid input playa. Enter date in the MM/DD/YYYY format.");
        }
    }


    newPlant.Sold = false;

    plants.Add(newPlant);
}

void AdoptAPlant()
{
    ListPlants();

    Plant chosenPlant = null;
    bool invalidChoice = true;  //boolean flag to break out of loop once criteria is met

    while (invalidChoice)
    {
        Console.WriteLine("Enter the plant you wish to adopt's unique single-digit identifier: ");

        try
        {
            int response = int.Parse(Console.ReadLine().Trim());

            chosenPlant = plants[response - 1];

            {

                if (chosenPlant.Sold)
                {
                    Console.WriteLine("Plant already sold. Choose another option.");
                }
                else
                {
                    chosenPlant.Sold = true;
                    Console.WriteLine($"Congrats! You just adopted a {chosenPlant.Species}.");
                    invalidChoice = false;
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }
}

void RemovePlantFromList()
{
    ListPlants();

    Plant gettingDeleted = null;

    while (gettingDeleted == null)
    {
        Console.WriteLine("Enter the plant you wish to deletes unique single digit identifer:");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            gettingDeleted = plants[response - 1];

            plants.RemoveAt(response - 1);

            Console.WriteLine("Plant has been deleted successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing plant only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
}

void PlantOfTheDay()
{
    Console.WriteLine("Randomly generated plant of the day:");

    List<Plant> availablePlants = plants.Where(plant => !plant.Sold).ToList();  //Where is similar to filter in js

    if (availablePlants.Count > 0)
    {
        int randomPlantIndex = random.Next(plants.Count);   //generating a random plant based off their index #
        Plant randomPlant = availablePlants[randomPlantIndex];

        Console.WriteLine(PlantString(randomPlant));
    }


}

void SearchPlants()
{
    Console.WriteLine("Enter Maximum Light Needs:");

    int userInput = int.Parse(Console.ReadLine().Trim());

    List<Plant> plantSunlight = new List<Plant>();

    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= userInput)
        {
            plantSunlight.Add(plant);

            Console.WriteLine(PlantString(plant));
        }
    }

}

void PlantStats()
{
    Plant leastExpensive = plants[0];
    Plant mostLightNeeded = plants[0];
    int plantsAvailable = 0;
    int averageLightNeeded = 0;
    int plantsAdopted = 0;
    int plantLightNeedsTotal = 0;

    // Least expensive plant
    foreach (Plant plant in plants)
    {
        if (plant.AskingPrice < leastExpensive.AskingPrice)
        {
            leastExpensive = plant;
        }
    }

    // Plant that needs the most sunlight
    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds < mostLightNeeded.LightNeeds)
        {
            mostLightNeeded = plant;
        }
    }

    //Number of plants that are available
    foreach (Plant plant in plants)
    {
        if (!plant.Sold)
        {
            plantsAvailable++;
        }
    }

    // Percentage of plants that have been sold
    foreach (Plant plant in plants)
    {
        if (plant.Sold)
        {
            plantsAdopted++;
        }
    }

    decimal percentageSold = (decimal)plantsAdopted / plants.Count;

    // Average sunlight needed for all plants 
    foreach (Plant plant in plants)
    {
        plantLightNeedsTotal += plant.LightNeeds;
    }

    decimal AvgLightNeeds = (decimal)plantLightNeedsTotal / plants.Count;


    Console.WriteLine(@$"
    The plant with lowest price is the {leastExpensive.Species}
    The total number of available (not sold) plants is {plantsAvailable}
    The plant with the highest light need is {mostLightNeeded.Species}
    The average of all plants light needs is {AvgLightNeeds}
    The total percentage of plants that have been adopted is {percentageSold}");

}

string PlantString(Plant plant)
{
    TimeSpan timeLeftInStock = plant.AvailableUntil - DateTime.Now;
    string plantString = $"{plant.Species} is in {plant.City} and {(plant.Sold ? "is not available." : "is available")} for ${plant.AskingPrice}. It will be on shelves for another {(plant.Sold ? "" : $"{timeLeftInStock.Days}")} days.";

    return plantString;
}
