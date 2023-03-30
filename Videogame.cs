using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace adonet_db_videogame
{
    public record VideogameSelect
    {

        public VideogameSelect(long id, string name, string overview, DateTime release_date, long software_house_id)
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
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseID { get; set; }

    }

    public record VideogameInsert
    {

        public VideogameInsert(string name, string overview, DateTime release_date, long software_house_id)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = release_date;
            SoftwareHouseID = software_house_id;
        }

        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseID { get; set; }

    }
}
