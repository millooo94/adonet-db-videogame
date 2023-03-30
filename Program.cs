using adonet_db_videogame;
using System.Data.SqlClient;

var connStr = "Data Source=localhost;Initial Catalog=dbVideogames;Integrated Security=True";

var manager = new VideogameManager(connStr);

//manager.AddVideogame("okok", "okok", new DateTime(2023, 12, 24), 5);

while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Inserisci un nuovo videogioco");
    Console.WriteLine("2. Ricerca un videogioco per id");
    Console.WriteLine("3. Ricerca tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input");
    Console.WriteLine("4. Cancella un videogioco");
    Console.WriteLine("5. Chiudi il programma");

    var choice = Console.ReadLine();


    switch (choice)
    {
        case "1":
            Console.Write("Enter the name of the videogame: ");
            var name = Console.ReadLine();
            Console.Write("Enter the overview of the videogame: ");
            var overview = Console.ReadLine();
            Console.Write("Enter the release date of the videogame (yyyy-mm-dd): ");
            var releaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter ID of the software house: ");
            var softwareHouseId = Convert.ToInt64(Console.ReadLine());
            var videogame = new VideogameInsert(name, overview, releaseDate, softwareHouseId);
            manager.AddVideogame(videogame);
            Console.WriteLine("Videogioco inserito con successo!");
            Console.WriteLine(videogame);
            break;

        case "2":
            Console.Write("Insert the ID of the videogame: ");
            var id = Convert.ToInt64(Console.ReadLine());
            var videogameSearchedById = manager.GetVideogamebyId(id);
            Console.WriteLine(videogameSearchedById);
            break;

        case "3":
            Console.WriteLine("Search a videogame by name:");
            var nameQuery = Console.ReadLine();
            var videogamesSearchedByName = manager.GetVideogamesByNameLike(nameQuery);
            foreach (VideogameSelect item in videogamesSearchedByName)
            {
                Console.WriteLine(item);
            }
            break;

        case "4":
            Console.WriteLine("Delete a videogame by name:");
            var nameForDelete = Console.ReadLine();
            manager.DeleteVideoGameByName(nameForDelete);
            break;

        default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
}



