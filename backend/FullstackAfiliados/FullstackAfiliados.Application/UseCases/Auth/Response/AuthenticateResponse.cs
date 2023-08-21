namespace FullstackAfiliados.Application.UseCases.Auth.Response;
public class AuthenticateResponse
{
    public string Name { get; set; }
    public DateTime ExpiresIn { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(string name, string token)
    {
        Name = name;
        Token = token;
        ExpiresIn = new DateTime().AddHours(1);
    }
}