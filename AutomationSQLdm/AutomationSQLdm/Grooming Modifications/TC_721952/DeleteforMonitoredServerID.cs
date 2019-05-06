
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;

namespace AutomationSQLdm.Grooming_Modifications.TC_721952
{
    
    [TestModule("A99B8D48-8CE4-4DC1-8071-6850FC9AB5C2", ModuleType.UserCode, 1)]
    public class DeleteforMonitoredServerID :Base.BaseClass, ITestModule
    {
        
        public DeleteforMonitoredServerID()
        {
            
        }
        
         void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		//Steps.AddSQLServerInstance(Config.ServerOptions_CMWIN2016SQL17); //CMWIN2016SQL17
        		Steps.VerifyQueryDataCount(Config.Query_MonitoredSQLServers,"MonitoredSQLServers");
        		//Steps.DeleteSQLServerInstance(Config.ServerOptions_CMWIN2016SQL17); //CMWIN2016SQL17
        		Steps.VerifyInstanceIsDeleted("select * from AnalysisConfiguration where MonitoredServerID = 6","AnalysisConfiguration");
        		Common.UpdateStatus(1); // 1 : Pass
        	} 
        	catch (Exception ex)
        	{
        		Common.UpdateStatus(5); // 5 : fail
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }

       
    }
}
