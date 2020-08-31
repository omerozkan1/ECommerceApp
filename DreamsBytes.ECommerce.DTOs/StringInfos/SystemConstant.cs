using System.Collections.Generic;

namespace DreamsBytes.ECommerce.DTOs.StringInfos
{
    public class SystemConstant
    {
        public const string webApiBaseAddress = "http://localhost:5006/";

        public enum ERRORS
        {
            SUCCESSFUL = 1,
            NOTFOUND = 2,
            SYSTEMERROR = 3

        }

        public static Dictionary<int, string> SystemErrors = new Dictionary<int, string>()
        {
            {1,"İşlem Başarılı" },
            {2,"Aranan Bulunamadı" },
            {3,"Sistem Hatası" }
        };
    }

    public class RoleInfo
    {
        public const string Admin = "Admin";
        public const string Member = "Member";
    }

    public class AreaInfo
    {
        public const string Admin = "Admin";
        public const string Member = "Member";
    }
}
