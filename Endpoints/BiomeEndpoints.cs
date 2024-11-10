using HanaGuro2.Data;
using Microsoft.EntityFrameworkCore;

namespace HanaGuro2.Endpoints;

public static class BiomeEndpoints
{
    public static RouteGroupBuilder MapBiomeEndpoints(this WebApplication app)
    {
        var gr = app.MapGroup("biomes");

        gr.MapGet("/", 
            async (PlantDbContext db) => 
                await db.Biomes.Select(x => x)
                    .AsNoTracking()
                    .ToListAsync());
        
        return gr;
    }
}