using Classes;
using InterfacesDAL;
using InterfacesLL;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ReportService : IReportService
    {
        private readonly IReportDAL _reportDAL;

        public ReportService(IReportDAL reportDAL)
        {
            this._reportDAL = reportDAL;
        }

        public bool CreateReport(ReportDTO report)
        {
            if (report == null)
            {
                return false;
            }
            else if (report.Id == null || string.IsNullOrEmpty(report.CommentId.ToString()) || string.IsNullOrEmpty(report.ReporterId.ToString())
                 || string.IsNullOrEmpty(report.Information))
            {
                return false;
            }
            else
            {
                return _reportDAL.CreateReportDAL(report);
            }
        }

        public bool DeleteReport(int id)
        {
            if (id < 0)
            {
                return false;
            }
            else
            {
                return _reportDAL.DeleteReportDAL(id);
            }
        }

        public List<Report> GetAllReports()
        {
            return _reportDAL.GetAllReportsDAL();
        }

        public Report GetReportById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _reportDAL.GetReportByIdDAL(id);
            }
        }
    }
}
