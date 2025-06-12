using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Sala_Reuniao_API.Auth
{
    public static class JwtAuthExtension
    {
        public static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettingsSection = configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            services.AddSingleton(jwtSettings);

            var chave = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {

                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        //ValidIssuer = "SalaReuniaoAPI",

                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,
                        //ValidAudience = "SalaReuniaoAPIUser",

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(chave),

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero

                    };
                });

            return services;
        }                
    }
}
