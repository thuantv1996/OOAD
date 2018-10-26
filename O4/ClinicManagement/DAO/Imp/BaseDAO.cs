using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DAO.Imp
{
    public class BaseDAO
    {
        /// <summary>
        /// Insert một Object Entity xuống Database
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <param name="Entity">Object entity</param>
        /// <param name="db">Database</param>
        /// <param name="MessageError">List Error</param>
        /// <returns>Result Execute</returns>
        public string Insert<T>(T Entity, DbContext db, out List<string> MessageError) where T : class
        {
            MessageError = null;
            try
            {
                // Lấy table T từ Database
                DbSet<T> Table = db.Set<T>();
                // Thêm Object vào Table
                Table.Add(Entity);
                // Lưu xữ lý
                db.SaveChanges();
                // Return success
                return DAO.Com.DAOConstant.RES_SUC;
            }
            catch (Exception e)
            {
                // Tạo danh sách MessageError
                MessageError = new List<string>();
                // Thêm thông tin lỗi
                MessageError.Add(DAO.Com.DAOUtils.GetErrorFromException(e));
                // Return fail
                return DAO.Com.DAOConstant.RES_FAI;
            }

        }

        /// <summary>
        /// Upfate một Object Entity
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <param name="Entity">Object entity</param>
        /// <param name="db">Database</param>
        /// <param name="MessageError">List Error</param>
        /// <returns>Result Execute</returns>
        public string Update<T>(T Entity, DbContext db, out List<string> MessageError) where T : class
        {
            MessageError = null;
            try
            {
                // Lấy Table T từ Database
                DbSet<T> Table = db.Set<T>();
                // Tìm kiếm đối tượng Entity old
                // Hàm GetKeys trả về mảng Object các Key value của Entity
                T UpdateObject = Table.Find(GetKeys<T>(Entity, db));
                // Nếu Không tìm thấy đối tượng
                if (UpdateObject == null)
                {
                    // Tạo mới MessageError
                    MessageError = new List<string>();
                    // Thông báo Mã lỗi
                    MessageError.Add(DAO.Com.DAOMessage.MES_DAO_001);
                    // Return fail
                    return DAO.Com.DAOConstant.RES_FAI;
                }
                // Nếu tìm thấy đối tượng
                // Sao chép giá trị các thuộc tính
                db.Entry(UpdateObject).CurrentValues.SetValues(Entity);
                // Lưu xữ lý
                db.SaveChanges();
                // Return success
                return DAO.Com.DAOConstant.RES_SUC;
            }
            catch (Exception e)
            {
                // Tạo danh sách MessageError
                MessageError = new List<string>();
                // Thêm thông tin lỗi
                MessageError.Add(DAO.Com.DAOUtils.GetErrorFromException(e));
                // Return fail
                return DAO.Com.DAOConstant.RES_FAI;
            }
        }

        /// <summary>
        /// Delete một Object Entity trong Database
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <param name="Entity">Object entity</param>
        /// <param name="db">Database</param>
        /// <param name="MessageError">List Error</param>
        /// <returns>Result Execute</returns>
        public string Delete<T>(T Entity, DbContext db, out List<string> MessageError) where T : class
        {
            MessageError = null;
            try
            {
                // Lấy Table T từ Database
                DbSet<T> Table = db.Set<T>();
                // Tìm kiếm đối tượng Entity old
                // Hàm GetKeys trả về mảng Object các Key value của Entity
                T DeleteObject = Table.Find(GetKeys<T>(Entity, db));
                // Nếu Không tìm thấy đối tượng
                if (DeleteObject == null)
                {
                    // Tạo mới MessageError
                    MessageError = new List<string>();
                    // Thông báo Mã lỗi
                    MessageError.Add(DAO.Com.DAOMessage.MES_DAO_001);
                    // Return fail
                    return DAO.Com.DAOConstant.RES_FAI;
                }
                // Nếu tìm thấy đối tượng
                // Xóa đối tượng đó trong Table
                Table.Remove(DeleteObject);
                // Lưu xữ lý
                db.SaveChanges();
                // Return success
                return DAO.Com.DAOConstant.RES_SUC;
            }
            catch (Exception e)
            {
                // Tạo danh sách MessageError
                MessageError = new List<string>();
                // Thêm thông tin lỗi
                MessageError.Add(DAO.Com.DAOUtils.GetErrorFromException(e));
                // Return fail
                return DAO.Com.DAOConstant.RES_FAI;
            }
        }

        /// <summary>
        /// Select một danh sách Object từ Database
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="db">Database</param>
        /// <param name="Result">List Result</param>
        /// <param name="MessageError">List Error</param>
        /// <returns>Result Execute</returns>
        public string Select<T>(DbContext db, out List<T> Result, out List<string> MessageError) where T : class
        {
            MessageError = null;
            try
            {
                // Lấy Table T từ Database
                DbSet<T> Table = db.Set<T>();
                // Tạo mới danh sách kết quả trả về
                Result = new List<T>();
                // Lấy tất cả các record trong Table
                Result = Table.ToList<T>();
                // Return success
                return DAO.Com.DAOConstant.RES_SUC;
            }
            catch (Exception e)
            {
                // Đặt kết quả trả về là null
                Result = null;
                // Tạo danh sách MessageError
                MessageError = new List<string>();
                // Thêm thông tin lỗi
                MessageError.Add(DAO.Com.DAOUtils.GetErrorFromException(e));
                // Return fail
                return DAO.Com.DAOConstant.RES_FAI;
            }
        }

        /// <summary>
        /// Select một danh sách Object từ Database với mã Linq Expression
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="db">Database</param>
        /// <param name="LinqSelector">Linq Expression</param>
        /// <param name="Result">List Result</param>
        /// <param name="MessageError">List Error</param>
        /// <returns>Result Execute</returns>
        public string Select<T>(DbContext db, Expression<Func<T, bool>> LinqSelector,
                                out List<T> Result, out List<string> MessageError) where T : class
        {
            MessageError = null;

            try
            {
                // Lấy Table T từ Database
                DbSet<T> Table = db.Set<T>();
                // Tạo mới danh sách kết quả trả về
                Result = new List<T>();
                // Lấy tất cả các record trong Table với d9eiu62 kiện search là LinqSelector
                Result = Table.Where(LinqSelector).ToList<T>();
                // Return success
                return DAO.Com.DAOConstant.RES_SUC;
            }
            catch (Exception e)
            {
                // Đặt kết quả trả về là null
                Result = null;
                // Tạo danh sách MessageError
                MessageError = new List<string>();
                // Thêm thông tin lỗi
                MessageError.Add(DAO.Com.DAOUtils.GetErrorFromException(e));
                // Return fail
                return DAO.Com.DAOConstant.RES_FAI;
            }
        }

        /// <summary>
        /// Select một danh sách Object từ Database với mã Linq Expression
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="db">Database</param>
        /// <param name="LinqSelector">Linq Expression</param>
        /// <param name="Result">List Result</param>
        /// <param name="MessageError">List Error</param>
        /// <returns>Result Execute</returns>
        public string Select<T>(DbContext db, string sql, object[] param,
                                out List<T> Result, out List<string> MessageError) where T : class
        {
            MessageError = null;

            try
            {
                // Lấy Table T từ Database
                DbSet<T> Table = db.Set<T>();
                // Tạo mới danh sách kết quả trả về
                Result = new List<T>();
                // Lấy tất cả các record trong Table với điều kiện search là LinqSelector
                Result = db.Database.SqlQuery<T>(sql,param).ToList<T>();
                // Return success
                return DAO.Com.DAOConstant.RES_SUC;
            }
            catch (Exception e)
            {
                // Đặt kết quả trả về là null
                Result = null;
                // Tạo danh sách MessageError
                MessageError = new List<string>();
                // Thêm thông tin lỗi
                MessageError.Add(DAO.Com.DAOUtils.GetErrorFromException(e));
                // Return fail
                return DAO.Com.DAOConstant.RES_FAI;
            }
        }

        /// <summary>
        /// Phương thức lấy danh sách key của 1 table
        /// copy https://michaelmairegger.wordpress.com/2013/03/30/find-primary-keys-from-entities-from-dbcontext/
        /// </summary>
        /// <typeparam name="T">Loại table</typeparam>
        /// <param name="context">Database</param>
        /// <returns>Danh sách tên các key của table T</returns>
        private string[] GetKeyNames<T>(DbContext context) where T : class
        {
            ObjectSet<T> objectSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<T>();
            string[] keyNames = objectSet.EntitySet.ElementType.KeyMembers
                                                               .Select(k => k.Name)
                                                               .ToArray();
            return keyNames;
        }

        /// <summary>
        /// Phương thức lấy ra danh sách key value
        /// copy https://michaelmairegger.wordpress.com/2013/03/30/find-primary-keys-from-entities-from-dbcontext/
        /// </summary>
        /// <typeparam name="T">Table type</typeparam>
        /// <param name="entity">entity</param>
        /// <param name="context">database</param>
        /// <returns>Danh sách các key value</returns>
        private object[] GetKeys<T>(T entity, DbContext context) where T : class
        {
            var keyNames = GetKeyNames<T>(context);
            Type type = typeof(T);

            object[] keys = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);
            }
            return keys;
        }
    }
}
