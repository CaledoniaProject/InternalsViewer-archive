﻿using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace InternalsViewer.Internals
{
    /// <summary>
    /// General class for data access
    /// </summary>
    internal class DataAccess
    {
        /// <summary>
        /// Executes a given command and returns the value in the first row and column
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="command">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object GetScalar(string connectionString, string database, string command, CommandType commandType, SqlParameter[] parameters)
        {
            object returnObject;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = commandType;

                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                try
                {
                    conn.Open();

                    if (conn.Database != database)
                    {
                        conn.ChangeDatabase(database);
                    }

                    returnObject = cmd.ExecuteScalar();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return returnObject;
        }

        public static DataTable GetDataTable(string connectionString, string command, string database, string tableName, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable returnDataTable = new DataTable();
            returnDataTable.Locale = CultureInfo.InvariantCulture;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.CommandType = commandType;

                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                conn.Open();

                if (conn.Database != database)
                {
                    conn.ChangeDatabase(database);
                }

                da.Fill(returnDataTable);
            }

            returnDataTable.TableName = tableName;

            return returnDataTable;
        }

        internal static DataTable GetDataTable(string connectionString, string command, string database, string tableName, CommandType commandType)
        {
            return GetDataTable(connectionString, command, database, tableName, commandType, new SqlParameter[] { });
        }

        public static int ExecuteNonQuery(string connectionString, string command, string database, CommandType commandType, SqlParameter[] parameters)
        {
            SqlParameter returnParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.ReturnValue;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.CommandType = commandType;

                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                cmd.Parameters.Add(returnParam);

                try
                {
                    conn.Open();

                    if (conn.Database != database)
                    {
                        conn.ChangeDatabase(database);
                    }

                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return (int)(returnParam.Value ?? -1);

        }

        public static int ExecuteNonQuery(string connectionString, string command, string database, CommandType commandType)
        {
            return ExecuteNonQuery(connectionString, command, database, commandType, new SqlParameter[] { });
        }
    }
}
