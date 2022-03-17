﻿using ApplicationCore.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class FavoriteRequestModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public Movie? Movie { get; set; }
    }
}
