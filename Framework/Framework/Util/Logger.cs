using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
        public static void ErrorHandler(IWebDriver driver, Exception ex)
        {
            Log.Error(ex);
            var screenshot = driver.TakeScreenshot();
            var filePath = ".//screenshots/" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
            try
            {
                screenshot.SaveAsFile(filePath);
            }
            catch(Exception e)
            {
                log.Error("Unable to save screenshot" + e.Message);
            }
            throw ex;
        }
    }
}
