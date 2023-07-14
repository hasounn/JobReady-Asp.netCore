using System.ComponentModel.DataAnnotations;

namespace JobReady
{
    public class Configuration
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Service { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
    }
}
