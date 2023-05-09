using System.Diagnostics;
using System.DirectoryServices.AccountManagement;


//Created by Anthony
//Last updated: 05/08/2023 V0.1
namespace User_Utilities
{
    public partial class UserUtilities : Form
    {
        public UserUtilities()
        {
            InitializeComponent();
        }
        private void PWresetBtn_Click(object sender, EventArgs e)
        {
            output.Items.Clear();

            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                UserPrincipal userTemplate = new UserPrincipal(context)
                {
                    SamAccountName = "STU*"
                };

                using (PrincipalSearcher searcher = new PrincipalSearcher(userTemplate))
                {
                    foreach (UserPrincipal user in searcher.FindAll())
                    {
                        if (user.PasswordNeverExpires)
                        {
                            user.PasswordNeverExpires = false;
                            user.Save();
                        }
                        user.ExpirePasswordNow();
                        user.Save();

                        output.Items.Add($"User '{user.SamAccountName}' password set to change on next login.");
                    }
                }
            }
        }

        private void PWexpireBtn_Click(object sender, EventArgs e)
        {
            output.Items.Clear();

            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                UserPrincipal userTemplate = new UserPrincipal(context)
                {
                    SamAccountName = "STU*"
                };

                using (PrincipalSearcher searcher = new PrincipalSearcher(userTemplate))
                {
                    foreach (UserPrincipal user in searcher.FindAll())
                    {
                        if (!user.PasswordNeverExpires)
                        {
                            user.PasswordNeverExpires = true;
                            user.Save();
                        }

                        output.Items.Add($"User '{user.SamAccountName}' password set to never expire.");
                    }
                }
            }
        }

        private void RTclockBtn_Click(object sender, EventArgs e)
        {
            string timezone = "Central Standard Time";
            Process.Start("tzutil.exe", $"/s \"{timezone}\"").WaitForExit();
            output.Items.Add($"Timezone set to {timezone}.");
        }

        private async void NetwrkBtn_Click(object sender, EventArgs e)
        {
            // Disable the button to prevent multiple clicks
            NetwrkBtn.Enabled = false;

            // Run the network reset on a separate Task to avoid freezing the UI
            await Task.Run(() => ResetNetwork());

            // Re-enable the button after the task is completed
            NetwrkBtn.Enabled = true;
        }

        private void ResetNetwork()
        {
            // Restart the network adapter
            ExecuteCommand("powershell", "Restart-NetAdapter -Name \"Wi*\"");
            AppendOutput("Network adapter restarted");

            // Clear DNS cache
            ExecuteCommand("powershell", "Clear-DnsClientCache");
            Thread.Sleep(5000);
            ExecuteCommand("ipconfig", "/flushdns");
            AppendOutput("Flushed DNS");

            // Release and renew IP configuration
            Thread.Sleep(5000);
            ExecuteCommand("ipconfig", "/release");
            Thread.Sleep(5000);
            ExecuteCommand("ipconfig", "/renew");
            AppendOutput("IP configuration renew & released!");

            // Reset Winsock and network adapter
            ExecuteCommand("netsh", "winsock reset");
            Thread.Sleep(5000);
            ExecuteCommand("netcfg", "-d");
            AppendOutput("Network adapter has been reset");

            // Prompt user to restart the computer
            Thread.Sleep(4000);
            DialogResult result = MessageBox.Show("Do you want to restart the computer now?", "Restart computer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ExecuteCommand("shutdown", "/r /f /t 0");
            }
        }

        private void AppendOutput(string message)
        {
            // Invoke the UI thread to update the output ListBox
            this.Invoke((Action)(() =>
            {
                output.Items.Add(message);

                // If the message is "Network adapter has been reset", display the MessageBox
                if (message == "Network adapter has been reset")
                {
                    DialogResult result = MessageBox.Show("Do you want to restart the computer now?", "Restart computer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ExecuteCommand("shutdown", "/r /f /t 0");
                    }
                }
            }));
        }

        private void ExecuteCommand(string fileName, string arguments)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.WaitForExit();
        }

        private void SmrtCrdBtn_Click(object sender, EventArgs e)
        {
            string card = @"D:\sp98312 - Smart Card Reader.exe";
            Process.Start(card);

            var command = "rundll32.exe";
            var arguments = "shell32.dll,Control_RunDLL inetcpl.cpl,1,3";

            ProcessStartInfo startInfo = new()
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using Process process = Process.Start(startInfo);
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Output:");
                Console.WriteLine(output);
            }

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error:");
                Console.WriteLine(error);
            }
        }
    }
}