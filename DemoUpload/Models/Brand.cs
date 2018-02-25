using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoUpload.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] BrandImage { get; set; }
    }
}