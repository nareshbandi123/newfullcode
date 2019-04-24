using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Text;

using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.Extensions;
using Ranorex;
using Ranorex.Core;
using System.Threading;

namespace AutomationSQLdm.OperatorSecurityRole
{
	/// <summary>
	/// Description of Steps.
	/// </summary>
	public static class Steps
	{
		public static OperatorSecurityRoleRepo repo = OperatorSecurityRoleRepo.Instance;
		public const string SNOOZEALERT_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='snoozeAllAlertsToolMenu']";
		public const string MAINTAINANCEMODE_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='MaintenanceModeButtonKey']";
		public static int rownum = 0;
		
		public static void SelectSnoozeAlertMenuItem()
		{ 
			try
			{
				Ranorex.MenuItem snoozeMenuItem = SNOOZEALERT_MENU;
				if(snoozeMenuItem != null) 
				{	
					snoozeMenuItem.ClickThis();
					Reports.ReportLog("Selected SnoozeAlert MenuItem", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				Reports.ReportLog("MenuItem SnoozeAlert not Selected", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSnoozeAlertMenuItem :" + ex.Message);
			}
		}
		
		public static void SelectMaintainceModeMenuItem()
		{ 
			try
			{
				Ranorex.MenuItem snoozeMenuItem = MAINTAINANCEMODE_MENU;
				if(snoozeMenuItem != null) 
				{	
					snoozeMenuItem.ClickThis();
					Reports.ReportLog("Selected SelectMaintainceModeMenuItem MenuItem", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				Reports.ReportLog("MenuItem SelectMaintainceModeMenuItem not Selected", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMaintainceModeMenuItem :" + ex.Message);
			}
		}
		
		
		public static void RightClickMonitoredServer()
		{ 
			try
			{
				var allServers = repo.Application.AllServers;
				Report.Info(allServers.Items.Count.ToString());
				if(allServers.Items.Count>=1)
				{
					allServers.Items[0].Click(System.Windows.Forms.MouseButtons.Right);
					Reports.ReportLog("Clicked Server ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickMonitoredServer :" + ex.Message);
			}
		}
		
		public static void RightClickAllServer()
		{ 
			try
			{
				var allServers = repo.Application.AllServers;
				Report.Info(allServers.Items.Count.ToString());
				allServers.Click(System.Windows.Forms.MouseButtons.Right);
				Reports.ReportLog("Right Clicked All Server ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickMonitoredServer :" + ex.Message);
			}
		}
		
		public static void ClickServersInLeftPane()
		{ 
			try
			{
				repo.Application.Servers.ClickThis();
				Reports.ReportLog("Clicked Servers in Left Pane ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickServersInLeftPane :" + ex.Message);
			}
		}
		
		public static void ClickSnoozeAlertContextMenu()
		{ 
			try
			{
				repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.ClickThis();
				Reports.ReportLog("Snooze Server Context Menu Clicked  ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SnoozeServer :" + ex.Message);
			}
		}
		
		public static void ClickMaintainceModeContextMenu()
		{ 
			try
			{
				repo.SQLdmDesktopClient.MaintenanceMode.ClickThis();
				Reports.ReportLog("Maintenance Mode Context Menu Clicked  ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickMaintainceModeContextMenu :" + ex.Message);
			}
		}
		
		public static void EnableMaintainceMode()
		{ 
			try
			{
				if(repo.SQLdmDesktopClient.EnableContextMenuItem.Enabled)
				{
					repo.SQLdmDesktopClient.EnableContextMenuItem.Click();
					Reports.ReportLog("Maintenance Mode is Enabled ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else if(repo.SQLdmDesktopClient.DisableContextMenuItem.Enabled)
				{
					repo.SQLdmDesktopClient.DisableContextMenuItem.Click();
					Reports.ReportLog("Maintenance Mode is Disabled ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Maintenance Mode is not applied", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("Maintenance Mode is not applied");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnableMaintainceMode :" + ex.Message);
			}
		}
		
		public static void VerifyMaintainceModeIsChanged()
		{ 
			try
			{
				Thread.Sleep(120000);
				RightClickMonitoredServer();
        	    ClickMaintainceModeContextMenu();
        	    
        	    if(repo.SQLdmDesktopClient.EnableContextMenuItem.Enabled)
					Reports.ReportLog("Maintaince Mode Is Enabled successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
        	    else if(repo.SQLdmDesktopClient.DisableContextMenuItem.Enabled)
				{
					Reports.ReportLog("Maintaince Mode is Disabled successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
        	    else
        	    {
        	    	Reports.ReportLog("Maintaince Mode is Disabled successfully. ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("Maintaince Mode Not applied successfully.");
        	    }
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMaintainceModeIsChanged :" + ex.Message);
			}
		}
		
		public static void VerifyMaintainceModeContextMenuItems()
		{ 
			try
			{	
				if(!repo.SQLdmDesktopClient.EnableContextMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.DisableContextMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.ScheduleConextMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				
					
				Reports.ReportLog("Verified Maintenance Mode Items: Enabled, Disables and Scheduled are present ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMaintainceModeContextMenuItems :" + ex.Message);
			}
		}
		
		public static void Cell_test()
		{ 
			var cell = Host.Local.FindSingle<Ranorex.Cell>(@"/form[@title~'^Idera\ SQL\ diagnostic\ mana']/statusbar[@automationid='statusBar']//table[@accessiblename~'^\ \ \ \ \ \ \ System\ logins,\ whi']//cell[@accessiblevalue='sa1']");
            cell.DoubleClick();
		}
		
		public static void VerifyMaintainceModeMenuItems_test()
		{ 
            var menuitems = Host.Local.Find<Ranorex.MenuItem>("/contextmenu[@win32ownerwindowlevel='2']/menuitem");
          
			if (menuitems != null) {
				foreach (var mitem in menuitems)  
			    {
					//if(mitem.Text.Equals(""))
			        Report.Info(mitem.Text + mitem.Enabled);           
			    }    
				Report.Info(menuitems.Count.ToString());
			}
			
		}
		
		public static void VerifyMaintainceModeMenuItems()
		{ 
			try
			{	
				if(!repo.SQLdmDesktopClient.MaintenanceModeEnableMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.MaintenanceModeDisableMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.MaintenanceModeScheduleMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				
					
				Reports.ReportLog("Verified Maintenance Mode Items: Enabled, Disables and Scheduled are present ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMaintainceModeContextMenuItems :" + ex.Message);
			}
		}
		
		public static void VerifyServerSnoozed()
		{ 
			try
			{
				RightClickMonitoredServer();
				
				if(!repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.Enabled) 
					Reports.ReportLog("SnoozeAlert is applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
				{
					Reports.ReportLog("SnoozeAlert Not applied successfully. ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					Validate.Fail("SnoozeAlert Not applied successfully.");
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyServerSnoozed :" + ex.Message);
			}
		}
		
		public static void SetSnoozeAlertTime()
		{ 
			try
			{
				repo.SnoozeAlertsDialog.SnooozeAlertTime.TextValue = "10";
				repo.SnoozeAlertsDialog.OkButton.ClickThis();
				Reports.ReportLog("SnoozeAlert Time applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetSnoozeAlertTime :" + ex.Message);
			}
		}
		
		public static void VerifySnoozeAlertApplied()
		{ 
			try
			{
				Ranorex.MenuItem snoozeMenuItem = SNOOZEALERT_MENU;
				Report.Info(snoozeMenuItem.Enabled.ToString());
				if(!snoozeMenuItem.Enabled) 
					Reports.ReportLog("SnoozeAlert is applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
				{
					Reports.ReportLog("SnoozeAlert Not applied successfully. ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					Validate.Fail("SnoozeAlert Not applied successfully.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifySnoozeAlertApplied :" + ex.Message);
			}
		}
		
		public static void ClickAdministration()
		{
			try
			{
				repo.Application.btnAdministrationInfo.WaitForExists(new Duration(100000));
				repo.Application.btnAdministration.ClickThis();
				Reports.ReportLog("Clicked Administration button", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickAdministration : " + ex.Message);
			}
		}
		
		public static void ClickApplicationSecurity()
		{
			try
			{
				//repo.Application.ApplicationSecurityInfo.WaitForExists(new Duration(100000));
				repo.Application.ApplicationSecurity.Click();
				Reports.ReportLog("Clicked Application Security", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickApplicationSecurity : " + ex.Message);
			}
		}
		
		public static void ClickEnableSecurity()
		{
			try
			{
				//repo.Application.EnableSecurityInfo.WaitForExists(new Duration(100000));
				if(repo.Application.EnableSecurityInfo.Exists())
				{
					repo.Application.EnableSecurity.ClickThis();
					Reports.ReportLog("Clicked Enabled Security", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
					Reports.ReportLog("Enabled Security link not exists", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickEnableSecurity : " + ex.Message);
			}
		}

		public static void AcceptExceptionMessage()
		{
			try
			{
				if(repo.ExceptionForm.SelfInfo.Exists())
				{
					repo.ExceptionForm.btnYes.ClickThis();
					Reports.ReportLog("Clicked Yes button on Exception Alert", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
					Reports.ReportLog("Exception Message popup does not exists", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : AcceptExceptionMessage : " + ex.Message);
			}
		}
		
		public static void ClickToAddUsers()
		{
			try
			{
				repo.Application.btnAddUsers.ClickThis();
				Reports.ReportLog("Clicked Add Users", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickToAddUsers : " + ex.Message);
			}
		}
		
		public static void ClickNextButton()
		{
			try
			{
				//repo.AddPermissionWizard.btnNextInfo.WaitForExists(new Duration(500));				
				repo.AddPermissionWizard.btnNext.ClickThis();
				Reports.ReportLog("Clicked Next Button", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickNextButton : " + ex.Message);
			}
		}
	
		public static void EnterDomianUserName(string domainUserName)
		{
			try
			{
				//repo.AddPermissionWizard.txtUserNameInfo.WaitForExists(new Duration(500));				
				repo.AddPermissionWizard.txtUserName.PressKeys(domainUserName);
				Reports.ReportLog("Entered DomianUserName", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterDomianUserName : " + ex.Message);
			}
		}
		
		public static void SelectSqlAuthentication()
		{
			try
			{
				Ranorex.ComboBox combobox = repo.AddPermissionWizard.ComboBoxUserPageCmbBxAuthentication;
				combobox.Click();
				ListItem lst_userItem = combobox.FindSingle<ListItem>("/list/listitem[@text='SQL Server Authentication']");
				lst_userItem.Focus();  
				lst_userItem.Click(); 
				Reports.ReportLog("SQL Server Authentication Selected ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectAuthenticationType : " + ex.Message);
			}
		}
		
		public static void ClickOptionBtn_ViewDataAcknowledgwAlarm()
		{
			try
			{
				//repo.AddPermissionWizard.ViewDataAcknowledgwAlarmInfo.WaitForExists(new Duration(500));
				repo.AddPermissionWizard.ViewDataAcknowledgwAlarm.Click();
				Reports.ReportLog("Selected Option ViewDataAcknowledgwAlarm ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOptionBtn_ViewDataAcknowledgwAlarm : " + ex.Message);
			}
		}
		
		public static void SelectServers()
		{
			try
			{
				Ranorex.List serversLists= null;
				if(repo.AddPermissionWizard.AvailableServersInfo.Exists())
				{
					serversLists = repo.AddPermissionWizard.AvailableServers;
					if(serversLists.Children.Count >= 1)
					{
						//Report.Info("serversLists.Items[0]: " + serversLists.Items[0]);
						//serversLists.Children[0].Click();
						serversLists.Items[0].Click();
						Reports.ReportLog("Selected Server", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("No Servers Available in Server List : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
				else
				{
					Reports.ReportLog("Available Server Dialog not exists : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOptionBtn_ViewDataAcknowledgwAlarm : " + ex.Message);
			}
		}
		
		public static void ClickAddButton()
		{
			try
			{
				//repo.AddPermissionWizard.ViewDataAcknowledgwAlarmInfo.WaitForExists(new Duration(500));
				repo.AddPermissionWizard.ButtonAdd.Click();
				Reports.ReportLog("Clicked Add button to Add Server", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickAddButton : " + ex.Message);
			}
		}
		
		public static void ClickFinishButton()
		{
			try
			{
				//repo.AddPermissionWizard.ViewDataAcknowledgwAlarmInfo.WaitForExists(new Duration(500));
				repo.AddPermissionWizard.ButtonFinish.Click();
				Reports.ReportLog("Clicked Finish Button", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickFinishButton : " + ex.Message);
			}
		}
		
		public static void VerifyWindowsUserAdded()
		{
			try
			{
				if(repo.Application.NewWindowsUserAddedInfo.Exists())
				{
					Reports.ReportLog("New User Added Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("New User not Added : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("New User not Added Successfully");
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyWindowsUserAdded : " + ex.Message);
			}
		}
		
		public static void VerifyUserAdded(string userType)
		{
			try
			{
				string user = null;
				if(userType.ToLower().Equals(Constants.NewSqlUser.ToLower()))
					user = Constants.NewSqlUser;
				else
					user = Constants.NewWindowsUser;
				
				var cell = Host.Local.FindSingle<Ranorex.Cell>(@"/form[@title~'^Idera\ SQL\ diagnostic\ mana']/statusbar[@automationid='statusBar']//table[@accessiblename~'^\ \ \ \ \ \ \ System\ logins,\ whi']//cell[@accessiblevalue='"+ user +"']");

				if(cell != null)
				{
					cell.Click();
					Reports.ReportLog("New User Added Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("New User not Added : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("New User not Added Successfully");
				}
			
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifySqlUserAdded : " + ex.Message);
			}
		}
		
		public static void VerifySqlUserAdded()
		{
			try
			{
				if(repo.NewSqlUserAddedInfo.Exists())
				{
					Reports.ReportLog("New User Added Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("New User not Added : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("New User not Added Successfully");
				}
			
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifySqlUserAdded : " + ex.Message);
			}
		}

		public static void EditUserInUserTable(string userType)
		{
			try
			{
				Ranorex.Cell cellUser= null;
				if (userType.ToLower() == "sqluser")
					cellUser = repo.Application.TableSystemLoginsWhichBelong.FindSingle("//cell[@accessiblevalue='"+ Constants.NewSqlUser +"']");
				else
					cellUser = repo.Application.TableSystemLoginsWhichBelong.FindSingle("//cell[@accessiblevalue='"+ Constants.NewWindowsUser +"']");
				cellUser.MoveTo();
				//Thread.Sleep(2000);
				cellUser.Click();
				//Thread.Sleep(2000);
				cellUser.DoubleClick();
				Reports.ReportLog("Opened User in Edit mode Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditUserInUserTable : " + ex.Message);
			}
		}
		
		public static void ChangePermission(string userType)
		{
			try
			{
				EditUserInUserTable(userType);
				repo.PermissionPropertyDialog.RadioButtonGeneralRdBtnAdministrator.MoveTo();
				repo.PermissionPropertyDialog.RadioButtonGeneralRdBtnAdministrator.Click();
				repo.PermissionPropertyDialog.ButtonBtnOK.MoveTo();
				repo.PermissionPropertyDialog.ButtonBtnOK.ClickThis();
				Reports.ReportLog("Permission Changed to Administrator Powers in Sql DM" , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ChangePermission : " + ex.Message);
			}
		}
		
		
		
		public static void VerifyPermissionChanged()
		{
			bool IsFound = false;
			try
			{
				var tableSystemLoginsWhichBelong = repo.Application.TableSystemLoginsWhichBelong;
				foreach(var row in tableSystemLoginsWhichBelong.Rows)
				{
					if(row.Cells[3].Text.ToLower().Equals(Constants.NewSqlUser.ToLower()))
					{
						if(row.Cells[5].Text.ToLower().Equals(Constants.strAdministrator.ToLower()))
						{
							IsFound = true;
							break;
						}
					}
				}
				if(IsFound)
					Reports.ReportLog("Permission Changed to Administrator Powers in Sql DM " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				else
					Validate.Fail("Permission Not Changed to Administrator Powers in Sql DM");
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ChangePermission : " + ex.Message);
			}
		}
		
//		public static void VerifyPermissionChanged()
//		{
//			try
//			{
//				
//				repo.PermissionPropertiesSIMPSONSAdminis.AdministratorPowersInSQLDiagnosticM.Click();
//				repo.PermissionPropertiesSIMPSONSAdminis.ButtonOK.ClickThis();
//				Reports.ReportLog("Permission Changed to 'Administrator Powers in Sql DM' " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//			}
//			catch(Exception ex)
//			{
//				throw new Exception("Failed : ChangePermission : " + ex.Message);
//			}
//		}
		
		
			
		public static void VerifyViewDataAcknowledgwAlarmIsSelected(string userType)
		{
			try
			{
				//repo.Application.NewWindowsUserAdded.DoubleClick();
				if(userType.Equals("WindowsUser")) 
					repo.Application.NewWindowsUserAdded.DoubleClick();
				else 
					repo.NewSqlUserAdded.DoubleClick();
				if(repo.PermissionPropertyDialog.ViewDataAcknowledgwAlarm.Checked)
				{
					Reports.ReportLog("ViewDataAcknowledgwAlarm Option is Selected " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("ViewDataAcknowledgwAlarm Option Not Selected : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("ViewDataAcknowledgwAlarm Option Not Selected");
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyUserAdded : " + ex.Message);
			}
		}
		
		public static void ClickCancelPermissionProperties()
		{
			try
			{
				repo.PermissionPropertyDialog.btnCancel.ClickThis();
				Reports.ReportLog("Clicked Cancel Permission Properties " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyUserAdded : " + ex.Message);
			}
		}
		
		public static void ClickWindowsUserToDelete()
		{
			try
			{
				repo.Application.NewWindowsUserAdded.Click();
				Reports.ReportLog("Clicked New WindowsUser Added " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickWindowsUserAdded : " + ex.Message);
			}
		}
		
		public static void ClickSqlUserToDelete()
		{
			try
			{
				repo.NewSqlUserAdded.Click();
				Reports.ReportLog("Clicked New SqlUser Added " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickSqlUserAdded : " + ex.Message);
			}
		}
		
		public static void DeleteAddedUser()
		{
			try
			{
				repo.Application.btnDelete.Click();
				repo.ExceptionForm.btnYes.Click();
				Reports.ReportLog("New User Deleted Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DeleteAddedUser : " + ex.Message);
			}
		}
		
		public static void ConnectDMRepo()
		{
			try
			{
				repo.Application.File.Click();
				Reports.ReportLog("Clicked File Menu Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.SQLdmDesktopClient.ConnectToSQLDMRepository.Click();
				Reports.ReportLog("Clicked Menuitem ConnectToSQLDMRepository Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				Ranorex.ComboBox combobox = repo.RepositoryConnectionDialog.AuthenticationDropDownList;
				combobox.Click();
				ListItem lst_userItem = combobox.FindSingle<ListItem>("/list/listitem[@text='SQL Server Authentication']");
				lst_userItem.Focus();  
				lst_userItem.Click(); 
				Reports.ReportLog("SQL Server Authentication Selected ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.RepositoryConnectionDialog.Username.PressKeys(Constants.SqlSystemUser);
				Reports.ReportLog("Username : " + Constants.NewSqlUser + "Entered Successfully  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				repo.RepositoryConnectionDialog.Password.PressKeys(Constants.SqlSystemUserPassword);
				Reports.ReportLog("Passsword Entered Successfully  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.RepositoryConnectionDialog.ConnectButton.ClickThis();
				Reports.ReportLog("Clicked Connect Button Successfully !  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				if(repo.Application.CaptionText.TextValue.Contains(Constants.SQLdmRepository))
					Reports.ReportLog("Connected to SQLdmRepository Successfully !  "   , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				else
				{
					Reports.ReportLog("Failed to connect to SQLdmRepository " , Reports.SQLdmReportLevel.Fail, null, Configuration.Config.TestCaseName);
					throw new Exception("Failed to connect to SQLdmRepository ");
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ConnectDMRepo : " + ex.Message);
			}
		}
		
		
		
		public static void ClickCntextMenuItem(string textValue)
		{ 
			try
			{	
				//var sQLdmDesktopClient = repo.SQLdmDesktopClient;
				//bool isFound = false;
				repo.SQLdmDesktopClient.SelfInfo.WaitForItemExists(2000);
				//repo.SQLdmDesktopClient.MaintenanceModeInfo.WaitForItemExists(2000);
				Ranorex.ContextMenu contextMenuItems = @".//contextmenu[@processname='SQLdmDesktopClient']";
				if(contextMenuItems != null)
				{
					
				}
				
//				Report.Info(contextMenuItems.Children.Count.ToString());
//				Report.Info(contextMenuItems.Children[0].ToString());
//				Ranorex.MenuItem mi = null;
//				//Report.Info(contextMenuItems.Checked.Count.ToString());
//				//repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.ClickThis();
//				foreach(Ranorex.Adapter item in contextMenuItems.Children)
//				{
//					
//   Ranorex.Separator sep = item.As<Ranorex.Separator>();  
//    if (sep != null)  
//        Report.Info("Seperator!");  
//    
//					mi = item.As<Ranorex.MenuItem>();
//					 
//					if(mi.Text.Contains(textValue))
//					{
//						isFound = true; break;
//					}
//				}
//				
//				if(isFound)
//				{
//					mi.ClickThis();
//					Reports.ReportLog("Context Menu '" +  textValue + "' Clicked ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
//				}
//				else
//					Reports.ReportLog("Context Menu '" +  textValue + "' does not exists ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
//				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SnoozeServer :" + ex.Message);
			}
		}
		
	}
}
