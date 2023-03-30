using adonet_db_videogame;
using System.Data.SqlClient;

var connStr = "Data Source=localhost;Initial Catalog=dbVideogames;Integrated Security=True";

var manager = new VideogameManager(connStr);

DateOnly dateOnlyValue = DateOnly.Today;

manager.AddVideogame("okok", "okok", dateOnlyValue, 5);