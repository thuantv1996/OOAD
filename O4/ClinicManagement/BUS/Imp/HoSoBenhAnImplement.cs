using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Entities;
using BUS.Service;
using DTO;
using DAO;
using COM;
using BUS.Com;
using DAO.Imp;

namespace BUS.Imp
{
    class HoSoBenhAnImplement : IHoSoBenhAnService
    {
        public string AddHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-AddHoSoBenhAn";
            // Tạo đối tượng HoSoDAO
            HOSOBENHAN HoSoDAO = new HOSOBENHAN();
            // Copy property từ HoSo sang HoSoDAO
            Utils.CopyPropertiesFrom(HoSoEntity, HoSoDAO);
            // Biến đón kết quả từ dao
            string IdResult;

            // Tạo đối tượng DAO
            BaseDAO dao = new BaseDAO();
            // Thực thi insert HoSo
            IdResult = dao.Insert(HoSoDAO, db, ref Messages);

            // Nếu lệnh insert fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi insert dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // return success
            return Constant.RES_SUC;
        }

        public string CreateIdHoSoBenhAn(out string Id, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-CreateIdHoSoBenhAn";
            List<HOSOBENHAN> ListHoSoDAO = new List<HOSOBENHAN>();
            Id = "HS00000001";
            using(var db = new QLPHONGKHAMEntities())
            {
                ListHoSoDAO = (from hs in db.HOSOBENHANs
                               orderby hs.MaHoSo descending
                               select hs).ToList();
            }
            if(ListHoSoDAO.Count > 0)
            {
                string curId = ListHoSoDAO.ElementAt(0).MaHoSo;
                try
                {
                    int curNumId = Int32.Parse(curId.Substring(2, 8));
                    curNumId += 1;
                    Id = "HS";
                    for (int i = 0; i < (8 - curNumId.ToString().Length); i++)
                    {
                        Id += "0";
                    }
                    Id += curNumId.ToString();
                }
                catch
                {
                    // thêm Message Error
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_SYS,
                        Message = String.Format("Lỗi xãy ra khi Parse một chuổi sang Int32 - {0}", ProgramName)
                    });
                    // return fail;
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string GetRootHoSoBenhAn(QLPHONGKHAMEntities db, string MaHoSoTruoc, out HoSoBenhAnEntity hoSoBenhAnRoot, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-GetRootHoSoBenhAn";
            hoSoBenhAnRoot = new HoSoBenhAnEntity();
            HOSOBENHAN hoso = new HOSOBENHAN();
            try
            {
                hoso = db.HOSOBENHANs.Find(MaHoSoTruoc);
            }
            catch
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi Find trên Table HOSOBENHAN - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            if(hoso == null)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi Find trên Table HOSOBENHAN - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            } 
            if(hoso.MaHoSoTruoc == null || hoso.MaHoSoTruoc == "")
            {
                Utils.CopyPropertiesFrom(hoso, hoSoBenhAnRoot);
                return Constant.RES_SUC;
            }
            else
            {
                return GetRootHoSoBenhAn(db, hoso.MaHoSoTruoc, out hoSoBenhAnRoot, ref Messages);
            }
        }

        public string GetListHoSoBenhAnWithId(QLPHONGKHAMEntities db, string MaBenhNhan, out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages)
        {
            ListHoSo = new List<HoSoBenhAnEntity>();
            List<HOSOBENHAN> ListHoSoDAO = new List<HOSOBENHAN>();
            ListHoSoDAO = (from hs in db.HOSOBENHANs
                           where hs.MaBenhNhan == MaBenhNhan
                           select hs).ToList();
            foreach(var hs in ListHoSoDAO)
            {
                HoSoBenhAnEntity hoSoBenhAn = new HoSoBenhAnEntity();
                Utils.CopyPropertiesFrom(hs, hoSoBenhAn);
                ListHoSo.Add(hoSoBenhAn);
            }
            return Constant.RES_SUC;
        }

        public string DeleteHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-DeleteHoSoBenhAn";
            // Tạo đối tượng HoSoDAO
            HOSOBENHAN HoSoDAO = new HOSOBENHAN();
            // Copy property từ HoSo sang HoSoDAO
            Utils.CopyPropertiesFrom(HoSoEntity, HoSoDAO);
            // Biến đón kết quả từ dao
            string IdResult;

            // Tạo đối tượng DAO
            BaseDAO dao = new BaseDAO();
            // Thực thi delete HoSo
            IdResult = dao.Delete(HoSoDAO, db, ref Messages);

