﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Models
{
    public class Log
    {

        public int Id { get; set; }

        public string Type { get; set; }
        public string Message { get; set; }

        public DateTime Date { get; set; }

    }
}
