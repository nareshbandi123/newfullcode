
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


namespace AutomationSQLdm.QueryPlan.TC_722069
{
    
    [TestModule("8AD4418D-28E0-4C10-BB72-C0138EFF7F8C", ModuleType.UserCode, 1)]
    public class Inputinvaliddataincollectqueryplanscountandverifychangescantbesaved :Base.BaseClass, ITestModule
    {
        
        public Inputinvaliddataincollectqueryplanscountandverifychangescantbesaved()
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
        		Steps.ClickOnFile();
        		Steps.SelectConnectRepoOption();
        		Steps.ClickOnConnect();
        		Steps.SelectServer(Config.ServerOptions_CMWIN2016S8);
        		Steps.ClickOnQueriesTab();
        		Steps.ClickOnSignatureMode();
        		Steps.CheckEnableQueryMonitor();
        		//Steps.VerifyQueryPlansStatus("enable");
        		//Steps.EnterTextInSelectTop("1");
        		//Steps.ClickOnOnInMSSP();
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