            // Nếu lệnh delete fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi delete dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // return success
            return Constant.RES_SUC;
        }

        public string GetInfomationHoSo(string MaHoSo, out HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-GetInfomationHoSo";
            // khởi tạo đối tượng HoSo
            HoSoEntity = new HoSoBenhAnEntity();
            // Khởi tạo danh sách HoSoDAO trả về 
            List<HOSOBENHAN> ListHoSoDAO = null;
            // Biến đón kết quả từ dao
            string IdResult;
            // Khởi tạo DB
            using (var db = new QLPHONGKHAMEntities())
            {
                // Tạo đối tượng DAO
                BaseDAO dao = new BaseDAO();
                // thực hiện lệnh select
                IdResult = dao.Select(db, hs => hs.MaHoSo == MaHoSo, out ListHoSoDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListHoSoDAO.Count == 0)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data trả về nhiều hơn 1 record
            if (ListHoSoDAO.Count > 1)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi select trên key nhiều hơn 1 record dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // copy property
            Utils.CopyPropertiesFrom(ListHoSoDAO.ElementAt(0), HoSoEntity);
            // return success
            return Constant.RES_SUC;
        }

        public string GetListHoSo(out List<HoSoBenhAnEntity> ListHoSoEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-GetInfomationHoSo";
            // khởi tạo đối tượng HoSo
            ListHoSoEntity = new List<HoSoBenhAnEntity>();
            // Khởi tạo danh sách HoSoDAO trả về 
            List<HOSOBENHAN> ListHoSoDAO = null;
            // Biến đón kết quả từ dao
            string IdResult;
            // Khởi tạo DB
            using (var db = new QLPHONGKHAMEntities())
            {
                // Tạo đối tượng DAO
                BaseDAO dao = new BaseDAO();
                // thực hiện lệnh select
                IdResult = dao.Select(db, out ListHoSoDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListHoSoDAO.Count == 0)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // duyệt qua danh sách hồ sơ
            foreach (var hoso in ListHoSoDAO)
            {
                // tạo đối tượng entity
                HoSoBenhAnEntity hoSoEntity = new HoSoBenhAnEntity();
                // copy property
                Utils.CopyPropertiesFrom(hoso, hoSoEntity);
                // add vào list ouput
                ListHoSoEntity.Add(hoSoEntity);
            }
            return Constant.RES_SUC;
        }

        public string SearchHoSo(HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnEntity> ListHoSoEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-SearchHoSo";
            // Danh sách hồ sơ (DTO) trả về
            ListHoSoEntity = new List<HoSoBenhAnEntity>();
            // Danh sách Hồ sơ (DAO) Nhận được từ function select
            List<BENHNHAN> ListHoSoDAO = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo lớp DAO
                BaseDAO dao = new BaseDAO();
                // Tạo Paramester search
                object[] param = { HoSoSearch.MaHoSo, HoSoSearch.TenBenhNhan, HoSoSearch.NgayKham };
                // Lấy câu truy vấn sql từ function Com.BUSSql.SqlSearchHoSoBenhAn(param)
                string sql = BUSSql.SqlSearchHoSoBenhAn(param);
                // thực thi hàm select 
                IdResult = dao.Select(db, sql, param, out ListHoSoDAO, ref Messages);
                // Nếu không thực hiện được lệnh SELECT
                if (IdResult == Constant.RES_FAI)
                {
                    // thêm message error
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Lỗi Database trong truy vấn select table HOSOBENHAN - {0}", ProgramName)
                    });
                    // Return faild
                    IdResult = Constant.RES_FAI;
                }
                // Nếu không tìm thấy record nào
                if (ListHoSoEntity.Count == 0)
                {
                    // thêm message error
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                    });
                    // Return fail
                    IdResult = Constant.RES_FAI;
                }
            }

            // Nếu có kết quả trả về
            // duyệt qua danh sách kết quả trả về
            BenhNhanImplement benhNhanImplement = new BenhNhanImplement();
            foreach (var hoso in ListHoSoDAO)
            {
                BenhNhanEnity benhNhanEnity = null;
                // Tìm Tên Bệnh nhân
                if(benhNhanImplement.GetInformationBenhNhan(hoso.MaBenhNhan, out benhNhanEnity, ref Messages) == Constant.RES_SUC)
                {
                    // nếu có chứa tên bệnh nhân
                    if (benhNhanEnity.HoTen.ToLower().Contains(HoSoSearch.TenBenhNhan.ToLower()))
                    {
                        // tạo mới đối tượng HoSoEntity
                        HoSoBenhAnEntity hoSoBenhAnEntity = new HoSoBenhAnEntity();
                        // copy property
                        Utils.CopyPropertiesFrom(hoso,hoSoBenhAnEntity);
                        // Thêm HoSoEntity vào List output
                        ListHoSoEntity.Add(hoSoBenhAnEntity);
                    }
                }
            }
            // nếu không có danh sách 
            if(ListHoSoEntity.Count == 0)
            {
                // thêm message error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                });
                // Return fail
                IdResult = Constant.RES_FAI;
            }
            // return 
            return Constant.RES_SUC;
        }

        public string UpdateHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhAnImplement-UpdateHoSo";
            // Tạo đối tượng HoSoDAO
            HOSOBENHAN HoSoDAO = new HOSOBENHAN();
            // Copy property từ HoSo sang HoSoDAO
            Utils.CopyPropertiesFrom(HoSoEntity, HoSoDAO);
            // Biến đón kết quả từ dao
            string IdResult;

            // Tạo đối tượng DAO
            BaseDAO dao = new BaseDAO();
            // Thực thi update HoSo
            IdResult = dao.Update(HoSoDAO, db, ref Messages);

            // Nếu lệnh update fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi update dữ liệu từ Table HOSOBENHAN - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // return success
            return Constant.RES_SUC;
        }

    }
}
