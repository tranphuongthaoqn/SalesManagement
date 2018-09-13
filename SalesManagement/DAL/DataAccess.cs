﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        private static SqlConnection sqlCon;
        private static void moKetNoi()
        {
            string strCon = @"server=DESKTOP-279M9CB\THAOSON; database=SalesManagement; integrated security=true;";
            sqlCon = new SqlConnection(strCon);
            try
            {
                sqlCon.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static void dongKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        private void ExcuteNonQuery(string strSQL, CommandType cmdType, SqlParameter[] arrPr)
        {
            try
            {
                moKetNoi();
                SqlCommand cmd = new SqlCommand(strSQL, sqlCon);
                cmd.CommandType = cmdType;
                foreach (SqlParameter pr in arrPr)
                {
                    cmd.Parameters.Add(pr);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ExcuteDataTable(string strSQL, CommandType cmdType, SqlParameter[] arrPr)
        {
            DataTable dt = new DataTable();
            try
            {
                moKetNoi();
                SqlCommand cmd = new SqlCommand(strSQL, sqlCon);
                cmd.CommandType = cmdType;
                if (arrPr != null)
                {
                    foreach (SqlParameter pr in arrPr)
                    {
                        cmd.Parameters.Add(pr);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dongKetNoi();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public DataTable ExcuteDataTableList(string strSQL, CommandType cmdType)
        {
            DataTable dt = new DataTable();
            try
            {
                moKetNoi();
                SqlCommand cmd = new SqlCommand(strSQL, sqlCon);
                cmd.CommandType = cmdType;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dongKetNoi();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public static DataSet GetData(string strSQL, CommandType cmdType)
        {
            DataSet ds = new DataSet();
            try
            {
                moKetNoi();
                SqlCommand cmd = new SqlCommand(strSQL, sqlCon);
                cmd.CommandType = cmdType;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dongKetNoi();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable GetData(string procName, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
                cmd.Parameters.AddRange(para);
            cmd.Connection = sqlCon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            sqlCon.Open();
            da.Fill(dt);
            sqlCon.Close();
            return dt;
        }
        private static Hashtable parasCache = Hashtable.Synchronized(new Hashtable());

        public static void ExecuteNonQuery(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            string strCon = @"server=192.168.1.14\BASQL; database=PDA_InternalTest;
                            User id=pda.namtdn; Password=namtdn";
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(strCon);
            try
            {
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                cmdCommand.ExecuteNonQuery();
                cmdCommand.Parameters.Clear();
                if (connect.State == ConnectionState.Open) connect.Close();
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                    SqlConnection.ClearPool(connect);
                }
                throw ex;
            }
        }

        public static DataTable ExecuteData(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            string strCon = @"server=192.168.1.14\BASQL; database=PDA_InternalTest;
                            User id=pda.namtdn; Password=namtdn";
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(strCon);
            try
            {
                DataTable dattTopic = new DataTable();
                SqlDataAdapter dataTopic = new SqlDataAdapter(cmdCommand);
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                cmdCommand.ExecuteNonQuery();
                dataTopic.Fill(dattTopic);
                cmdCommand.Parameters.Clear();
                if (connect.State == ConnectionState.Open) connect.Close();
                return dattTopic;
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                    SqlConnection.ClearPool(connect);
                }
                throw ex;
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            string strCon = @"server=192.168.1.14\BASQL; database=PDA_InternalTest;
                            User id=pda.namtdn; Password=namtdn";
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(strCon);
            try
            {
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                SqlDataReader datrDataReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
                cmdCommand.Parameters.Clear();
                return datrDataReader;
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                    SqlConnection.ClearPool(connect);
                }
                throw ex;
            }
        }

        private static void PrepareCommand(SqlCommand cmdCommand, SqlConnection connConnection, SqlTransaction trasTransaction, CommandType cmdCommandType, string cmdCommandString, SqlParameter[] cmdParameters)
        {
            if (connConnection.State != ConnectionState.Open)
            {
                connConnection.Open();
            }
            cmdCommand.Connection = connConnection;
            cmdCommand.CommandText = cmdCommandString;
            if (trasTransaction != null)
            {
                cmdCommand.Transaction = trasTransaction;
            }

            cmdCommand.CommandType = cmdCommandType;
            if (cmdParameters != null)
            {
                foreach (SqlParameter para in cmdParameters)
                {
                    cmdCommand.Parameters.Add(para);
                }
            }
        }

        public static void PrepareCommand(SqlCommand cmdCommand, CommandType cmdCommandType, string cmdCommandString, SqlParameter[] cmdParameters)
        {
            cmdCommand.Parameters.Clear();
            cmdCommand.CommandType = cmdCommandType;
            cmdCommand.CommandText = cmdCommandString;
            if (cmdParameters != null)
                foreach (SqlParameter para in cmdParameters)
                    cmdCommand.Parameters.Add(para);
        }

        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParameters)
        {
            parasCache[cacheKey] = cmdParameters;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parasCache[cacheKey];

            if (cachedParms == null)
            {
                return null;
            }
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
            {
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();
            }
            return clonedParms;
        }
    }
}
