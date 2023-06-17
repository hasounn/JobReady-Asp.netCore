namespace JobReady;

public class UniversityMajorDetails
{
    public long Id { get; set; }
    public long UniversityId { get; set; }
    public UniversityDetails University { get; set; }
    public long MajorId { get; set; }
    public Major Major { get; set; }
}
