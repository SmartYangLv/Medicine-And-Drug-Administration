using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAdministration.Model
{
    public class NotUniqueException : Exception { }
    public class SqlHelper
    {
        /// <summary>
        /// SQL命令
        /// </summary>
        private SqlCommand SqlCommand { get; set; }
        /// <summary>
        /// SQL参数
        /// </summary>
        private SqlParameter SqlParameter { get; set; }
        public SqlHelper NewCommand()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ToString ();
            this.SqlCommand =sqlConnection.CreateCommand();
            return this;
        }
        public SqlHelper NewCommand(string commandText)
        {
            this.NewCommand();
            return this.CommandText(commandText);
        }
        public SqlHelper CommandText(string commandText)
        {
            this.SqlCommand.CommandText = commandText;
            return this;
        }
        public SqlHelper IsStoreProcedure(bool isStoredProcedure=true)
        {
            this.SqlCommand.CommandType =isStoredProcedure ?CommandType .StoredProcedure:CommandType.Text ;
            return this;
        }
        public SqlHelper NewParameter(string parameterName)
        {
            this.SqlParameter = new SqlParameter();
            this.SqlParameter.ParameterName = parameterName;
            this.SqlCommand .Parameters .Add(this.SqlParameter);
            return this;
        }
        public SqlHelper NewParameter(string parameterName, object value) 
        { 
            this.NewParameter (parameterName);
            this.SqlParameter .Value =value ;
            return this;
        }
        public SqlHelper ParameterType(SqlDbType sqlDbType)
        {
            this.SqlParameter .SqlDbType = sqlDbType;
            return this;
        }
        public SqlHelper ParameterSize(int size)
        {
            this.SqlParameter .Size = size;
            return this;
        }
        public SqlHelper ParameterValue(object value)
        {
            this.SqlParameter.Value = value;
            return this;
        }
        public SqlHelper ParameterDirection(ParameterDirection parameterDirection)
        {
            this.SqlParameter .Direction = parameterDirection;
            return this;
        }
        public T GetScalar<T>()
        {
            object result = null;
            this.SqlCommand .Connection .Open ();
            result = this.SqlCommand.ExecuteScalar();
            this.SqlCommand .Connection .Close ();
            return (T)result;
        }
        public IDataReader GetReader()
        {
            this.SqlCommand.Connection.Open();
            SqlDataReader sqlDataReader = this.SqlCommand.ExecuteReader();
            return sqlDataReader;
        }
        public int NonQuery()
        {
            int rowAffected = 0;
            try
            {
                this.SqlCommand.Connection.Open();
                rowAffected = this.SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                if(sqlEx .Number == 2627)
                {
                    throw new NotUniqueException();
                }
                throw;
            }
            finally
            {
                this.SqlCommand.Connection.Close();
            }
            return rowAffected;
        }
    }
}
