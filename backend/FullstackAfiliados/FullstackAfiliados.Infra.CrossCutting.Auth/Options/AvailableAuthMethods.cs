using System.ComponentModel;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Options;

public enum AvailableAuthMethods
{
    [Description("JwtToken")]
    JwtToken
}