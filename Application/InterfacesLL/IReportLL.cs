using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IReportLL
    {
        Report GetReportById(int id);
        List<Report> GetAllReports(int eventId);
        bool CreateReport(Report report);
        bool DeleteReport(int id);
    }
}
