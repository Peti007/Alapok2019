using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06AdoNet.DataAccess
{
    public class DataAccessLayer
    {
        private readonly string connectionString;

        public DataAccessLayer(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Missing connectionString", nameof(connectionString));
            }

            this.connectionString = connectionString;
        }
        public Teacher TeacherRead(int id)
        {
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT [Id],[Name] FROM [CodeFirstDB].[dbo].[Teacher] WHERE [Id] = @Id";

                    var param = cmd.CreateParameter();
                    param.DbType = System.Data.DbType.Int32;
                    param.Direction = System.Data.ParameterDirection.Input;
                    param.ParameterName = "@Id";
                    param.Value = id;

                    cmd.Parameters.Add(param);

                    //lefuttatjuk a parancsot úgy, hogy a visszakapott eredményhalmazt olvasni tudjuk
                   var reader =  cmd.ExecuteReader();

                    if (!reader.Read())
                    {// nem sikerült olvasni, nincs ilyen azonosítójú rekord, visszatérünk null-lal
                        return null;
                    }

                    var teacher = new Teacher()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        TeacherName = reader.GetString(reader.GetOrdinal("Name"))
                    };

                    return teacher;
                    
                }
            }
        }

        public int TeacherCreate(Teacher teacher)
        {
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO [dbo].[Teacher] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY() as ID";

                    cmd.Parameters
                        .Add("@Name", SqlDbType.NVarChar, -1)
                        .Value = teacher.TeacherName;

                    var reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        return 0;
                    }

                    //a 2. lekérdezés 1 oszlopos, így a 0-s indexű oszlopra van szükségünk
                    //a SCOPE_INDENTITY() numeric(18,0) értékkel tér vissza, ami "nem fér bele" az int32-be
                    //így betöltjük decimálisként
                    var id = (int)reader.GetDecimal(0);
                    return id;

                }
            }
        }
    }
}
