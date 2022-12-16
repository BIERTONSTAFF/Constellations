using Constellations.Dto;
using Constellations.Models;
using Microsoft.EntityFrameworkCore;

namespace Constellations.Controllers;

public abstract class StarController
{
    public static async Task<List<Star>> AllByCid(int cid)
    {
        var ctx = new ApplicationContext();
        var stars = await ctx.Stars!.Where(x => x.Cid == cid).ToListAsync();

        return stars;
    }

    public static async Task<Star?> Find(int id)
    {
        var ctx = new ApplicationContext();
        var star = await ctx.Stars!.SingleOrDefaultAsync(x => x.Id == id);

        return star;
    }
    
    public static async void Create(StarDto dto)
    {
        var ctx = new ApplicationContext();
        var star = new Star()
        {
            Cid = StarDto.Cid,
            PosX = StarDto.PosX,
            PosY = StarDto.PosY,
            Name = dto.Name,
            Description = dto.Description
        };

        await ctx.Stars!.AddAsync(star);

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