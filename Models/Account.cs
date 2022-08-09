using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassroomStart.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("acc_id", TypeName = "int(11)")]
        public int AccId { get; set; }

        [Column("acc_client_id", TypeName = "int(11)")]
        public int AccClientId { get; set; }

        [Column("acc_type_id", TypeName = "int(11)")]
        public int AccTypeId { get; set; }

        [Column("acc_balance", TypeName = "decimals(5,2)")]
        public decimal AccBalance { get; set; }

        [Column("acc_interestapplieddate", TypeName = "datetime")]
        public DateTime? AccInterestapplieddate { get; set; }

        [Column("acc_appliedinterest", TypeName = "int(11)")]
        public int AccAppliedinterest { get; set; }

        [Column("acc_deposit", TypeName = "decimal(10,0)")]
        public decimal AccDeposit { get; set; }

        [Column("acc_withdraw", TypeName = "decimal(10,0)")]
        public decimal AccWithdraw { get; set; }

        public virtual Client AccClient { get; set; } = null!;
        public virtual Accounttype AccType { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;

    }
}







/*
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
*/