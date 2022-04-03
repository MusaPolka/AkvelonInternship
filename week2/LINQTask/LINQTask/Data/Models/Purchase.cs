using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTask.Data.Models
{
    public class Purchase
    {
        public int ConsumerCode { get; set; }
        public string ArticleNumber { get; set; }
        public string StoreName { get; set; }
    }
}
