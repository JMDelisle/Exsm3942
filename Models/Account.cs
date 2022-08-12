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
    public partial class Account
    {
        public Account(int accClientid, int accTypeId, decimal accBalance, DateTime accInterestapplieddate)
        {
            AccClientid = accClientid;
            AccTypeId = accTypeId;
            AccBalance = accBalance;
            AccInterestapplieddate = accInterestapplieddate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("acc_id", TypeName = "int(11)")]
        public int AccId { get; set; }

        [Column("acc_client_id", TypeName = "int(11)")]
        public int AccClientid { get; set; }

        [Column("acc_type_id", TypeName = "int(11)")]
        public int AccTypeId { get; set; }

        [Column("acc_balance", TypeName = "decimals(5,2)")]
        public decimal AccBalance { get; private set; }

        [Column("acc_interestapplieddate", TypeName = "datetime")]
        public DateTime AccInterestapplieddate { get; set; }


        public decimal Deposit(decimal amount)
        {
            AccBalance = AccBalance + (amount);
            return AccBalance;
        }

        public decimal Withdraw(decimal amount)
        {
            try
            {
                if (amount < AccBalance)
                    AccBalance -= amount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Insuffient funds:" + ex.Message);
            }
            return AccBalance;
        }



        public decimal ApplyInterest()
        {
            if (Client.GetVIPClient())
            {
                AccBalance += (AccBalance * ((AccType.AtInterestrate + 1) / 100));
            }
            else
            {
                AccBalance -= (AccBalance * ((AccType.AtInterestrate + 1) / 100));
            }
            return AccBalance;
        }

        [ForeignKey(nameof(AccClientid))]
        public virtual Client AccClient { get; set; } = null!;

        [ForeignKey(nameof(AccTypeId))]
        public virtual Accounttype AccType { get; set; } = null!;
    }
}
