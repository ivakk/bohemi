using Classes;
using InterfacesDAL;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockDAL
{
    public class MockReportDAL : IReportDAL
    {
        public List<Report> reports = new List<Report>();
        private int nextId = 1;  // Simulating auto-increment ID

        public Report GetReportByIdDAL(int id)
        {
            return reports.FirstOrDefault(r => r.Id == id);
        }

        public List<Report> GetAllReportsDAL()
        {
            return new List<Report>(reports);
        }

        public bool CreateReportDAL(ReportDTO newReport)
        {
            try
            {
                newReport.Id = nextId++;  // Assign an ID to the new report
                reports.Add(new Report(newReport.Id, newReport.CommentId, newReport.ReporterId, newReport.Information));
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public bool DeleteReportDAL(int id)
        {
            var report = GetReportByIdDAL(id);
            if (report != null)
            {
                reports.Remove(report);
                return true;
            }
            return false;
        }
    }
}
