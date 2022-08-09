using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassroomStart.Models
{
    public partial class Accounttype
    {
        public Accounttype()
        {
            Accounts = new HashSet<Account>();
        }

        public int AtId { get; set; }
        public string AtName { get; set; } = null!;
        public decimal? AtInterestrate { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
