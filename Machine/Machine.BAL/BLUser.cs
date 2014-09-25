using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Machine.BAL
{
    public class BLUser
    {
        public static DAL.User UserLogin(string con, string UserName, string Pass)
        {
            return Machine.DAL.Users.UserLogin(con, UserName, Pass);
        }
        public static IEnumerable<DAL.User> GetUserList(string con, bool IsAdmin, string str = null)
        {
            return Machine.DAL.Users.GetUserList(con, IsAdmin, str);
        }
        public static Machine.DAL.User GetUserDetail(string con, int UserId)
        {
            return Machine.DAL.Users.GetUser(UserId, con);
        }
        public static Machine.DAL.User GetUserPassDetail(int UserId, string con)
        {
            return Machine.DAL.Users.GetUserPassDetail(UserId, con);
        }
        public static int UserAddEdit(string con, int UserId, string UserName, string Pass, string FirstName, string LastName, string Email, bool IsAdmin)
        {
            return Machine.DAL.Users.Edit(con, UserId, UserName, Pass, FirstName, LastName, Email, IsAdmin);
        }
        public static object DeleteUser(string con, int UserId)
        {
            return Machine.DAL.Users.UserDelete(UserId, con);
        }
        public static bool CheckExist(string con, string Name, int Id)
        {
            return Machine.DAL.Users.CheckExist(con, Name, Id);
        }
        public static int CheckEMail(string con, string Email, int UserId)
        {
            return Machine.DAL.Users.CheckUserEmail(con, Email, UserId);
        }
        public static int ForgotPasswordAdd(string con, string Email, string Message)
        {
            return Machine.DAL.Users.FGPassAdd(con, Email, Message);
        }
        public static int PasswordAdd(string con, int UserId, string Pass)
        {
            return Machine.DAL.Users.PasswordReset(con, UserId, Pass);
        }
        public static object GetPasswordRequest(string con, string str = null)
        {
            return Machine.DAL.Users.GetPasswordRequestList(con, str);
        }
        public static int ForgotPwdCheckEmail(string con, string Email)
        {
            return Machine.DAL.Users.ForgotPwdCheckEmail(con, Email);
        }
        public static List<DAL.uReport> UserMenu(string con, int Userid)
        {
            return Machine.DAL.Users.UserMenu(con, Userid);
        }

        public static int UserAssignGroup(string con, int UserId, string Ids)
        {
            return Machine.DAL.Users.UserAssignGroup(con, UserId, Ids);
        }

        public static DataSet FillAssignGroup(string con, int UserId)
        {
            return Machine.DAL.Users.FillAssignGroup(con, UserId);
        }

        public static DataSet FillAssignTable(string con, int UserId)
        {
            return Machine.DAL.Users.FillAssignTable(con, UserId);
        }

        public static int UserChangePassword(string con, int Userid, string OldPassword, string NewPass)
        {
            return Machine.DAL.Users.UserChangePassword(con, Userid, OldPassword, NewPass);
        }
    }
}
