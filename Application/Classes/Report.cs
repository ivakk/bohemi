﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Report
    {
        public int Id { get; }
        public int CommentId { get; private set; }
        public int ReporterId { get; private set; }
        public bool Handled { get; private set; }

        public Report(int id, int commentId, int reporterId, bool handled)
        {
            Id = id;
            CommentId = commentId;
            ReporterId = reporterId;
            Handled = handled;
        }
    }
}
