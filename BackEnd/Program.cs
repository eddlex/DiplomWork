using BackEnd.Services.Configuration;
using BackEnd.Services.Db;
using BackEnd.Services.Form;
using BackEnd.Services.SMTPConfig;
using BackEnd.Services.University;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IRecipientService, RecipientService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<ISmtpService, SmtpService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
