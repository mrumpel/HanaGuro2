using HanaGuro2.Data;
using HanaGuro2.Models;

namespace HanaGuro2.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this WebApplication app)
    {
        var gr = app.MapGroup("users");

        //POST
        gr.MapPost("/", async (User u, PlantDbContext db) =>
        {
            db.Users.Add(u);
            await db.SaveChangesAsync();
            return Results.Created($"{u.Id}", u);
        });
        
        //GET
        gr.MapGet("/{id:int}", async (int id, PlantDbContext db) => db.Users.Find(id));

        return gr;
    }
}