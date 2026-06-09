using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/alisher_kunbolsyn_gmail_com", (string? x, string? y) =>
{
    if (!BigInteger.TryParse(x, out var a) ||
        !BigInteger.TryParse(y, out var b) ||
        a < 0 || b < 0)
    {
        return Results.Text("NaN", "text/plain");
    }

    if (a == 0 || b == 0)
        return Results.Text("0", "text/plain");

    var lcm = BigInteger.Abs(a * b) / Gcd(a, b);
    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();

static BigInteger Gcd(BigInteger a, BigInteger b)
{
    while (b != 0)
        (a, b) = (b, a % b);

    return BigInteger.Abs(a);
}