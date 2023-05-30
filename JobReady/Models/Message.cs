using System.ComponentModel.DataAnnotations;

namespace JobReady.Models
{
    public class Message
    {
        [Key]
<<<<<<< HEAD
        public long Id { get; set; }
=======
        public int Id { get; set; }
>>>>>>> f462fb55f0982a97ab83aeb0ff86f5381d8d0645
        [Required]
        public string UserName { get; set; }
        [Required]
        public string MessageText { get; set; }
        public DateTime CreatedOn { get; set; }
<<<<<<< HEAD
        public long SenderID { get; set; }

        public long ReceiverID { get; set; }
        public UserAccount Sender { get; set; }

        public UserAccount Receiver { get; set; }
=======
        public long UserID { get; set; }
        public UserAccount Sender { get; set; }
>>>>>>> f462fb55f0982a97ab83aeb0ff86f5381d8d0645
    }
}
