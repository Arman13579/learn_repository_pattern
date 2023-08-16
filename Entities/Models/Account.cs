using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    [Table("Account")]
    public class Account
    {
        [Column("AccountId")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Account type is required")]
        public string? AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public Owner? Owner { get; set; }
    }
}
