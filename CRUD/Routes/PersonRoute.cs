using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");     // Grouping routes 

        // GET METHOD
        route.MapGet("", async (PersonContext context) =>
        {
            var person = await context.Person.ToListAsync();
            return Results.Ok(person);
        });
        
        
        // POST METHOD
        route.MapPost("", async (PersonRequest req, PersonContext context) =>
        {
            var person = new Person(req.name);
            await context.AddAsync(person);

            await context.SaveChangesAsync(); // do the db commit and save data
        });
        
        // PUT METHOD
        route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
        {

            try
            {
                var person = await context.Person.FirstOrDefaultAsync(x => x.Id == id);
                
                if (person == null)
                {
                    return Results.NotFound();
                }
                
                person.ChangeName(req.name);
                
                await context.SaveChangesAsync();

                return Results.Ok($"User {person.Name} has been updated ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
        
        
        // DELETE METHOD
        route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
        {
            try
            {
                var person = await context.Person.FirstOrDefaultAsync(x => x.Id == id);

                if (person == null)
                {
                    return Results.NotFound();
                }
                
                person.ChangeIsActive(false);
                await context.SaveChangesAsync();
                return Results.Ok($"User {person.Name} has been deleted ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }
}