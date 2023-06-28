using Microsoft.Data.SqlClient;
using System.Data;

namespace GrupoTranspaisDanielTorres
{
    internal class Conexion
    {
        //TODO Cambiar la cadena de conexion
        //private const string CONNECTION_STRING = "Integrated Security=SSPI;Initial Catalog=GrupoTranspaisDaniel;Data Source=DANIEL-PC;TrustServerCertificate=True;";
        private const string CONNECTION_STRING = "";
        public Conexion() { }

        private static SqlConnection Connect()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONNECTION_STRING;
            con.Open();
            con.Close();
            return con;            
        }

        public static void InsertarPersona(Persona persona)
        {            
            SqlParameter[] parameters = new SqlParameter[]
            {                
                new SqlParameter(){ ParameterName="@nombre", SqlDbType= System.Data.SqlDbType.NVarChar, Value = persona.Nombre },
                new SqlParameter() { ParameterName="@apellido", SqlDbType= System.Data.SqlDbType.NVarChar, Value = persona.Apellido },
                new SqlParameter() { ParameterName = "@edad", SqlDbType = System.Data.SqlDbType.Int, Value = persona.Edad }
            };            
            ExecuteTransaction("sp_Insertar", parameters);
        }

        public static DataTable GetPersona(int id)
        {
            string query = "SELECT id, nombre, apellido, edad FROM persona WHERE id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter { ParameterName="@id", SqlDbType = System.Data.SqlDbType.Int, Value = id } 
            };

            //SqlParameter parameter = new SqlParameter() { ParameterName="@id", SqlDbType = System.Data.SqlDbType.Int, Value = id };
            DataTable dt = ExecuteQuery(query, parameters);
            return dt;
        }

        private static void ExecuteTransaction(string procedureName, Microsoft.Data.SqlClient.SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = Connect();
                con.Open();
                using (var command = new SqlCommand(procedureName, con))
                {
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }                    

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            con.Dispose();
        }

        private static DataTable ExecuteQuery(string query, Microsoft.Data.SqlClient.SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection();
            //SqlDataReader reader;
            SqlDataAdapter adapter;
            DataTable dt = new DataTable();
            try
            {
                con = Connect();
                con.Open();
                using (var command = new SqlCommand(query, con))
                {
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            con.Dispose();
            return dt;
        }
    }
}
