﻿using System.Data;
using System.Data.SqlClient;
using InternalsViewer.Internals.Pages;

namespace InternalsViewer.Internals.TransactionLog
{
    public class LogMonitor
    {
        public static LogSequenceNumber StartMonitoring(string connectionString, string database)
        {
            Checkpoint(connectionString, database);

            BootPage bootPage = new BootPage(connectionString, database);

            return bootPage.CheckpointLsn;
        }

        public static DataTable StopMonitoring(string database, LogSequenceNumber startLsn, string connectionString)
        {
            DataTable logTable = DataAccess.GetDataTable(connectionString,
                                                         Properties.Resources.SQL_TransactionLog,
                                                         database,
                                                         "Transaction Log",
                                                         CommandType.Text,
                                                         new SqlParameter[] { new SqlParameter("begin", startLsn.ToDecimal()) });

            logTable.Columns.Add(new DataColumn("PageAddress", typeof(PageAddress)));

            foreach (DataRow row in logTable.Rows)
            {
                string pageAddress = row["PageId"].ToString();

                if (!string.IsNullOrEmpty(pageAddress))
                {
                    PageAddress page = PageAddress.Parse(row["PageId"].ToString());

                    row["PageAddress"] = page;
                }
            }

            return logTable;
        }

        private static void Checkpoint(string connectionString, string database)
        {
            DataAccess.ExecuteNonQuery(connectionString, Properties.Resources.SQL_Checkpoint, database, System.Data.CommandType.Text);
        }
    }
}
