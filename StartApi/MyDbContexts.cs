using Microsoft.EntityFrameworkCore;
// using StartApi.Modules.Items;
using System.Reflection;
namespace StartApi;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    //public DbSet<Items> Items { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var models = modelBuilder.Model.GetEntityTypes()
			.SelectMany(e => e.GetForeignKeys());
		foreach (var relationship in models)
		{
			relationship.DeleteBehavior = DeleteBehavior.NoAction;
		}

		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
    
}
public static class DatabaseInjection
{
	public static void AddDatabase(this IServiceCollection service)
	{
		var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION");
		dbConnection ??= "Host=localhost;Port=5432;Database= StartApi;Username=myuser;Password=mypassword;";
		service.AddDbContext<MyDbContext>(options => { options.UseNpgsql(dbConnection); });
	}
}