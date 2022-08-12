using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassroomStart.Models
{
    [Table("accounttype")]
    public class Accounttype
    {

        public Accounttype (string atName, decimal atInterestrate)
        {
            
            AtName = atName;
            AtInterestrate = atInterestrate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("at_id", TypeName = "int(11)")]
        public int AtId { get; set; }

        [Column("at_name", TypeName = "varchar(50)")]
        [StringLength(50)]
        [Required]
        public string AtName { get; set; } = null!;

        [Column("at_interestrate", TypeName = "decimal(5,2)")]
        [Required]
        public decimal AtInterestrate { get; set; }



        [InverseProperty(nameof(Models.Account.AccType))]
        public virtual ICollection<Account> Accounts { get; set; }

    }
}

/*
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
*/