
using System;


namespace AutomationSQLdm.Configuration
{
 
    public static class Config 
    {
        public static string AppPath = System.Configuration.ConfigurationManager.AppSettings["APP_PATH"].ToString();
        
		public static int ProcessID;
		public static string TestCaseName;
		
		
		//Available Servers
		public const string ServerOptions_CMWIN2016S8 		= "CMWIN2016-S8";
		public const string ServerOptions_CMWIN2016SQL17 	= "CMWIN2016SQL17";
		public const string ServerOptions_TMSSQL2016 		= "T-MSSQL2016";
		//public const string ServerOptions_DEFAULTSERVER 	= "T-MSSQL2016";  //ForNavigations
		public const string ServerOptions_DEFAULTSERVER 	= "CMWIN2016-S8";  //ForNavigations
		
		
		//Available Queryyes
		public const string Query_DBFileStatistics 			= "Select * from DatabaseFileStatistics";
		public const string Query_DBSize		   			= "Select * from DatabaseSize";
		public const string Query_DBSizeDateTime   			= "Select * from DatabaseSizeDateTime";
		public const string Query_DiskDriveStatistics  		= "Select * from DiskDriveStatistics";
		public const string Query_TableGrowth   			= "Select * from TableGrowth";
		public const string Query_MonitoredSQLServers   	= "Select * from MonitoredSQLServers";
		public const string Query_AnalysisConfiguration   	= "Select * from AnalysisConfiguration";
		
		
		public const string Query_DBFileStatisticsAggregation 		= "Select * from DatabaseFileStatisticsAggregation";
		public const string Query_DBSizeAggregation		   			= "Select * from DatabaseSizeAggregation";
		public const string Query_DBSizeDateTimeAggregation   		= "Select * from DatabaseSizeDateTimeAggregation";
		public const string Query_DiskDriveStatisticsAggregation	= "Select * from DiskDriveStatisticsAggregation";
		public const string Query_TableGrowthAggregation 			= "Select * from TableGrowthAggregation";
		
		//Available Queryyes for Top Query Plans
		//delete from QueryMonitorStatistics
		public const string Query_DurationMilliseconds		= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by DurationMilliseconds DESC";
		public const string Query_LogicalDiskReads 			= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by Reads DESC";
		public const string Query_CPUUsage 					= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by CPUMilliseconds DESC";
		public const string Query_PhysicalDiskWrites		= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by Writes DESC";
		
		
		public static string WindowsUser = System.Configuration.ConfigurationManager.AppSettings["WindowsUser"].ToString();
		public static string WinUserPassword = System.Configuration.ConfigurationManager.AppSettings["WinUserPassword"].ToString();
		
		
    }
}
