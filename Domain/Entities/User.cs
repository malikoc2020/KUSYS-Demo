using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string TC { get; set; }
        [NotMapped]
        public string DefaultRole { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        //public ICollection<Car> UserCars { get; set; }
        //public ICollection<Flat> UserFlats { get; set; }
        //[InverseProperty("SendUser")]
        //public virtual ICollection<Message> SendedMessages { get; set; }
        //[InverseProperty("ReceiveUser")]
        //public virtual ICollection<Message> ReceivedMessages { get; set; }
    }
}
