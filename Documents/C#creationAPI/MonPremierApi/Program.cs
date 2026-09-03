using Centralisation.Film.Endpoint;
using Context.Data.Films;
using Data.Extention;
using Microsoft.EntityFrameworkCore;
using Centralisation.Centre.Jeux;
using Context.Data.Jeux;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connexionstring = builder.Configuration.GetConnectionString("BaseDataFilm");
var connexionjeu = builder.Configuration.GetConnectionString("ContextJeu");


builder.Services.AddDbContext<DataFilm>(options =>
    options.UseSqlite(connexionstring));


builder.Services.AddDbContext<ContextJeu>(Options =>
Options.UseSqlite(connexionjeu));

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();


app.UseCors();


app.MigrationData();


app.CentralisationFilm();
app.CentralisationJeu();

// je met en place swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();


