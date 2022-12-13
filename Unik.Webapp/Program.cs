using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Unik.UserContext;
using Unik.WebApp.Infrastructure.Booking.Contract.Dto;
using Unik.WebApp.Infrastructure.Booking.Implementation;
using Unik.WebApp.Infrastructure.Kompetence.Contract;
using Unik.WebApp.Infrastructure.Kompetence.Implementation;
using Unik.WebApp.Infrastructure.Kunde.Contract;
using Unik.WebApp.Infrastructure.Kunde.Implementation;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Implementation;
using Unik.WebApp.Infrastructure.Opgave.Contract;
using Unik.WebApp.Infrastructure.Opgave.Implementation;
using Unik.WebApp.Infrastructure.Projekt.Contract;
using Unik.WebApp.Infrastructure.Projekt.Implementation;
using Unik.WebApp.Infrastructure.Sales.Contract;
using Unik.WebApp.Infrastructure.Sales.Implementation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("UserDb");
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Unik.UserContext.Migrations")));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter(); // i video 11 7:40 siger han den ikke er nødvendig

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();


//Docker 
builder.Configuration.AddEnvironmentVariables();


//Medarbejder IHttpClientFactory
//IHttpClientFactory

builder.Services.AddHttpClient<IBookingService, BookingService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"])
);

builder.Services.AddHttpClient<IkompetenceService, kompetenceService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"])
);
builder.Services.AddHttpClient<IOpgaveService, OpgaveService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"])
);
builder.Services.AddHttpClient<ISalesService, SalesService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"])
);

builder.Services.AddHttpClient<IMedarbejderService, MedarbejderService>(client =>
client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"])
);

builder.Services.AddHttpClient<IProjektService, ProjektService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"])
);
builder.Services.AddHttpClient<IKundeService, KundeService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"])
);

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;//ved false, så skal man ikke confirme gennem e-mail.
}).AddEntityFrameworkStores<WebAppUserDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policybuilder => policybuilder.RequireClaim("Admin"));
    options.AddPolicy("Tekniker", policybuilder => policybuilder.RequireClaim("Tekniker"));
    options.AddPolicy("Sælger", policybuilder => policybuilder.RequireClaim("Sælger"));
    options.AddPolicy("Konverter", policybuilder => policybuilder.RequireClaim("Konverter"));
    options.AddPolicy("Konsulent", policybuilder => policybuilder.RequireClaim("Konsulent"));
    options.AddPolicy("Kunde", policybuilder => policybuilder.RequireClaim("Kunde"));
});
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Projekt", "Sælger");
    options.Conventions.AuthorizeFolder("/Opgave", "Sælger");
    options.Conventions.AuthorizeFolder("/Sales", "Sælger");
    options.Conventions.AuthorizeFolder("/Medarbejder", "Sælger");
    options.Conventions.AuthorizeFolder("/Kunde", "Sælger");
    options.Conventions.AuthorizeFolder("/Kompetence", "Sælger");
    options.Conventions.AuthorizePage("/Register", "Sælger");
});




//add-migration InitialMigrationUser -Context WebAppUserDbContext -Project Unik.UserContext.Migrations
//update-database -Context WebAppUserDbContext
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint(); //i video 11 7:40 siger han den ikke er nødvendig
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
