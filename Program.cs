using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using NileshWebApi;
using NileshWebApi.Filters;
using NileshWebApi.Models;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

/// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ActionClass());
})
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configure the DbContext
builder.Services.AddDbContext<ExamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<EmailService>();
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder =>
        {
            //policyBuilder.WithOrigins("http://localhost:3001") // React app origin
            //             .AllowAnyHeader()
            //             .AllowAnyMethod();

            policyBuilder.AllowAnyOrigin() // Allow React app
                 .AllowAnyMethod() // Allow GET, POST, PUT, DELETE
                 .AllowAnyHeader(); // Allow all headers
        });

   
});
// Add Azure AD authentication for JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
