﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MadPay724.Data.Dtos.Site.Panel.Document
{
   public class DocumentForCreateDto
    {
        [Required]
        public bool IsTrue { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string Name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string NationalCode { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 0)]
        public string FatherNameRegisterCode { get; set; }
        [Required]
        public string BirthDay { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string Address { get; set; }
        public IFormFile File { get; set; }
    }
}