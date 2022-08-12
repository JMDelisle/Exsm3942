using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClassroomStart.Models
{
    [Table("client")]
    public partial class Client
    {

       

        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        public Client(string cFirstname, string cLastname, DateTime cBirthdate, string cHomeaddress)
        {
            CFirstname = cFirstname;
            CLastname = cLastname;
            CBirthdate = cBirthdate;
            CHomeaddress = cHomeaddress;
        }

        private static bool vIPClient;

        public static bool GetVIPClient()
        {
            return vIPClient;
        }

        internal static void SetVIPClient(bool value)
        {
            vIPClient = value;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("c_id", TypeName = "int(11)")]
        public int CId { get; set; }

        [Column("c_firstname", TypeName = "varchar(50)")]
        [StringLength(30)]
        public string CFirstname { get; set; } = null!;

        [Column("c_lastname", TypeName = "varchar(50)")]
        [StringLength(30)]
        public string CLastname { get; set; } = null!;

        [Column("c_birthdate", TypeName = "datetime")]
        public DateTime CBirthdate { get; set; }

        [Column("c_homeaddress", TypeName = "varchar(255)")]
        public string CHomeaddress { get; set; } = null!;


        [NotMapped]
        public bool VIPClient
        {
            get
            {
                return Accounts.Sum(s => s.AccBalance) > 100000;
            }
        }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
