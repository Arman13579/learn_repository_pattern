﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Owner")]
    public class Owner
    {

        // for initalizing non null variable
        //public Owner(string id, string name, string address)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Address = address;
        //}

        [Column("OwnerId")]
        public string Id { get; set; } = Guid.NewGuid().ToString(); // set default value to non null properties
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longger than 60 characters")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address can't be logger than 100 characters")]
        public string Address { get; set; } = string.Empty;
        public ICollection<Account>? Accounts { get; set; }
    }
}
