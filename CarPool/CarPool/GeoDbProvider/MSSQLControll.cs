using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using CarPool.Models;
using Microsoft.Extensions.Configuration;

namespace CarPool.GeoDbProvider
{
    public class MSSQL
    {
        SqlConnection cnn;

        public MSSQL()
        {

            //string ConnectionString = configuration.GetConnectionString("GeoDb");
            string ConnectionString = @"Server=tcp:dpkolarik.database.windows.net,1433;Initial Catalog=Geography;Persist Security Info=False;User ID=mkolarik;Password=Polav1994!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
        }

        public List<City> GetAllStreets()
        {
            List<City> cityFromDB = new List<City>();
            string commandText = (@"select City.Name as City, Street.Name as Street, City.Region as region from City
                                    inner join CityPart on CityPart.City_Id=City.Id
                                    inner join Street on Street.CityPart_Id =CityPart.Id
                                    ");
            SqlCommand command = new SqlCommand(commandText, cnn);

            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                cityFromDB.Add(new City { cityName = dataReader["City"].ToString(), regionName = dataReader["Region"].ToString(), streetName = dataReader["Street"].ToString() });
                //output += dataReader.GetValue(0) + " (Okres "+ dataReader["Region"].ToString() +")" + ";";
            }
            dataReader.Close();
            return cityFromDB;

        }

        public List<City> GetAllCity()
        {
            List<City> cityFromDB = new List<City>();
            string commandText = (@"Select * From City");
            SqlCommand command = new SqlCommand(commandText, cnn);

            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                cityFromDB.Add(new City { cityName = dataReader["Name"].ToString(), regionName = dataReader["Region"].ToString() });
                //output += dataReader.GetValue(0) + " (Okres "+ dataReader["Region"].ToString() +")" + ";";
            }
            dataReader.Close();
            return cityFromDB;

        }


        public List<City> FindCity(string city)
        {
            List<City> cityFromDB = new List<City>();

            string commandText = (@"SELECT TOP 4 City.Name,City.Region from City WHERE City.Name COLLATE Latin1_general_CI_AI Like '%'+@City+'%'
                                  UNION
                                  SELECT City.Name,City.Region from City WHERE City.Name COLLATE Latin1_general_CI_AI = @City
                                  ");
            SqlCommand command = new SqlCommand(commandText, cnn);
            command.Parameters.Add("City", SqlDbType.VarChar).Value = city;
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                cityFromDB.Add(new City { cityName = dataReader["Name"].ToString(), regionName = dataReader["Region"].ToString(), streetName = null });
                //output += dataReader.GetValue(0) + " (Okres "+ dataReader["Region"].ToString() +")" + ";";
            }
            dataReader.Close();
            return cityFromDB;

        }

        public List<School> FindAllSchools()
        {

            List<School> SchoolFromDB = new List<School>();

            string commandText = (@"Select Name,SohrtName from dbo.School ");

            SqlCommand command = new SqlCommand(commandText, cnn);


            SqlDataReader dataReader;
            // string output = "";
            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                SchoolFromDB.Add(new School { name = dataReader.GetValue(0).ToString(), shortName = dataReader.GetValue(1).ToString() });

                //SchoolFromDB.Add(new School { name = dataReader.GetValue(0).ToString(), shortName = dataReader.GetValue(1).ToString(), x = float.Parse( dataReader.GetValue(2).ToString()), y=float.Parse( dataReader.GetValue(3).ToString()) });
            }
            dataReader.Close();

