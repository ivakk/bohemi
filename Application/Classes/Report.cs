using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Report
    {
        public int Id { get; }
        public int CommentId { get; set; }
        public int ReporterId { get; set; }
        public string Information { get; set; }

        public Report(int id, int commentId, int reporterId, string information)
        {
            Id = id;
            CommentId = commentId;
            ReporterId = reporterId;
            Information = information;
        }
    }
}
