using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassroomStart.Models
{
    public partial class Account
    {
        public int AccId { get; set; }
        public int AccClientId { get; set; }
        public int AccTypeId { get; set; }
        public decimal AccBalance { get; set; }
        public DateTime? AccInterestapplieddate { get; set; }
        public int AccAppliedinterest { get; set; }
        public decimal AccDeposit { get; set; }
        public decimal AccWithdraw { get; set; }

        public virtual Client AccClient { get; set; } = null!;
        public virtual Accounttype AccType { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
    }
}
