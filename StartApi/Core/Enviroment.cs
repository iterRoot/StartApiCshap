namespace DesProjectApi.Core;

public static class MyEnvironment
{
    // public static string GetName()
    // {
    //     var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    //     return env switch
    //     {
    //         "Production" => "prod",
    //         "Uat" => "uat",
    //         _ => "dev"
    //     };
    // }

    public static string DbConnection => Environment.GetEnvironmentVariable("DB_CONNECTION") ??
                                         "Host=localhost;Port=5432;Database= StartApi;Username=myuser;Password=mypassword;";

    // public static string JwtIssuer => Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "https://dev.eventhub.one";

    // public static string JwtAudience => Environment.GetEnvironmentVariable("JWT_AUDIENCE") ??
    //                                     "https://dev.eventhub.one";

    // public static string JwtKey => Environment.GetEnvironmentVariable("JWT_KEY") ??
    //                                "ra8FXsc1Xv6FjN8cuxMDYcKeP4aQ4XRmKZyGnyhLRhuJ";

    // public static double JwtExpired => double.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRED") ?? "1904198888");
}