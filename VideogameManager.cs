using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    public class VideogameManager
    {
        string connStr;

        public VideogameManager(string connStr)
        {
            this.connStr = connStr;
        }

        public void AddVideogame(VideogameInsert videogame)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "INSERT INTO videogames (name, overview, release_date, software_house_id)" +
                            "VALUES (@Name, @Overview, @ReleaseDate, @SoftwareHouseId)";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", videogame.Name);
                cmd.Parameters.AddWithValue("@Overview", videogame.Overview);
                cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                cmd.Parameters.AddWithValue("@SoftwareHouseId", videogame.SoftwareHouseID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("The videogame was successfully stored");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public VideogameSelect? GetVideogamebyId(long id)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "SELECT videogames.id, videogames.name, videogames.overview, videogames.release_date, videogames.software_house_id" +
                            " FROM videogames" +
                            " WHERE videogames.id = @id";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var _id = reader.GetInt64(0);
                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(1);
                    var overviewIdx = reader.GetOrdinal("overview");
                    var overview = reader.GetString(2);
                    var releaseDateIdx = reader.GetOrdinal("release_date");
                    var release_date = reader.GetDateTime(3);
                    var softwareHouseIdIdx = reader.GetOrdinal("software_house_id");
                    var software_house_id = reader.GetInt64(4);

                    var videogame = new VideogameSelect(_id, name, overview, release_date, software_house_id);

                    return videogame;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public List<VideogameSelect> GetVideogamesByNameLike (string likeString)
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<VideogameSelect>();

            try
            {
                conn.Open();
                var query = "SELECT videogames.id, videogames.name, videogames.overview, videogames.release_date" +
                            " FROM videogames" +
                           $" WHERE videogames.name = @NameLike";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NameLike", $"%{likeString}%");

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var id = reader.GetInt64(0);
                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(1);
                    var overviewIdx = reader.GetOrdinal("overview");
                    var overview = reader.GetString(2);
                    var releaseDateIdx = reader.GetOrdinal("release_date");
                    var release_date = reader.GetDateTime(3);
                    var softwareHouseIdIdx = reader.GetOrdinal("software_house_id");
                    var software_house_id = reader.GetInt64(4);

                    var videogame = new VideogameSelect(id, name, overview, release_date, software_house_id);
                    videogames.Add(videogame);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return videogames;
        }
        
        public void DeleteVideoGameByName(string name)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "DELETE FROM videogames " +
                            "WHERE videogames.name = @Name";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.ExecuteNonQuery();
                Console.WriteLine("The videogame was successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
