using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.DAL
{
    public class Users
    {
        public static IEnumerable<User> GetUserList(string con, bool IsAdmin, string str = null)
        {
            if (str != null && str != "")
                str = "%" + str.Replace(" ", "%") + "%";

            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@IsAdmin", SqlDbType.Bit);
            prm[0].Value = IsAdmin;

            prm[1] = new SqlParameter("@str", SqlDbType.NVarChar);
            prm[1].Value = str;

            var ds = SqlHelper.ExecuteDataset(con, "uspUserList", prm);
            if (ds != null)
            {
                IEnumerable<User> lst = ds.Tables[0].AsEnumerable().Select(r => new User
                  {
                      UserId = r.Field<int>("UserId"),
                      UserName = r.Field<string>("UserName"),
                      Pass = r.Field<string>("Pass"),
                      FirstName = r.Field<string>("FirstName"),
                      LastName = r.Field<string>("LastName"),
                      Email = r.Field<string>("Email"),
                      IsAdmin = r.Field<bool>("IsAdmin"),
                      CreateDate = r.Field<DateTime>("CreateDate")
                  });
                return lst;
            }
            return null;
        }
        public static bool CheckExist(string con, string Name, int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            prm[0].Value = Name;

            prm[1] = new SqlParameter("@Id", SqlDbType.Int);
            prm[1].Value = Id;

            return Convert.ToBoolean(SqlHelper.ExecuteScalar(con, "uspUserCheckExist", prm));
        }
        public static Machine.DAL.User GetUser(int UserId, string con)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;

            var ds = SqlHelper.ExecuteDataset(con, "uspUserDetail", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new User
                {
                    UserId = r.Field<int>("UserId"),
                    UserName = r.Field<string>("UserName"),
                    Pass = r.Field<string>("Pass"),
                    FirstName = r.Field<string>("FirstName"),
                    LastName = r.Field<string>("LastName"),
                    Email = r.Field<string>("Email"),
                    IsAdmin = r.Field<bool>("IsAdmin"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                }).FirstOrDefault();
                return lst;
            }
            return null;
        }
        public static int UserDelete(int UserId, string con)
        {
            try
            {
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
                prm[0].Value = UserId;

                return SqlHelper.ExecuteNonQuery(con, "uspUserDelete", prm);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int Edit(string con, int UserId, string UserName, string Pass, string FirstName, string LastName, string Email, bool IsAdmin)
        {
            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;

            prm[1] = new SqlParameter("@UserName", SqlDbType.NVarChar);
            prm[1].Value = UserName;

            prm[2] = new SqlParameter("@Pass", SqlDbType.NVarChar);
            prm[2].Value = Pass;

            prm[3] = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            prm[3].Value = FirstName;

            prm[4] = new SqlParameter("@LastName", SqlDbType.NVarChar);
            prm[4].Value = LastName;

            prm[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
            prm[5].Value = Email;

            prm[6] = new SqlParameter("@IsAdmin", SqlDbType.Bit);
            prm[6].Value = IsAdmin;

            return SqlHelper.ExecuteNonQuery(con, "uspUserEdit", prm);
        }

        public static User UserLogin(string con, string UserName, string Pass)
        {
            SqlParameter[] prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
            prm[0].Value = UserName;

            prm[1] = new SqlParameter("@Pass", SqlDbType.NVarChar);
            prm[1].Value = Pass;
             
             var ds = SqlHelper.ExecuteDataset(con, "uspUserLogin", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new User
                {
                    UserId = r.Field<int>("UserId"),
                    UserName = r.Field<string>("UserName"),
                    Pass = r.Field<string>("Pass"),
                    FirstName = r.Field<string>("FirstName"),
                    LastName = r.Field<string>("LastName"),
                    Email = r.Field<string>("Email"),
                    IsAdmin = r.Field<bool>("IsAdmin"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                }).FirstOrDefault();
                return lst;
            }
            return null;
        }
        public static List<uReport> UserMenu(string con, int Userid)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = Userid;

            var ds = SqlHelper.ExecuteDataset(con, "uspUserGetMenu", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new uReport
                {
                    ReportId = r.Field<int>("ReportId"),
                    Name = r.Field<string>("Name"),
                    Desc = r.Field<string>("Description"),
                    PageUrl = r.Field<string>("PageUrl"),
                    IsParent = r.Field<bool>("IsParent"),
                    Parent = r.Field<int>("Parent"),
                    Index = r.Field<int>("Idx"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                }).ToList();
                return lst;
            }
            return null;
        }

        public static int UserAssignGroup(string con, int UserId, string ids)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;
            prm[1] = new SqlParameter("@Ids", SqlDbType.NVarChar);
            prm[1].Value = ids;

            return SqlHelper.ExecuteNonQuery(con, "uspUserAssigngroup", prm);
        }

        public static DataSet FillAssignGroup(string con, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;

            var ds = SqlHelper.ExecuteDataset(con, "uspUserFillAssignGroup", prm);
            if (ds != null)
            {
                //var lst = ds.Tables[0].AsEnumerable().Select(r => new Group
                //{
                //    GroupId = r.Field<int>("GroupId"),
                //    Name = r.Field<string>("Name"),
                //    IsGroup =  Convert.ToBoolean( r.Field<bool>("IsGroup"))
                //});
                //return lst;
                return ds;
            }
            return null;

        }

        public static DataSet FillAssignTable(string con, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;

            var ds = SqlHelper.ExecuteDataset(con, "uspUserFillAssignTable", prm);
            if (ds != null)
                return ds;
            
            return null;
        }
        public static int CheckUserEmail(string con, string Email, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Email", SqlDbType.NVarChar);
            prm[0].Value = Email;

            prm[1] = new SqlParameter("@UserId", SqlDbType.NVarChar);
            prm[1].Value = UserId;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(con, "uspUserEmailCheck", prm));//uspForgotEmailCheck
        }
        public static int ForgotPwdCheckEmail(string con, string Email)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Email", SqlDbType.NVarChar);
            prm[0].Value = Email;


            return Convert.ToInt32(SqlHelper.ExecuteScalar(con, "uspFGPassCheckExist", prm));
        }
        public static int FGPassAdd(string con, string Email, string Message)
        {
            SqlParameter[] prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@UserEmail", SqlDbType.NVarChar);
            prm[0].Value = Email;

            prm[1] = new SqlParameter("@Message", SqlDbType.NVarChar);
            prm[1].Value = Message;

            return SqlHelper.ExecuteNonQuery(con, "uspFGPassAdd", prm);
        }
        public static object GetPasswordRequestList(string con, string str = null)
        {
            if (str != null && str != "")
                str = "%" + str.Replace(" ", "%") + "%";

            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@str", SqlDbType.NVarChar);
            prm[0].Value = str;

            var ds = SqlHelper.ExecuteDataset(con, "uspFGPassList", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new User
                {
                    UserId = r.Field<int>("UserID"),
                    UserName = r.Field<string>("UserName"),
                    Email = r.Field<string>("Email"),
                    Message = r.Field<string>("Message")
                });
                return lst;
            }
            return null;
        }
        public static int PasswordReset(string con, int UserId, string Pass)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;

            prm[1] = new SqlParameter("@NewPass", SqlDbType.NVarChar);
            prm[1].Value = Pass;

            return SqlHelper.ExecuteNonQuery(con, "uspUserPasswordUpdate", prm);
        }

        public static Machine.DAL.User GetUserPassDetail(int UserId, string con)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;


            var ds = SqlHelper.ExecuteDataset(con, "uspUserPassDetail", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new User
                {
                    UserId = r.Field<int>("UserId"),
                    UserName = r.Field<string>("UserName"),
                    Pass = r.Field<string>("Pass"),
                    Message = r.Field<string>("Message")
                }).FirstOrDefault();
                return lst;
            }
            return null;
        }

        public static int UserChangePassword(string con, int Userid, string OldPassword, string NewPass)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = Userid;
            prm[1] = new SqlParameter("@OldPass", SqlDbType.NVarChar);
            prm[1].Value = OldPassword;
            prm[2] = new SqlParameter("@NewPass", SqlDbType.NVarChar);
            prm[2].Value = NewPass;

            return SqlHelper.ExecuteNonQuery(con, "uspUserChangePassword", prm);
        }
    }

    public class User
    {
        public User() { }
        public User(int userid, string username, string pass, string firstname, string lastname, string email, bool isAdmin, string message, DateTime createddate)
        {
            this.UserId = userid;
            this.UserName = username;
            this.Pass = pass;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.CreateDate = createddate;
            this.Email = email;
            this.IsAdmin = isAdmin;
            this.Message = message;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
