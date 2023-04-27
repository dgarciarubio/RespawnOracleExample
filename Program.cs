using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Respawn;
using RespawnOracleExample;

var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=Respawn1)));User Id=test_user;Password=some-password";
using var dbContext = new AppDbContext(connectionString);
using var dbConnection = new OracleConnection(connectionString);
await dbConnection.OpenAsync();
var respawner = await Respawner.CreateAsync(dbConnection, new RespawnerOptions
{
    DbAdapter = DbAdapter.Oracle,
});
await dbContext.Database.MigrateAsync();
dbContext.Entities.Add(new Entity
{
   Name = "An Entity Name",
});
await dbContext.SaveChangesAsync();
await respawner.ResetAsync(dbConnection);