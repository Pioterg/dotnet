﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Models.Domains
{
    internal class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
