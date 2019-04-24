
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
using AutomationSQLdm.Extensions;
using AutomationSQLdm.Configuration;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using AutomationSQLdm.DataBaseOperations;

namespace AutomationSQLdm.QueryPlan
{
   
    [TestModule("3DB530C4-EC44-47A4-A9B3-3A46D548F489", ModuleType.UserCode, 1)]
    public static class Steps 
    {
       
        public static QueryPlanRepo repo = QueryPlanRepo.Instance;
	//	public const string GROOMING_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='menuToolsGrooming']";
		public const string FILECONNECT_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='menuFileConnect']";
		
        public static void ClickOnFile()
		{
			try 
				{
					repo.SQLdmDesktop.FileInfo.WaitForExists(new Duration(1000000));
					repo.SQLdmDesktop.File.Click();
					Reports.ReportLog("ClickOnFile", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				} 
			catch (Exception ex)
				{
				throw new Exception("Failed : ClickOnFile :" + ex.Message);
				}
		}
        
        public static void SelectConnectRepoOption()
		{ 
			try
				{
					Ranorex.MenuItem fileMenuItem = FILECONNECT_MENU;
					if(fileMenuItem != null) fileMenuItem.ClickThis();
					Reports.ReportLog("SelectConnectRepoOption", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectConnectRepoOption :" + ex.Message);
			}
		}
        
        public static void ClickOnConnect()
		{
			try 
				{
					repo.RepoConsoleDialog.SelfInfo.WaitForExists(new Duration(1000000));
					repo.RepoConsoleDialog.btnRCDConnectInfo.WaitForItemExists(1000000);
					repo.RepoConsoleDialog.btnRCDConnect.ClickThis();
					
					Reports.ReportLog("Click On Connect", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				} 
			catch (Exception ex)
				{
				throw new Exception("Failed : ClickOnConnect :" + ex.Message);
				}
		}
        
        public static void SelectServer(string serverName)
			{
				try 
				{
					 repo.SQLdmDesktop.AllServersInfo.WaitForItemExists(120000);
					 TreeItem serveritem = repo.SQLdmDesktop.AllServers.GetChildItem(serverName);
					 
					if(serveritem != null)
					{
						serveritem.ClickThis();
						Reports.ReportLog("Successfully Selected Required Server : " + serverName, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Required Server is Not Available to Select", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
						
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : SelectServer :" + ex.Message);
				}
			}
        
         public static void ClickOnQueriesTab()
			{
				try 
				{
					
				    repo.SQLdmDesktop.tabQueriesInfo.WaitForExists(new Duration(1000000));
				    repo.SQLdmDesktop.tabQueries.Click();
				    Reports.ReportLog("Successfully Clicked On Queries Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnQueriesTab :" + ex.Message);
				}
			}
         public static void ClickOnSignatureMode()
			{
				try 
				{
					
				    repo.SQLdmDesktop.QueriesTab.rgQUESignatureModeInfo.WaitForExists(new Duration(1000000));
				    repo.SQLdmDesktop.QueriesTab.rgQUESignatureMode.Click();
				    Reports.ReportLog("Successfully Clicked On Signature Mode", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnSignatureMode :" + ex.Message);
				}
			}
         
         public static void CheckEnableQueryMonitor()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.SelfInfo.WaitForExists(new Duration(1000000));
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitorInfo.WaitForExists(1000000);
					
					if(!repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked)
					{
						repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked = true;
						Reports.ReportLog("Successfully Checked Enable Query Monitor", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Enable Query Monitor is in Checked Status", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
						
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : CheckEnableQueryMonitor :" + ex.Message);
				}
			}
         
         public static void UnCheckEnableQueryMonitor()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.SelfInfo.WaitForExists(new Duration(1000000));
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitorInfo.WaitForExists(1000000);
					
					if(repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked)
					{
						repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked = false;
						Reports.ReportLog("Successfully UnChecked Enable Query Monitor", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Enable Query Monitor is in UnChecked Status", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
						
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : UnCheckEnableQueryMonitor :" + ex.Message);
				}
			}
         
         
          public static void ClickOnOkInMSSP()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.btnMSSPOkInfo.WaitForExists(new Duration(1000000));
					repo.MonitoredSQLServerProperties.btnMSSPOk.ClickThis();
				    
				    Reports.ReportLog("Successfully Clicked On Ok button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnOkInMSSP :" + ex.Message);
				}
			}
         
          public static void ClickOnCancelInMSSP()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.btnMSSPCancelInfo.WaitForExists(new Duration(1000000));
					repo.MonitoredSQLServerProperties.btnMSSPCancel.ClickThis();
				    
				    Reports.ReportLog("Successfully Clicked On Cancel button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnCancelInMSSP :" + ex.Message);
				}
			}
         
         //------------------------------------------------------------------------------------------------------
		
    }
}
