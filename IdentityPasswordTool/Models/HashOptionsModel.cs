namespace IdentityPasswordTool.Models;

public class HashOptionsModel
{
    public int IterationCount { get; set; } = 10000;
    public bool UseIdentityV3  { get; set; } = true;
}