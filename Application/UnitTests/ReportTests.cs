using DTOs;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockDAL;

namespace UnitTests
{
    public class ReportTests
    {
        [Fact]
        public void CreateReport_AddsReport_ReturnsTrue()
        {
            // Arrange
            var newReport = new ReportDTO(0, 1, 1, false);

            MockReportDAL _mockReportDAL = new MockReportDAL();
            ReportService _reportService = new ReportService(_mockReportDAL);

            // Act
            bool result = _reportService.CreateReport(newReport);

            // Assert
            Assert.True(result);
            Assert.NotEmpty(_reportService.GetAllReports());
        }

        [Fact]
        public void GetReportById_ReturnsReport_WhenIdIsValid()
        {
            // Arrange
            var newReport = new ReportDTO(0, 1, 1, false);

            MockReportDAL _mockReportDAL = new MockReportDAL();
            ReportService _reportService = new ReportService(_mockReportDAL);

            _reportService.CreateReport(newReport);
            int reportId = _mockReportDAL.reports.Last().Id;

            // Act
            var report = _reportService.GetReportById(reportId);

            // Assert
            Assert.NotNull(report);
        }

        [Fact]
        public void DeleteReport_RemovesReport_WhenIdIsValid()
        {
            // Arrange
            var newReport = new ReportDTO(0, 1, 1, false);

            MockReportDAL _mockReportDAL = new MockReportDAL();
            ReportService _reportService = new ReportService(_mockReportDAL);

            _reportService.CreateReport(newReport);
            int reportId = _mockReportDAL.reports.Last().Id;

            // Act
            bool result = _reportService.DeleteReport(reportId);

            // Assert
            Assert.True(result);
            Assert.Null(_reportService.GetReportById(reportId));
        }

        [Fact]
        public void GetAllReports_ReturnsAllReports()
        {
            // Arrange
            var newReport1 = new ReportDTO(0, 1, 1, false);
            var newReport2 = new ReportDTO(1, 1, 2, false);

            MockReportDAL _mockReportDAL = new MockReportDAL();
            ReportService _reportService = new ReportService(_mockReportDAL);

            _reportService.CreateReport(newReport1);
            _reportService.CreateReport(newReport2);

            // Act
            var allReports = _reportService.GetAllReports();

            // Assert
            Assert.Equal(2, allReports.Count);
        }
    }
}
