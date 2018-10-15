using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_Example.Models
{
    public class SampleModel
    {
        public Guid Id { get; set; }

        public string SampleString { get; set; }
        public int SampleInt { get; set; }
    }
}