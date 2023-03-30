using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace adonet_db_videogame
{
    public record Videogame
    {

        public Videogame(long id, string name, string overview, DateOnly release_date, long software_house_id)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = release_date;
            SoftwareHouseID = software_house_id;
        }


        public long Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public long SoftwareHouseID { get; set; }

    }
}
