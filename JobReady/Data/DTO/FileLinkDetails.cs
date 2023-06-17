using System.ComponentModel.DataAnnotations;

namespace JobReady.Data.DTO
{
    public class FileLinkDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ContentSize { get; set; }
        public virtual System.Byte[] ContentHash { get; set; }
        public ObjectType? ObjectType { get; set; }
        public long? ObjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public UserAccountDetails CreatedBy { get; set; }
    }
}
