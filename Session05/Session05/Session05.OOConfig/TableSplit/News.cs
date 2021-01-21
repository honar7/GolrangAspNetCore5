using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05.OOConfig.TableSplit
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public NewsDetail NewsDetail { get; set; }
    }

    public class NewsDetail
    {
        public int Id { get; set; }
        public string Body { get; set; }
    }
}
