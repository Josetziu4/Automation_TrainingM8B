using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinkedIn_LoginPage.Reporting
{
    class ReportManager
    {
        [Test]
        public void fnGetReportPath()
        {
            string strExecutionPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string strBaseDirectory = strExecutionPath.Substring(0, strExecutionPath.IndexOf("bin"));
            strBaseDirectory = new Uri(strBaseDirectory).LocalPath;

            string strReportDirectory = strBaseDirectory + "ExtentReports";
            if (!Directory.Exists(strReportDirectory))
            {
                Directory.CreateDirectory(strReportDirectory);
            }

            string strReportPath = strReportDirectory + "\\ExtentReport_" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".html";  //ExtentReport_MMDDYYYY_HHMMSS.html
        }
    }
}
