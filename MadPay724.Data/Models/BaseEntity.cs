﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MadPay724.Data.Models
{
    public class BaseEntity <T>
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
    }
}
