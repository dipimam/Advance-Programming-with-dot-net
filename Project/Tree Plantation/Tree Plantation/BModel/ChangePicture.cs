﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tree_Plantation.BModel
{
    public class ChangePicture
    {
        [Required]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}