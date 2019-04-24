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
using AutomationSQLdm.Base;
using AutomationSQLdm.Commons;

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721980
{
    /// <summary>
    /// Description of VerifyMaintenanceModeAfterSqlUserLogin.
    /// </summary>
    [TestModule("A58D8F56-E8CF-4170-91F8-1062234A3964", ModuleType.UserCode, 1)]
    public class VerifyMaintenanceModeAfterSqlUserLogin : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyMaintenanceModeAfterSqlUserLogin()
        {
            // Do not delete - a parameterless constructor is required!
        }

     	void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        	  Steps.ClickAdministration();
        	  Steps.ClickApplicationSecurity();
        	  Steps.ClickEnableSecurity();
        	  Steps.AcceptExceptionMessage();
        	  Steps.ClickToAddUsers();
        	  Steps.ClickNextButton();
        	  Steps.EnterDomianUserName(Constants.NewSqlUser);
        	  Steps.SelectSqlAuthentication();
        	  Steps.ClickNextButton();
        	  Steps.ClickOptionBtn_ViewDataAcknowledgwAlarm();
        	  Steps.ClickNextButton();
        	  Steps.SelectServers();
        	  Steps.ClickAddButton();
        	  Steps.ClickNextButton();
        	  Steps.ClickFinishButton();
        	  Steps.VerifySqlUserAdded();
        	  
        	  //Login DM with SQL
        	  Steps.ConnectDMRepo();
        	   
        	  AutomationSQLdm.Grooming_Modifications.Steps.ClickOnTools();
        	  Steps.SelectSnoozeAlertMenuItem(); // will create  for maintaince mode
        	  Steps.SelectMaintainceModeMenuItem();
//        	  AutomationSQLdm.Grooming_Modifications.Steps.ClickOnTools(); //uncomment it will required here.
//        	  Steps.VerifySnoozeAlertApplied(); //  will create  for maintaince mode
        	
        	// will delete the below code , kept just for reference
//			  Steps.ClickServersInLeftPane();
//			  Steps.RightClickMonitoredServer();
//        	  Steps.ClickMaintainceModeContextMenu();
        	  Steps.VerifyMaintainceModeContextMenuItems();
//        	  Steps.EnableMaintainceMode();
//        	  Steps.VerifyMaintainceModeIsChanged();
        	} 
        	catch (Exception ex)
        	{
        		Validate.Fail(ex.Message);
        	}
        	return true;
        }
        
      
    }
}
