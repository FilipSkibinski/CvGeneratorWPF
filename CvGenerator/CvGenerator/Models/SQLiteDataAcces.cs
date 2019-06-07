using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace CvGenerator.Models
{
    class SQLiteDataAcces
    {

        public static List<PersonModel> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("select * from Person", new DynamicParameters());
                return output.ToList();

            }
        }

        public static void SavePerson(PersonModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Person (Name, Surname, City, Country, PhoneNumber, Email, Date, School, Experience, Skills) " +
                    "values (@Name, @Surname, @City, @Country, @PhoneNumber, @Email, @Date, @School, @Experience, @Skills)", person);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
