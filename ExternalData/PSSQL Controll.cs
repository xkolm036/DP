using System;
using System.Data;
using Data.Models;
using Npgsql;
using System.Collections.Generic;


namespace Data

{
    public class PSSQLControll
    {
        NpgsqlConnection conn;

        public PSSQLControll()
        {
            string connetctionString = "Host=localhost;Username=postgres;Password=polav1994;Database=Geography";
            conn  = new NpgsqlConnection(connetctionString);
            conn.Open();
        }

        public List<City> FindCity(string city)
        {
            List<City> cityFromDB = new List<City>();

            //   var conn = new NpgsqlConnection(connetctionString);
            // conn.Open();

            //ok
            var cmd = new NpgsqlCommand("SELECT name,region from City WHERE LOWER(unaccent(City.Name)) iLike unaccent(@City) " +
                                        "Limit 4", conn);
            cmd.Parameters.AddWithValue("City", "%" + city + "%");

            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cityFromDB.Add(new City { cityName = reader.GetString(0), regionName = reader.GetString(1), streetName = null });

            reader.Close();

            return cityFromDB;
        }




        public List<City> FindStreet(string street)
        {

            List<City> cityFromDB = new List<City>();
            NpgsqlCommand cmd;

            if (street.Split(' ').Length > 1)
            {

                cmd = new NpgsqlCommand("SELECT DISTINCT  City.Name as Mesto,Street.Name as Ulice from Street "+
                                          "  inner JOIN CityPart on street.citypart_id = citypart.Id "+
                                          "  Inner JOIN City on CityPart.City_Id = City.Id "+
                                          "  WHERE LOWER(unaccent(City.Name)) || ' ' || LOWER(unaccent(Street.Name)) iLike unaccent(@Street) " +
                                          "  OR LOWER(unaccent(Street.Name)) || ' ' || LOWER(unaccent(City.Name)) iLike unaccent(@Street) " +
                                          "  limit 5", conn);
                cmd.Parameters.AddWithValue("Street", "%" + street + "%");
            }
            else
            {
                cmd = new NpgsqlCommand("Select Mesto,Ulice from(" +
                     " SELECT DISTINCT City.Name as Mesto,Street.Name as Ulice from Street" +
                     " Inner JOIN CityPart on Street.CityPart_Id=CityPart.Id" +
                     " Inner JOIN City on CityPart.City_Id=City.Id" +
                     " WHERE unaccent(City.Name)||' '|| unaccent(Street.Name) iLike unaccent(@Street) OR" +
                     " unaccent(Street.Name) ||' '||unaccent(City.Name) ilike unaccent( @Street)) as tst" +
                     " WHERE unaccent (Ulice) ilike unaccent( @Street)" +
                     " limit 5 ", conn);

            }


            cmd.Parameters.AddWithValue("Street", "%" + street + "%");
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                cityFromDB.Add(new City { cityName = reader.GetString(0), streetName = reader.GetString(1), regionName = null });

            reader.Close();



            return cityFromDB;

        }

        public List<School> FindSchool(string school)
        {


            NpgsqlCommand cmd;
            List<School> SchoolFromDB = new List<School>();

            cmd = new NpgsqlCommand("Select Name,ShortName  from School"+
                      " where  lower(unaccent(shortname))  ilike unaccent(@School)" +
                      " or lower(unaccent(name))  ilike  unaccent(@School)" +
                      " Limit 5", conn);
            cmd.Parameters.AddWithValue("School", "%" + school + "%");

            var reader = cmd.ExecuteReader();
            while (reader.Read())
                SchoolFromDB.Add(new School { name = reader.GetString(0), shortName = reader.GetString(1) });

            reader.Close();


            return SchoolFromDB;
        }


        public void CloseConnection()
        {
            conn.Close();
        }

        public void CreateRoute(Route r)
        {
            NpgsqlCommand cmd;


            cmd = new NpgsqlCommand("INSERT INTO route (StartDestination,FinalDestination,Date,Seats)" +
                        "VALUES (@StartDestination,@FinalDestination,@Date,@Seats)", conn);

            string tempDate = r.date + " " + r.time;
            DateTime dateTime = Convert.ToDateTime(tempDate);

            cmd.Parameters.AddWithValue("StartDestination", r.startDest);
            cmd.Parameters.AddWithValue("FinalDestination", r.finalDestination);
            cmd.Parameters.AddWithValue("Date", dateTime);
            cmd.Parameters.AddWithValue("Seats", r.Seats);

            cmd.ExecuteNonQuery();
        }


        public List<Route> FindRoutes(Route r)
        {
            NpgsqlCommand cmd;
            List<Route> routesFromDb = new List<Route>();


            string tempDate = r.date + " " + r.time;
            DateTime dateTime = Convert.ToDateTime(tempDate);
            string sqlFormattedDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            cmd = new NpgsqlCommand("SELECT * FROM dbo.Route WHERE StartDestination=@StartDestination AND FinalDestination=@FinalDestination " +
                       " AND Seats>0 AND (Date between INTERVAL '-30 MI' +@Dates AND INTERVAL '30 MI' +@Dates)", conn);

            cmd.Parameters.AddWithValue("StartDestination", r.startDest);
            cmd.Parameters.AddWithValue("FinalDestination", r.finalDestination);
            cmd.Parameters.AddWithValue("Dates", sqlFormattedDate);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                dateTime = (DateTime)reader.GetValue(reader.GetOrdinal("Date"));
                routesFromDb.Add(new Route
                {

                    startDest = reader.GetValue(reader.GetOrdinal("StartDestination")).ToString(),
                    finalDestination = reader.GetValue(reader.GetOrdinal("StartDestination")).ToString(),
                    Seats = int.Parse(reader.GetValue(reader.GetOrdinal("Seats")).ToString()),
                    date = dateTime.ToString("dd.MM.yyyy"),
                    time = dateTime.ToString("HH:mm")
                });
            }
            reader.Close();
            return routesFromDb;




        }
    }
}