            return SchoolFromDB;
        }


        public List<City> FindStreet(string street)
        {
            string commandText;
            List<City> cityFromDB = new List<City>();


            if (street.Split(' ').Length > 1)

                commandText = (@"SELECT DISTINCT TOP 5 City.Name as Mesto,Street.Name as Ulice from Street
                                 Inner JOIN CityPart on Street.CityPart_Id=CityPart.Id
                                 Inner JOIN City on CityPart.City_Id=City.Id
                                 WHERE City.Name+' '+Street.Name  COLLATE Latin1_general_CI_AI Like '%'+@Street+'%' OR
                                 Street.Name+' '+City.Name  COLLATE Latin1_general_CI_AI Like '%'+@Street+'%'");
            else
                commandText = (@"Select TOP 5 Mesto,Ulice from(
                                SELECT DISTINCT City.Name as Mesto,Street.Name as Ulice from Street
                                Inner JOIN CityPart on Street.CityPart_Id=CityPart.Id
                                Inner JOIN City on CityPart.City_Id=City.Id
                                WHERE City.Name+' '+Street.Name  COLLATE Latin1_general_CI_AI Like '%'+@Street+'%' OR
                                Street.Name+' '+City.Name  COLLATE Latin1_general_CI_AI Like '%'+@Street+'%') as tst
                                WHERE Ulice COLLATE Latin1_general_CI_AI like '%'+@Street+'%'
                                ");

            SqlCommand command = new SqlCommand(commandText, cnn);
            command.Parameters.Add("Street", SqlDbType.VarChar).Value = street;




            SqlDataReader dataReader;
            // string output = "";
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                cityFromDB.Add(new City { cityName = dataReader.GetValue(0).ToString(), streetName = dataReader.GetValue(1).ToString(), regionName = null });
                //output += dataReader.GetValue(0) + " " + dataReader.GetValue(1) + ";";
            }
            dataReader.Close();
            return cityFromDB;

        }

        public List<School> FindSchool(string school)
        {



            List<School> SchoolFromDB = new List<School>();

            string commandText = (@"Select TOP 5 Name,SohrtName  from dbo.School 
                                    where dbo.School.SohrtName COLLATE Latin1_general_CI_AI  like '%' + @School + '%'    
                                    or dbo.School.Name COLLATE Latin1_general_CI_AI  like '%' + @School + '%' ");

            SqlCommand command = new SqlCommand(commandText, cnn);
            command.Parameters.Add("School", SqlDbType.VarChar).Value = school;

            SqlDataReader dataReader;
            // string output = "";
            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                SchoolFromDB.Add(new School { name = dataReader.GetValue(0).ToString(), shortName = dataReader.GetValue(1).ToString() });

                //SchoolFromDB.Add(new School { name = dataReader.GetValue(0).ToString(), shortName = dataReader.GetValue(1).ToString(), x = float.Parse( dataReader.GetValue(2).ToString()), y=float.Parse( dataReader.GetValue(3).ToString()) });
            }
            dataReader.Close();

            return SchoolFromDB;
        }


        public void CloseConnection()
        {
            cnn.Close();
        }

        /*    public void CreateRoute(Route r)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string commandText = (@"INSERT INTO DP.dbo.Route (StartDestination,FinalDestination,Date,Seats)
                                      VALUES (@StartDestination,@FinalDestination,@Date,@Seats)");

                string tempDate = r.date + " " + r.time;
                DateTime dateTime = Convert.ToDateTime(tempDate);

                SqlCommand command = new SqlCommand(commandText, cnn);
                command.Parameters.AddWithValue("@StartDestination", r.startDest);
                command.Parameters.AddWithValue("@FinalDestination", r.finalDestination);
                command.Parameters.AddWithValue("@Date", dateTime);
                command.Parameters.AddWithValue("@Seats", r.seats);
                //command.Parameters.AddWithValue("@Time", r.time);
                command.ExecuteNonQuery();

                command.Dispose();

            }


            public List<Route> FindRoutes(Route r)
            {
                List<Route> routesFromDb = new List<Route>();


                string tempDate = r.date + " " + r.time;
                DateTime dateTime = Convert.ToDateTime(tempDate);
                string sqlFormattedDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string commandText = (@"SELECT * FROM dbo.Route WHERE StartDestination=@StartDestination AND FinalDestination=@FinalDestination 
                                      AND Seats>0 AND (Date between DATEADD(MI,-30,@Dates) AND DATEADD(MI,30,@Dates))");


                SqlCommand command = new SqlCommand(commandText, cnn);
                command.Parameters.AddWithValue("@StartDestination", r.startDest);
                command.Parameters.AddWithValue("@FinalDestination", r.finalDestination);
                command.Parameters.AddWithValue("@Dates", sqlFormattedDate);





                SqlDataReader dataReader;
                //  string output="";
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    dateTime = (DateTime)dataReader["Date"];
                    routesFromDb.Add(new Route
                    {
                        startDest = dataReader["StartDestination"].ToString(),
                        finalDestination = dataReader["FinalDestination"].ToString(),
                        seats = int.Parse(dataReader["Seats"].ToString()),
                        date = dateTime.ToString("dd.MM.yyyy"),
                        //time = dateTime.ToString("HH:mm")
                    });
                }
                dataReader.Close();
                return routesFromDb;

            }  */

    }
}
