using CRUD.Data;
using CRUD.Models;

namespace CRUD.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");     // Grouping routes 
        
        // POST METHOD
        route.MapPost("", async (PersonRequest req, PersonContext context) =>
        {
            var person = new Person(req.name);
            await context.AddAsync(person);

            await context.SaveChangesAsync(); // do the db commit and save data
        });
    }
}