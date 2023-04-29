using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OvetimePolicies_Core.Dtos;
using System.Data;

namespace OvetimePolicies_Data.Repositories;

public class QueryRepository : IQueryRepository
{

    private readonly IConfiguration _config;
    private string Connectionstring = "myAppcs";
    private readonly IDbConnection db;

    public QueryRepository(IConfiguration config)
    {
        _config = config;
         db = new SqlConnection(_config.GetConnectionString(Connectionstring));
    }

    public async Task<PersonDto> GetById(Guid id)
    {
        var query = "Select * from [Person] where Id = {Id}";

        return (await db.QueryAsync<PersonDto>(query)).FirstOrDefault();

    }

    public async Task<List<PersonDto>> GetAll()
    {
        var query = "Select * from [Person]";

        return (await db.QueryAsync<PersonDto>(query)).ToList();
    }
}
