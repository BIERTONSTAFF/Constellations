namespace Constellations.Dto;

public abstract class StarDto
{
    public static int Cid { get; set; }
    public static int PosX { get; set; }
    public static int PosY { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}