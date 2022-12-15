using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Booking.Command;
using Unik.Applicaiton.Booking.Command.Implementation;
using Unik.Applicaiton.Booking.Queries;
using Unik.Applicaiton.Booking.Queries.Implementation;
using Unik.Applicaiton.Booking.Repositories;
using Unik.Applicaiton.Kompetence.Commands;
using Unik.Applicaiton.Kompetence.Commands.Implementation;
using Unik.Applicaiton.Kompetence.Query;
using Unik.Applicaiton.Kompetence.Query.Implementation;
using Unik.Applicaiton.Kompetence.Repositories;
using Unik.Applicaiton.Kunde.Commands;
using Unik.Applicaiton.Kunde.Commands.Implementation;
using Unik.Applicaiton.Kunde.Query;
using Unik.Applicaiton.Kunde.Query.Implementation;
using Unik.Applicaiton.Kunde.Repositories;
using Unik.Applicaiton.Medarbejder.Commands;
using Unik.Applicaiton.Medarbejder.Commands.Implementation;
using Unik.Applicaiton.Medarbejder.Query;
using Unik.Applicaiton.Medarbejder.Query.Implementation;
using Unik.Applicaiton.Medarbejder.Repositories;
using Unik.Applicaiton.Opgave.Command;
using Unik.Applicaiton.Opgave.Command.Implementation;
using Unik.Applicaiton.Opgave.Queries;
using Unik.Applicaiton.Opgave.Queries.Implementation;
using Unik.Applicaiton.Opgave.Repositories;
using Unik.Applicaiton.Projekt.Command;
using Unik.Applicaiton.Projekt.Command.Implementation;
using Unik.Applicaiton.Projekt.Queries;
using Unik.Applicaiton.Projekt.Queries.Implementation;
using Unik.Applicaiton.Projekt.Repositories;
using Unik.Applicaiton.Sales.Commands;
using Unik.Applicaiton.Sales.Commands.Implementation;
using Unik.Applicaiton.Sales.Query;
using Unik.Applicaiton.Sales.Query.Implementation;
using Unik.Applicaiton.Sales.Repositories;
using Unik.Application.Kunde.Query;
using Unik.Application.Kunde.Query.Implementation;
using Unik.Crosscut.TransactionHandling;
using Unik.Crosscut.TransactionHandling.Implementation;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Opgave.DomainService;
using Unik.Infrastructure.Booking.DomainServices;
using Unik.Infrastructure.Kompetence.Repositories;
using Unik.Infrastructure.Kunde.Repositories;
using Unik.Infrastructure.Medarbejder.Repositories;
using Unik.Infrastructure.Opgave.DomainService;
using Unik.Infrastructure.Opgave.Repositories;
using Unik.Infrastructure.Projekt.Repositories;
using Unik.Infrastructure.Sales.Repositories;
using Unik.SqlServerContext;
using static Unik.Infrastructure.Booking.Repository.BoookingRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Docker
builder.Configuration.AddEnvironmentVariables();

//Connectionstring

builder.Services.AddDbContext<UnikContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UnikConnection"),
            x => x.MigrationsAssembly("Unik.SqlServerContext.Migrations")));
//Medarbejder IoC
builder.Services.AddScoped<ICreateMedarbejderCommand, CreateMedarbejderCommand>();
builder.Services.AddScoped<IMedarbejderRepository, MedarbejderRepository>();
builder.Services.AddScoped<IDeleteMedarbejderCommand, DeleteMedarbejderCommand>();
builder.Services.AddScoped<IEditMedarbejderCommand, EditMedarbejderCommand>();
builder.Services.AddScoped<IMedarbejderGetAllQuery, MedarbejderGetAllQuery>();
builder.Services.AddScoped<IMedarbejderGetQuery, MedarbejderGetQuery>();
builder.Services.AddScoped<ICreateMedarbejderKompetenceCommand, CreateMedarbejderKompetenceCommand>();
builder.Services.AddScoped<IMedarbejderGetByUserId, MedarbejderGetByUserId>();


//Projekt IoC
builder.Services.AddScoped<IProjektGetQuery, ProjektGetQuery>();
builder.Services.AddScoped<IProjektGetAllQuery, ProjektGetAllQuery>();
builder.Services.AddScoped<IEditProjektCommand, EditProjektCommand>();
builder.Services.AddScoped<IDeleteProjektCommand, DeleteProjektCommand>();
builder.Services.AddScoped<ICreateProjektCommand, CreateProjektCommand>();
builder.Services.AddScoped<IProjektRepositories, Repositories>();


//Kompetence

builder.Services.AddScoped<ICreateKompetenceCommand, CreateKompetenceCommand>();
builder.Services.AddScoped<IEditKompetenceCommand, EditKompetenceCommand>();
builder.Services.AddScoped<IDeleteKompetenceCommand, DeleteKompetenceCommand>();
builder.Services.AddScoped<iKompetenceGetAllQuery, KompetenceGetAllQuery>();
builder.Services.AddScoped<IKompetenceRepository, KompetenceRepository>();
builder.Services.AddScoped<iKompetenceGetQuery, KompetenceGetQuery>();


//Kunde IoC
builder.Services.AddScoped<IKundeRepository, KundeRepository>();
builder.Services.AddScoped<ICreateKundeCommand, CreateKundeCommand>();
builder.Services.AddScoped<IEditKundeCommand, EditKundeCommand>();
builder.Services.AddScoped<IDeleteKundeCommand, DeleteKundeCommand>();
builder.Services.AddScoped<IKundeGetAllQuery, KundeGetAllQuery>();
builder.Services.AddScoped<IKundeGetQuery, KundeGetQuery>();
builder.Services.AddScoped<IKundeGetByUser,KundeGetByUser>();

//booking IoC
builder.Services.AddScoped<ICreateBookingCommand, CreateBookingCommand>();
builder.Services.AddScoped<IEditBookingCommand, EditBookingCommand>();
builder.Services.AddScoped<IDeleteBookingCommand, DeleteBookingCommand>();
builder.Services.AddScoped<IBookingGetAllQuery, BookingGetAllQuery>();
builder.Services.AddScoped<IBookingGetQuery, BookingGetQuery>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>(); 
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();
builder.Services.AddScoped<IFindMedarbejder, FindMedarbejder>();


//Opgave IoC
builder.Services.AddScoped<ICreateOpgaveCommand, CreateOpgaveCommand>();
builder.Services.AddScoped<IEditOpgaveCommand, EditOpgaveCommand>();
builder.Services.AddScoped<IDeleteOpgaveCommand, DeleteOpgaveCommand>();
builder.Services.AddScoped<IOpgaveGetAllQuery, OpgaveGetAllQuery>();
builder.Services.AddScoped<IOpgaveGetQuery, OpgaveGetQuery>();
builder.Services.AddScoped<IOpgaveRepository, OpgaveRepository>();
builder.Services.AddScoped<IOpgaveDomainService, OpgaveDomainService>();

//Sales 
builder.Services.AddScoped<ICreateSalesCommand, CreateSalesCommand>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IDeleteSalesCommand, DeleteSalesCommand>();
builder.Services.AddScoped<IEditSalesCommand, EditSalesCommand>();
builder.Services.AddScoped<ISalesGetAllQuery, SalesGetAllQuery>();
builder.Services.AddScoped<ISalesGetQuery, SalesGetQuery>();

//Transaction 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(a =>
{
    var db = a.GetService<UnikContext>();
    return new UnitOfWork(db);
});



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

//Commands
//add-migration førsteMigration -Context UnikContext -project Unik.SqlServerContext.Migrations
//update-database -context UnikContext