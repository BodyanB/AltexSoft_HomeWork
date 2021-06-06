using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Buyer : BaseModel
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public Buyer(string email, string name, string phoneNumber)
        {
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
