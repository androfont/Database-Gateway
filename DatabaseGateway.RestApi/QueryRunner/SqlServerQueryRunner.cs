using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace DatabaseGateway.RestApi.QueryRunner
{
    public class SqlServerQueryRunner : IQueryRunner
    {
        public string ConnectionString { get; }

        public SqlServerQueryRunner(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<object> RunQuery(string commandText)
        {
            using var connection = new SqlConnection(ConnectionString);
            using var command = new SqlCommand(commandText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var result = new ExpandoObject() as IDictionary<string, object>;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        result.Add(reader.GetName(i), reader[i]);
                    }
                }

                yield return result;
            }
            reader.Close();
        }
    }
}
