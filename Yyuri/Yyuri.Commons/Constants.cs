using System.ComponentModel.DataAnnotations;
using System.Configuration;


namespace Yyuri.Commons
{
    public static class Constants
    {
        public enum Month
        {
            [Display(Name = "01")]
            JAN = 1,
            [Display(Name = "02")]
            FEB = 2,
            [Display(Name = "03")]
            MAR = 3,
            [Display(Name = "04")]
            APR = 4,
            [Display(Name = "05")]
            MAY = 5,
            [Display(Name = "06")]
            JUN = 6,
            [Display(Name = "07")]
            JUL = 7,
            [Display(Name = "08")]
            AUG = 8,
            [Display(Name = "09")]
            SEP = 9,
            [Display(Name = "10")]
            OCT = 10,
            [Display(Name = "11")]
            NOV = 11,
            [Display(Name = "12")]
            DEC = 12,
        }

        //public enum Month
        //{
        //    NotSet = 0,
        //    January = 1,
        //    February = 2,
        //    March = 3,
        //    April = 4,
        //    May = 5,
        //    June = 6,
        //    July = 7,
        //    August = 8,
        //    September = 9,
        //    October = 10,
        //    November = 11,
        //    December = 12
        //}

        public enum Claims
        {
            User = 0,
            Administrator = 1,
            Staff = 2,
            Manager = 3
        };

        public const string SYS_USER_GROUP_UNAUTHORIZED_USERS = "Unauthorized Users";
        public const string SYS_USER_GROUP_STAFFS = "Staffs";
        public const string SYS_USER_GROUP_MANAGERS = "Managers";
        public const string SYS_USER_GROUP_PROJECT_MANAGERS = "Project Managers";
        public const string SYS_USER_GROUP_SYSTEM_ADMINISTRATORS = "System Admin";
        public const string SYS_USER_GROUP_USERS = "User";

        public const string SYS_ROLE_SYSTEM_ADMINISTRATION = "system_administration";
        public const string SYS_ROLE_USER_MANAGEMENT = "user_management";

        public const string SYS_MANAGEMENT_PRODUCT = "management_product";
        public const string SYS_MANAGEMENT_PRODUCTCATEGORY = "management_productcategory";
        public const string SYS_MANAGEMENT_PRODUCTTAG = "management_producttag";

        public const string SYS_MANAGEMENT_POST = "management_post";
        public const string SYS_MANAGEMENT_POSTCATEGORY = "management_postcategory";
        public const string SYS_MANAGEMENT_POSTTAG = "management_posttag";





        public const string SYS_ROLE_TIMESHEET = "timesheet";
        public const string SYS_ROLE_LEAVE = "leave";

        public const string ENTITY_FRAMEWORK_CONNECTION_STRING = "AtsDbContext";

        public static string COOKIE_PATH = "";
        public static string CONFIGURATION_AUDIENCE_SECRET = ConfigurationManager.AppSettings["as:AudienceSecret"];
        public static string CONFIGURATION_AUDIENCE_ID = ConfigurationManager.AppSettings["as:AudienceId"];
        public static int ACCESSTOKEN_EXPIRE_TIMESPAN_MINUTES = 0;
        public static int TOKEN_LIFESPAN_MINUTES = 60;
        public static int PASSWORD_MIN_LENGHT = 8;



        public static string Project_Prefix = "PJ";
        public static string Project_Seperator  = "_3";

        public const string DateFormat = "dd/MM/yyyy";
        public const string NumberFormat = "{0:#,#}";

        public const string QRCODE = "QRCode";
        public const string EMPLOYEE = "Employee";
        public const string ASSET = "AssetMng";

    }
}
