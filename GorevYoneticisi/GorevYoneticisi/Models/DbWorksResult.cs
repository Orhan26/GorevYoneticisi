using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorevYoneticisi.Models
{
    public class DbWorksResult
    {
        public string Message { get; set; }
        public object Result { get; set; }
        public bool Success { get; set; }
    }
}
