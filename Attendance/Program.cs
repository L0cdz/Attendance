namespace Attendance
{
    internal static class Program
    {
        public static String id,name,pwd,email,sdt,sever,database,username,password;
        public static String compensateDay = "";
        public static List<String> listAbsent = new List<String>();
        public static List<String> listCompensate = new List<String>();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Config());
        }
    }
}