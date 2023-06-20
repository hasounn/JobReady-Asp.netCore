namespace JobReady.Data.DTO
{
    public class FacultyDetails
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public long UniversityId { get; set; }
        public UniversityDetails University { get; set; }
        public string BranchLocation { get; set; }
        public long BranchNumber { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
