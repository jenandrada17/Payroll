using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;

using Ionic.Zip;

using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DBConnect.Tools
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        public void Zip(string source, string destination)
        {
            using (ZipFile zip = new ZipFile
            {
                CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression
            })
            {
                var files = Directory.GetFiles(source, "*",
                    SearchOption.AllDirectories).
                    Where(f => Path.GetExtension(f).
                        ToLowerInvariant() != ".zip").ToArray();

                foreach (var f in files)
                {
                    if (!f.Contains(".zip"))
                    {
                        if (f.Contains(".FBK"))
                        {
                            zip.AddFile(f, GetCleanFolderName(source, f));
                        }
                    }
                }

                var destinationFilename = destination;

                if (!Directory.Exists(destination) && !destination.EndsWith(".zip"))
                {
                    destinationFilename += $"\\{new DirectoryInfo(source).Name}-{DateTime.Now:yyyy-MM-dd-HH-mm-ss-ffffff}.zip";
                }

                zip.Save(destinationFilename);
                Console.WriteLine(destinationFilename.Length);
                File.Move(destinationFilename, destinationFilename.Substring(0, 68) + ".zip");
                MessageBox.Show("Backup Succeeded.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private string GetCleanFolderName(string source, string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))
            {
                return string.Empty;
            }

            var result = filepath.Substring(source.Length);

            if (result.StartsWith("\\"))
            {
                result = result.Substring(1);
            }

            result = result.Substring(0, result.Length - new FileInfo(filepath).Name.Length);

            return result;
        }

        private void BackUp_BTN_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog f = new SaveFileDialog())
            {
                if (Program.DefaultFolder == "")
                {
                    Program.DefaultFolder = Application.ExecutablePath.ToString();
                }

                f.InitialDirectory = Program.DefaultFolder;
                f.Filter = "IB/FB Backup File(*.gdk;*.ibk;*.fbk)|*.gdk;*.ibk;*.fbk|All Files(*.*)|*.*";
                FileName_TXT.Text = $"BACKUP{DateTime.Now.ToString("MMddyyHHmmsstt")}";
                f.FileName = $"{FileName_TXT.Text}{".FBK"}";
                if (DialogResult.OK == f.ShowDialog())
                {
                    Path_TXT.Text = Path.GetDirectoryName(f.FileName);
                    FileName_TXT.Text = Path.GetFileName(f.FileName);
                    Program.DefaultFolder = Path.Combine(Path_TXT.Text, FileName_TXT.Text);
                    Program.TargetFile = Path.Combine(Path_TXT.Text, FileName_TXT.Text);
                }
            }

            if (!Program.TargetDirectoryIsValid())
                return;
            Log_Console.Clear();
            try
            {
                var backupSvc = new FbBackup
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["FbConString"].ConnectionString.ToString()
                };
                backupSvc.BackupFiles.Add(new FbBackupFile(Path.Combine(Path_TXT.Text, FileName_TXT.Text), 4096));
                backupSvc.Verbose = true;
                backupSvc.Options = FbBackupFlags.IgnoreLimbo;
                backupSvc.ServiceOutput += BackupSvc_ServiceOutput;
                backupSvc.InfoMessage += BackupSvc_InfoMessage;
                backupSvc.Execute();
                Zip(Path_TXT.Text, Path.Combine(Path_TXT.Text, FileName_TXT.Text) + ".zip");
                File.Delete(Path.Combine(Path_TXT.Text, FileName_TXT.Text));
                Path_TXT.Clear();
                FileName_TXT.Clear();
                Program.TargetFile = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
            }
        }

        private void BackupSvc_InfoMessage(object sender, FbInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BackupSvc_ServiceOutput(object sender, ServiceOutputEventArgs e)
        {
            Log_Console.AppendText("Backup: " + e.Message.Substring(5).TrimStart() + "\r\n");
            Console.WriteLine("Backup: " + e.Message.Substring(5).TrimStart() + "\r\n");
            Application.DoEvents();
        }

        private void Restore_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openf = new OpenFileDialog())
                {
                    if (Program.DefaultFolder == "")
                    {
                        Program.DefaultFolder = Environment.CurrentDirectory.ToString();
                    }

                    openf.InitialDirectory = Program.DefaultFolder;

                    openf.Filter = "IB/FB Backup File(*.gdk;*.ibk;*.fbk)|*.gdk;*.ibk;*.fbk|IB/FB Database File(*.gdb;*.ib;*.fdb)|*.gdb;*.ib;*.fdb|All Files(*.*)|*.*";
                    openf.FileName = "*.FBK";
                    if (DialogResult.OK == openf.ShowDialog())
                    {
                        Path_TXT.Text = Path.GetDirectoryName(openf.FileName);
                        FileName_TXT.Text = Path.GetFileName(openf.FileName);
                        Program.DefaultFolder = Path.Combine(Path_TXT.Text, FileName_TXT.Text);
                        Program.TargetFile = Path.Combine(Path_TXT.Text, FileName_TXT.Text);
                    }

                    if (!Program.TargetDirectoryIsValid())
                        return;
                    Log_Console.Clear();
                    var restoreSvc = new FbRestore
                    {
                        ConnectionString = ConfigurationManager.ConnectionStrings["FbConString"].ConnectionString.ToString()
                    };
                    restoreSvc.BackupFiles.Add(new FbBackupFile(Path.Combine(Path_TXT.Text, FileName_TXT.Text), 4096));
                    restoreSvc.Verbose = true;
                    restoreSvc.PageSize = 4096;
                    restoreSvc.PageBuffers = 2048;
                    restoreSvc.Options = FbRestoreFlags.Replace;
                    FbConnection.ClearAllPools();
                    restoreSvc.ServiceOutput += RestoreSvc_ServiceOutput; ;
                    restoreSvc.InfoMessage += RestoreSvc_InfoMessage;
                    restoreSvc.Execute();
                    Path_TXT.Clear();
                    FileName_TXT.Clear();
                    MessageBox.Show("Database Successfully Restored", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
            }
        }

        private void RestoreSvc_ServiceOutput(object sender, ServiceOutputEventArgs e)
        {
            Log_Console.AppendText("Restore: " + e.Message.Substring(5).TrimStart() + "\r\n");
            Console.WriteLine("Restore: " + e.Message.Substring(5).TrimStart() + "\r\n");
            Application.DoEvents();
        }

        private void RestoreSvc_InfoMessage(object sender, FbInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Log_Console_TextChanged(object sender, EventArgs e)
        {
            Log_Console.ScrollToCaret();
            Application.DoEvents();
        }
    }
}