using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IReportService
    {
        Report GetReportById(int id);
        List<Report> GetAllReports();
        bool CreateReport(ReportDTO report);
        bool DeleteReport(int id);
    }
}
