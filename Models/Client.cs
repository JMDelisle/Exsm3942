using System;
using System.Collections.Generic;

namespace ClassroomStart.Models
{
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        public int CId { get; set; }
        public string CFirstname { get; set; } = null!;
        public string CLastname { get; set; } = null!;
        public DateOnly CBirthdate { get; set; }
        public string? CHomeaddress { get; set; }

        public virtual Account CIdNavigation { get; set; } = null!;
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
