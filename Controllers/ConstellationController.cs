using Constellations.Dto;
using Constellations.Models;
using Microsoft.EntityFrameworkCore;

namespace Constellations.Controllers;

public abstract class ConstellationController
{
    public static async Task<List<Constellation>> All()
    {
        var ctx = new ApplicationContext();
        var constellations = await ctx.Constellations!.Select(x => x).ToListAsync();
        
        return constellations;
    }

    public static async Task<Constellation?> Find(int id)
    {
        var ctx = new ApplicationContext();
        var constellation = await ctx.Constellations!.SingleOrDefaultAsync(x => x.Id == id);

        return constellation;
    }
    
    public static async Task Create(ConstellationDto dto)
    {
        var ctx = new ApplicationContext();
        var constellation = new Constellation()
        {
            Name = dto.Name,
            Description = dto.Description
        };

        await ctx.Constellations!.AddAsync(constellation);

        try
        {
            await ctx.SaveChangesAsync();
        }
        catch(DbUpdateException)
        {
            Console.Write("DbUpdateException\n");
        }
    }
}