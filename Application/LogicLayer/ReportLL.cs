using Classes;
using InterfacesDAL;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ReportLL : IReportLL
    {
        private readonly IReportDAL _reportDAL;

        public ReportLL(IReportDAL reportDAL)
        {
            this._reportDAL = reportDAL;
        }

        public bool CreateReport(Report report)
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
            if (id < 0 || id == null)
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
            if (id < 0 || id == null)
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
