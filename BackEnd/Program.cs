using BackEnd.Services.Configuration;
using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BackEnd.Helpers;


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
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISmtpService, SmtpService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWeightService, WeightService>();
builder.Services.AddScoped<IRatingService, RatingService>();




var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

var contact = new OpenApiContact()
{
    Name = "Mohamad Lawand",
    Email = "hello@mohamadlawand.com",
    Url = new Uri("http://www.mohamadlawand.com")
};

var license = new OpenApiLicense()
{
    Name = "Free License",
    Url = new Uri("http://www.mohamadlawand.com")
};

var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "Minimal API - JWT Authentication with Swagger demo",
    Description = "Implementing JWT Authentication in Minimal API",
    TermsOfService = new Uri("http://www.example.com"),
    Contact = contact,
    License = license
};

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});

builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7088") // Add your client URL
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseMiddleware<RequestResponseLoggingMiddleware>();


//app.MapGet("/items", [Authorize] async (ApiDbContext db) =>
//{
//    return await db.Items.ToListAsync();
//});

//app.MapPost("/items", [Authorize] async (ApiDbContext db, Item item) => {
//    if (await db.Items.FirstOrDefaultAsync(x => x.Id == item.Id) != null)
//    {
//        return Results.BadRequest();
//    }

//    db.Items.Add(item);
//    await db.SaveChangesAsync();
//    return Results.Created($"/Items/{item.Id}", item);
//});

//app.MapGet("/items/{id}", [Authorize] async (ApiDbContext db, int id) =>
//{
//    var item = await db.Items.FirstOrDefaultAsync(x => x.Id == id);

//    return item == null ? Results.NotFound() : Results.Ok(item);
//});

//app.MapPut("/items/{id}", [Authorize] async (ApiDbContext db, int id, Item item) =>
//{
//    var existItem = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
//    if (existItem == null)
//    {
//        return Results.BadRequest();
//    }

//    existItem.Title = item.Title;
//    existItem.IsCompleted = item.IsCompleted;

//    await db.SaveChangesAsync();
//    return Results.Ok(item);
//});

//app.MapDelete("/items/{id}", [Authorize] async (ApiDbContext db, int id) =>
//{
//    var existItem = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
//    if (existItem == null)
//    {
//        return Results.BadRequest();
//    }

//    db.Items.Remove(existItem);
//    await db.SaveChangesAsync();
//    return Results.NoContent();
//});




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();


app.MapControllers();

app.Run();

record UserDto(string UserName, string Password, string University);

