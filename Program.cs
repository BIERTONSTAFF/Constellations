using Constellations.Controllers;
using Constellations.Models;

const int width = 48;
const int height = 24;

var constellations = await ConstellationController.All();

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Write("Constellations List:\n");

constellations.ForEach(x =>
{
    Console.Write($"{constellations.IndexOf(x) + 1}. {x.Name}\n");
});

Console.Write("Constellation ID: ");

var id = int.Parse(Console.ReadLine()!);
var constellation = constellations.Find(x => x.Id == id);
var stars = await StarController.AllByCid(constellation!.Id);

Console.Clear();

PrintTable();
PrintConstellation(stars);

Console.SetCursorPosition(0, 24);
Console.Write($"Constellation: {constellation.Name}\n" +
              $"— {constellation.Description}\n");

stars.ForEach(x =>
{
    var star = stars.ElementAt(stars.IndexOf(x));
    
    Console.Write($"Star({star.Id}): {star.Name}\n" +
                  $"— {star.Description}\n");
});

Console.Read();

static void PrintConstellation(List<Star> stars)
{
    stars.ForEach(x =>
    {
        var star = stars.ElementAt(stars.IndexOf(x));
        
        Console.SetCursorPosition(star.PosX + 1, star.PosY + 1);
        Console.Write("*");
    });
}

static void PrintTable()
{
    for (var w = 0; w < height; w++)
    {
        for (var h = 0; h < width; h++)
        {
            if (w is 0 or (height - 1)) Console.Write("=");
            else if (h is 0 or (width - 1)) Console.Write("|");
            else Console.Write(" ");
        }
    
        Console.Write("\n");
    }
}