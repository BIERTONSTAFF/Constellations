namespace Constellations.Models;

public class Star
{
    public int Id { get; set; }
    public int Cid { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}