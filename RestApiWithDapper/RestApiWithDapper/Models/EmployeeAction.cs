using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithDapper.Models
{
    public class EmployeeAction 
    {
        private readonly IConfiguration Config; //create object of Iconfiguration interface
        
        public EmployeeAction(IConfiguration config)
        {
            Config = config; //set the Config object
        }
      
       

        /// <summary>
        /// This is a generic method used to get all records from the database, it takes three parameters storeprocedure name, dynamic parameters and name of connection string mentioned in the appsettings 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeprocedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public List<T> GetAll<T>(string storeprocedure, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(connectionString)))
            {
                return dbConnection.Query<T>(storeprocedure, parameters, commandType: CommandType.StoredProcedure).ToList(); //use query method in the IDbconnection of dapper to get all records
            }
        }

        /// <summary>
        /// This is a generic method used to get individual  record from the database, it takes three parameters storeprocedure name, dynamic parameters and name of connection string mentioned in the appsettings 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeprocedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public T Get<T>(string storeprocedure, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(connectionString)))
            {
                return dbConnection.Query<T>(storeprocedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); //use query method in the IDbconnection of dapper to get individual record
            }
        }

        /// <summary>
        /// This is a generic method used to insert or update records in the database, it takes three parameters storeprocedure name, dynamic parameters and name of connection string mentioned in the appsettings 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeprocedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public T InsertOrUpdate<T>(string storeprocedure, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(connectionString)))
            {
                return dbConnection.Query<T>(storeprocedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); //use query method in the IDbconnection of dapper to update or create record in the database
            }
        }

        /// <summary>
        /// This is a generic method used to delete the record from the database, it takes three parameters storeprocedure name, dynamic parameters and name of connection string mentioned in the appsettings 
        /// </summary>
        /// <param name="storeprocedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public int Delete(string storeprocedure, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(connectionString)))
            {
                return dbConnection.Execute(storeprocedure, parameters, commandType: CommandType.StoredProcedure); //use Excute method in the IDbconnection of dapper to delete the record
            }
        }
    }
}
