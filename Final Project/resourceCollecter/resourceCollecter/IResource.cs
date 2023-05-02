namespace resourceCollecter
{
    public interface IResource
    {
        // interface for the base resource to inherit
        double PerClick { get; }
        double PerSecond { get; }
        double Count { get; }
    }
}
