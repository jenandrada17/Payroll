using DBConnect.Helper;
using DBConnect.Settings;

using FirebirdSql.Data.FirebirdClient;

using System;
using System.Windows.Forms;

namespace DBConnect
{
    public partial class ServerSettings : Form
    {
        public ServerSettings()
        {
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {
            if (!string.IsNullOrWhiteSpace(Database_TXT.Text))
            {
                foreach (object obj in Controls)
                {
                    if (obj is TextBox txt)
                    {
                        txt.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (object obj in Controls)
                {
                    if (obj is TextBox txt)
                    {
                        txt.Enabled = true;
                    }
                }
            }
            if (DataSource_TXT.Enabled == false)
            {
                foreach (object obj in Controls)
                {
                    if (obj is Button btn)
                    {
                        btn.Enabled = false;
                        switch (btn.Text)
                        {
                            case "Change":
                            case "Cancel":
                                btn.Enabled = true;
                                break;

                            default:
                                btn.Enabled = false;
                                break;
                        }
                    }
                }
            }
            else
            {
                foreach (object obj in Controls)
                {
                    if (obj is Button btn)
                    {
                        btn.Enabled = true;
                    }
                }
            }
        }

        private void TestCon_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = string.Format($"User={UserName_TXT.Text};Password={Password_TXT.Text};" +
                                                     $"Database={Database_TXT.Text};DataSource={DataSource_TXT.Text};" +
                                                     $"Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=100;Pooling=false;" +
                                                     $"Packet Size=8192;");

                var helper = new ConnectionHelper(connectionString);
                if (helper.IsConnected)
                    MessageBox.Show(this, @"test succeeded", @"message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FbException exception)
            {
                MessageBox.Show("Unable to proceed, please check if you have entered the correct Server name, Username, Password or Database name then try again \n" + exception.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to proceed, please check if you have entered the correct Server name, Username, Password or Database name then try again \n" + exception.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FBConnectionString()
        {
            var cs = new FbConnectionStringBuilder()
            {
                UserID = UserName_TXT.Text,
                Password = Password_TXT.Text,
                Database = Database_TXT.Text,
                DataSource = DataSource_TXT.Text,
                Compression = true,
                Charset = FbCharset.None.ToString(),
                ClientLibrary = $@"{Environment.SpecialFolder.System}\GDS32.DLL",
                Dialect = 3,
                Port = 3050,
                ServerType = FbServerType.Default,
                ReturnRecordsAffected = true
            };

            return cs.ConnectionString;
        }

        private void SaveCon_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = FBConnectionString();

                var helper = new ConnectionHelper(connectionString);
                if (helper.IsConnected)
                {
                    var setting = new AppSettings();
                    setting.SaveConnectionString("FbConString", connectionString);
                    Properties.Settings.Default.DataSource = DataSource_TXT.Text;
                    Properties.Settings.Default.UserName = UserName_TXT.Text;
                    Properties.Settings.Default.Password = Password_TXT.Text;
                    Properties.Settings.Default.Database = Database_TXT.Text;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                    MessageBox.Show(@"Your connection string successfully saved", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Close();
                    if (MessageBox.Show("The Application needs to restart. \n do you wish to restart the application?", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
            }
            catch (FbException exception)
            {
                MessageBox.Show("Unable to proceed, please check if you have entered the correct Server name, Username, Password or Database name then try again \n" + exception.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to proceed, please check if you have entered the correct Server name, Username, Password or Database name then try again \n" + exception.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Change_BTN_Click(object sender, EventArgs e)
        {
            foreach (object obj in Controls)
            {
                if (obj is TextBox txt)
                {
                    txt.Enabled = true;
                }
            }
            foreach (object obj in Controls)
            {
                if (obj is Button btn)
                {
                    btn.Enabled = true;
                }
            }
        }

        private void CancelCon_BTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}