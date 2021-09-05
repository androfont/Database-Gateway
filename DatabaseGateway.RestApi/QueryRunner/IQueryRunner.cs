using System.Collections.Generic;

namespace DatabaseGateway.RestApi.QueryRunner
{
    public interface IQueryRunner
    {
        string ConnectionString { get; }

        IEnumerable<object> RunQuery(string commandText);
    }
}
