
using Labb3Api_V2.Data;
using Labb3Api_V2.Models;
using Labb3Api_V2.Models.DTOs;
using Labb3Api_V2.Models.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Labb3Api_V2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            /* API-ANROP */

            // GET - Hämtar alla personer i systemet
            app.MapGet("/persons", async (ApplicationDbContext context) =>
            {
                var persons = await context.Persons
                .Include(p => p.PersonHobbies)
                .ThenInclude(ph => ph.Hobby)
                .ThenInclude(h => h.WebLinks)
                .ToListAsync();

                if (persons == null || persons.Count == 0)
                {
                    return Results.NotFound("No persons found in the database");
                }

                // Creating DTOs to avoid cycles before serialization
                var personsDTO = persons.Select(p => new PersonDTO
                {
                    PersonId = p.PersonId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email,
                    Hobbies = p.PersonHobbies.Select(ph => new HobbyDTO
                    {
                        HobbyId = ph.Hobby.HobbyId,
                        Title = ph.Hobby.Title,
                        Description = ph.Hobby.Description,
                        WebLinks = ph.Hobby.WebLinks.Select(wl => new WebLinkDTO
                        {
                            WebLinkId = wl.WebLinkId,
                            Url = wl.Url
                        }).ToList(),
                    }).ToList(),
                }).ToList();

                return Results.Ok(personsDTO);
            });

            // GET - Hämta alla intressen som är kopplade till en specifik person
            app.MapGet("/persons/{personId:int}/hobbies", async (int personId, ApplicationDbContext context) =>
            {
                var personHobbies = await context.PersonHobbies
                .Where(ph => ph.FkPersonId == personId)
                .Include(ph => ph.Hobby)
                .ThenInclude(h => h.WebLinks)
                .Select(ph => new HobbyDTO
                {
                    HobbyId = ph.FkHobbyId,
                    Title = ph.Hobby.Title,
                    Description = ph.Hobby.Description,
                    WebLinks = ph.Hobby.WebLinks.Select(wl => new WebLinkDTO
                    {
                        WebLinkId = wl.WebLinkId,
                        Url = wl.Url
                    }).ToList()
                }).ToListAsync();

                if (personHobbies == null || personHobbies.Count == 0)
                {
                    return Results.NotFound($"Person with ID: {personId} not found in the database");
                }

                return Results.Ok(personHobbies);
            });

            // GET - Hämta alla länkar som är kopplade till en specifik person
            app.MapGet("/persons/{personId:int}/weblinks", async (int personId, ApplicationDbContext context) =>
            {
                var personWebLinks = await context.WebLinks
                .Where(wl => wl.Hobby.PersonHobbies.Any(ph => ph.FkPersonId == personId))
                .Include(wl => wl.Hobby)
                .Select(wl => new WebLinkDTO
                {
                    WebLinkId = wl.WebLinkId,
                    Url = wl.Url,
                    HobbyTitle = wl.Hobby.Title
                }).ToListAsync();

                if (personWebLinks == null || personWebLinks.Count == 0)
                {
                    return Results.NotFound($"Person with ID: {personId} has no linked weblinks");
                }

                return Results.Ok(personWebLinks);          
            });

            // POST - Koppla en person till ett nytt intresse
            app.MapPost("/persons/{personId:int}/hobbies", async (int personId, Hobby hobby, ApplicationDbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);

                if (person == null)
                {
                    return Results.NotFound($"Person with ID: {personId} not found in the database");
                }

                var newHobby = new Hobby()
                {
                    Title = hobby.Title,
                    Description = hobby.Description
                };

                context.Hobbies.Add(newHobby);
                await context.SaveChangesAsync();

                var newPersonHobby = new PersonHobby()
                {
                    FkPersonId = personId,
                    FkHobbyId = newHobby.HobbyId,
                };

                context.PersonHobbies.Add(newPersonHobby);
                await context.SaveChangesAsync();

                var responseDTO = new HobbyResponseDTO()
                {
                    HobbyId = newHobby.HobbyId,
                    Title = newHobby.Title,
                    Description = newHobby.Description
                };

                return Results.Created($"/persons/{personId}/hobbies", responseDTO);
            });

            // POST - Lägg in nya länkar för en specifik person och ett specifikt intresse
            app.MapPost("/persons/{personId:int}/hobbies/{hobbyId:int}/weblinks", async
                (int personId, int hobbyId, List<WebLink> webLinks, ApplicationDbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);

                if (person == null)
                {
                    return Results.NotFound($"Person with ID: {personId} not found in the database");
                }

                var hobby = await context.PersonHobbies
                .Where(ph => ph.FkPersonId == personId && ph.FkHobbyId == hobbyId)
                .Include(ph => ph.Hobby)
                .Select(ph => ph.Hobby)
                .FirstOrDefaultAsync();

                if (hobby == null)
                {
                    return Results.NotFound($"Person has no hobbies connected with ID: {hobbyId}");
                }

                var webLinkResponseList = new List<WebLinkResponseDTO>();

                var newWebLinks = webLinks.Select(wl => new WebLink
                {
                    WebLinkId = wl.WebLinkId,
                    Url = wl.Url,
                    FkHobbyId = hobby.HobbyId
                });

                await context.WebLinks.AddRangeAsync(newWebLinks);
                await context.SaveChangesAsync();

                foreach (var webLink in newWebLinks)
                {
                    var webLinkResponse = new WebLinkResponseDTO()
                    {
                        WebLinkId = webLink.WebLinkId,
                        Url = webLink.Url,
                    };

                    webLinkResponseList.Add(webLinkResponse);
                }

                return Results.Created($"/persons/{personId}/hobbies/{hobbyId}/weblinks", webLinkResponseList);
            });

            /* ÖVRIGA API-ANROP */

            // POST - Skapa en ny person
            app.MapPost("/persons", async (Person person, ApplicationDbContext context) =>
            {
                if (person == null)
                {
                    return Results.BadRequest();
                }

                context.Persons.Add(person);
                await context.SaveChangesAsync();

                return Results.Created($"/api/persons/{person.PersonId}", person);
            });

            app.Run();
        }
    }
}
