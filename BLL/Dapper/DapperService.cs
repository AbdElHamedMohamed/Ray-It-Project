using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dapper
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "MasterConnection";

        public DapperService(IConfiguration config)
        {
            _config = config;
        }


        public IEnumerable<TResult> GetNested<T1, T2, T3, TResult>(string sp, Func<T1, T2, T3, TResult> p, string s, CommandType commandType)
        {
            using IDbConnection db = new OracleConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T1, T2, T3, TResult>(sp, p, splitOn: s);
        }


        public IEnumerable<TResult> GetNested<T1, T2, TResult>(string sp, Func<T1, T2, TResult> p, string s, CommandType commandType)
        {
            using IDbConnection db = new OracleConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T1, T2, TResult>(sp, p, splitOn: s);
        }



        public async Task<int> Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {

            int result;
            using IDbConnection db = new OracleConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = await db.ExecuteAsync(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new OracleConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new OracleConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }




        public DbConnection GetDbconnection()
        {
            return new OracleConnection(_config.GetConnectionString(Connectionstring));
        }

        public void Dispose()
        {

        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new OracleConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new OracleConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }


    }
}
