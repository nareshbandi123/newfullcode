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

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721992
{
    /// <summary>
    /// Description of VerifySnoozeAlertsForFewMinutesForSqlUser.
    /// </summary>
    [TestModule("C0223962-F997-4C6F-B6C0-24CB8014DABB", ModuleType.UserCode, 1)]
    public class VerifySnoozeAlertsForFewMinutesForSqlUser : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifySnoozeAlertsForFewMinutesForSqlUser()
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
			  AutomationSQLdm.Grooming_Modifications.Steps.ClickOnTools();
        	  Steps.SelectSnoozeAlertMenuItem();
        	  Steps.SetSnoozeAlertTime();
        	  AutomationSQLdm.Grooming_Modifications.Steps.ClickOnTools();
        	  Steps.VerifySnoozeAlertApplied();
        	  Common.UpdateStatus(1); // 1 : Pass
        	} 
        	catch (Exception ex)
        	{
        		Common.UpdateStatus(5); // 5 : fail
        		Validate.Fail(ex.Message);
        	}
        	return true;
        }
        
      
    }
}
