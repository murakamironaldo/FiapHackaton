using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Serilog;
using Serilog.Sinks.MariaDB;
using Serilog.Sinks.MariaDB.Extensions;
using Sistema.API.endpoints.configuracoes;
using Sistema.API.endpoints.security;
using Sistema.API.endpoints.usuarioperfis;
using Sistema.API.endpoints.usuarios;
using Sistema.Infra.Database;
using Sistema.IOCWrapper;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


Startup.Bootstrap(builder.Services);


builder.Services.AddCors(options =>
{

    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});



builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
    options.AddPolicy("EmployeePolicy", p =>
        p.RequireAuthenticatedUser().RequireClaim("EmployeeCode"));
    options.AddPolicy("CpfPolicy", p =>
        p.RequireAuthenticatedUser().RequireClaim("Cpf"));
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtBearerTokenSettings:SecretKey"]))
    };
});







builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sistema Odoias",
        Description = "API do sistema",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }

    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .WriteTo.Console()
        .WriteTo.MariaDB(
            context.Configuration["ConnectionStrings:DefaultConnection"], 
            tableName: "Logs",
            autoCreateTable: true,
            useBulkInsert: false,
            options: new MariaDBSinkOptions()
            );

});


builder.Services.AddDbContext<SistemaDbContext>(options =>
{
    options.UseMySql(builder.Configuration["ConnectionStrings:DefaultConnection"], new MySqlServerVersion(new Version(8, 0, 25)));
});






var app = builder.Build();
app.UseCors("default");
app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#region Autenticacao
app.MapMethods(AutenticacaoPost.Template, AutenticacaoPost.Methods, AutenticacaoPost.Handle);
#endregion

#region Usuarios
app.MapMethods(UsuarioCarregar.Template, UsuarioCarregar.Methods, UsuarioCarregar.Handle);
app.MapMethods(UsuarioListar.Template, UsuarioListar.Methods, UsuarioListar.Handle);
app.MapMethods(UsuarioExcluir.Template, UsuarioExcluir.Methods, UsuarioExcluir.Handle);


#region UsuarioPerfis
app.MapMethods(UsuarioPerfisListar.Template, UsuarioPerfisListar.Methods, UsuarioPerfisListar.Handle);

#endregion

#endregion


#region Configuracoes
app.MapMethods(ConfiguracaoListar.Template, ConfiguracaoListar.Methods, ConfiguracaoListar.Handle);
app.MapMethods(ConfiguracaoCarregar.Template, ConfiguracaoCarregar.Methods, ConfiguracaoCarregar.Handle);
app.MapMethods(ConfiguracaoAlterar.Template, ConfiguracaoAlterar.Methods, ConfiguracaoAlterar.Handle);


#endregion

//Configuracoes

//Fim Configuracoes




app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext http) =>
{

    var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;

    if (error != null)
    {
        if (error is MySqlException)
            return Results.Problem(title: "Database out", statusCode: 500);
        else if (error is BadHttpRequestException)
            return Results.Problem(title: "Error to convert data to other type. See all the information sent", statusCode: 500);
    }

    return Results.Problem(title: "An error ocurred", statusCode: 500);
});



app.Run();

