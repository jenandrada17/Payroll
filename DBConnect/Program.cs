using System;
using System.IO;
using System.Windows.Forms;

namespace DBConnect
{
    internal static class Program
    {
        public static string DefaultFolder = "";
        public static string TargetFile = "";
        public static string ExcelTargetFile = "";
        private static string _connectionString = "";

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                    throw new Exception("Connection string is empty.");
                else
                    return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public static bool TargetDirectoryIsValid()
        {
            try
            {
                string dir = Path.GetDirectoryName(TargetFile);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Specify path is not valid. Please try again." + Environment.NewLine + Environment.NewLine + ex.Message, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public static bool ExcelTargetDirectoryIsValid()
        {
            try
            {
                string dir = Path.GetDirectoryName(ExcelTargetFile);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Specify path is not valid. Please try again." + Environment.NewLine + Environment.NewLine + ex.Message, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }
}