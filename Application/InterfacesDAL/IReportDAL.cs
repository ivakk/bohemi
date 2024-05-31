using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDAL
{
    public interface IReportDAL
    {
        Report GetReportByIdDAL(int id);
        List<Report> GetAllReportsDAL();
        bool CreateReportDAL(ReportDTO report);
        bool DeleteReportDAL(int id);
    }
}
