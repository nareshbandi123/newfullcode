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
namespace AutomationSQLdm.OperatorSecurityRole.TC_T721994
{
    /// <summary>
    /// Description of VerifySnoozeAlertsForFewMinutesForWindowsUser.
    /// </summary>
    [TestModule("83B5BF4C-D31F-489C-9F5C-ED1AFB8EC463", ModuleType.UserCode, 1)]
    public class VerifySnoozeAlertsForFewMinutesForWindowsUser : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifySnoozeAlertsForFewMinutesForWindowsUser()
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
        	  Steps.EnterDomianUserName(Constants.NewWindowsUser);
        	  Steps.ClickNextButton();
        	  Steps.ClickOptionBtn_ViewDataAcknowledgwAlarm();
        	  Steps.ClickNextButton();
        	  Steps.SelectServers();
        	  Steps.ClickAddButton();
        	  Steps.ClickNextButton();
        	  Steps.ClickFinishButton();
        	  Steps.VerifyWindowsUserAdded();
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
