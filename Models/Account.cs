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

        public Account(int accClientId, int accTypeId, decimal accBalance, DateTime? accInterestapplieddate)
        {
            AccClientId = accClientId;
            AccTypeId = accTypeId;
            AccBalance = accBalance;
            AccInterestapplieddate = accInterestapplieddate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("acc_id", TypeName = "int(11)")]
        public int AccId { get; set; }

        [Column("acc_client_id", TypeName = "int(11)")]
        public int AccClientId { get; set; }

        [Column("acc_type_id", TypeName = "int(11)")]
        public int AccTypeId { get; set; }

        [Column("acc_balance", TypeName = "decimals(5,2)")]
        public decimal AccBalance { get;  set; }

        [Column("acc_interestapplieddate", TypeName = "datetime")]
        public DateTime? AccInterestapplieddate { get; set; }

        [Column("acc_appliedinterest", TypeName = "int(11)")]
        public int AccAppliedinterest { get; set; }

        [Column("acc_deposit", TypeName = "decimal(10,0)")]
        public decimal AccDeposit { get; set; }

        [Column("acc_withdraw", TypeName = "decimal(10,0)")]
        public decimal AccWithdraw { get; set; }


        public decimal Deposit(decimal amount)
        {
            AccBalance = AccBalance + (amount);
            return AccBalance;
        }

        public decimal Withdraw(decimal amount)
        {
            try
            {
                if(amount < AccBalance)
                    AccBalance-=amount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Insuffient funds:" + ex.Message);
            }
            return AccBalance;
        }



          public decimal ApplyInterest()
          {
              if(Client.VIPClient == true)
              {
                AccBalance += (AccBalance * ((AccType.AtInterestrate + 1) / 100));
              }
              else
            {
                AccBalance -= (AccBalance * ((AccType.AtInterestrate + 1) / 100));
            }
            return AccBalance;
          } 





        [ForeignKey(nameof(AccClientId))]
        public virtual Client AccClient { get; set; } = null!;
        
        [ForeignKey(nameof(AccTypeId))]
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