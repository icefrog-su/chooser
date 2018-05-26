/* Copyright 2018 icefrog.su@qq.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */




using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Chooser
{
    /// <summary>
    /// [CHOOSER INTERNAL CONFIG INFORMATION]
    /// [VERSION 1.0.0]
    /// [CONTENT 记录第一次运行的客户机所要求用户记录的一些配置信息]
    /// 关于开发工具配置文件路径说明：
    ///     约定配置文件书写格式为:[需要打开的软件名]=[路径]
    ///     为了便于文件流的数据读取,该文件的写入不得加入其他任何字符数据.
    /// [AUTHOR  @ICE FROG-LSW]
    /// [DATETIME 2016-9-8]
    /// </summary>
    public static class Config
    {
        private const string LOCALHOST_IP_ADDRESS = "LOCALHOST-IP-ADDRESS";
        private const string LOCAL_NAME = "LOCALHOST-NAME";
        private const string LOCAL_LOGINED_USER_NAME = "LOCAL-LOGINED-USER-NAME";
        private const string LOCAL_LOGINED_USER_ISADMIN = "LOCAL-LOGINED-USER-ISADMIN";
        private const string CURRENT_DATE_TIME = "CURRENT-DATE-TIME";
        private const string OPERATION_VERSION_INFORMATION = "OPERATION-VERSION-INFORMATION";

        public static Form form;

        /// <summary>
        /// 是否允许进入配置界面
        /// </summary>
        public static bool CanDoConfig = false;

        /// <summary>
        /// 标记默认值
        /// </summary>
        public const string UNDEFINE = "Undefine";

        /// <summary>
        /// 检查网络连接若成功使用的图标文件路径
        /// </summary>
        public const string WebStatusOKIconUrl = "icon/OK.png";

        /// <summary>
        /// 检查网络连接若失败或异常使用的图标文件路径
        /// </summary>
        public const string WebStatusErrIconUrl = "icon/err.png";

        /// <summary>
        /// 检查网络连接之前或者过程中使用的图标文件路径
        /// </summary>
        public const string WebStatusLoadingIconUrl = "icon/loading.png";

        /// <summary>
        /// 未检查网络连接之前使用的图标文件路径
        /// </summary>
        public const string WebStatusNotCheckIconUrl = "icon/gt.png";

        /// <summary>
        /// 开发者工具软件路径读取配置文件路径[根目录]
        /// </summary>
        public const string Appconfig = "appconfig.ini";

        /// <summary>
        /// 用户工具软件路径读取配置文件路径[根目录]
        /// </summary>
        public const string Userconfig = "userconfig.ini";

        /// <summary>
        /// 在线Web路径读取配置文件路径[根目录]
        /// </summary>
        public const string Onlineconfig = "onlineconfig.ini";

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string ConfigFilePath = UNDEFINE;

        /// <summary>
        /// 配置文件保存路径，若在客户机上第一次运行 内容则为默认常量属性[UNDEFINE]的值
        /// 若获取到的值为默认，则尝试调用Initialize函数进行加载配置
        /// </summary>
        public static string ConfigSavePath = UNDEFINE;

        /// <summary>
        /// 需要写入到磁盘中的配置文件信息
        /// 若获取到的值为默认，则尝试调用Initialize函数进行加载配置
        /// </summary>
        public const string ConfigWriteContent = UNDEFINE;

        /// <summary>
        /// 本地主机名
        /// 若获取到的值为默认，则尝试调用Initialize函数进行加载配置
        /// </summary>
        public static string LocalHostName = UNDEFINE;

        /// <summary>
        /// 本地IP地址
        /// 若获取到的值为默认，则尝试调用Initialize函数进行加载配置
        /// </summary>
        public static string LocalHostIPAddress = UNDEFINE;

        /// <summary>
        /// 本地计算机登陆用户名
        /// 若获取到的值为默认，则尝试调用Initialize函数进行加载配置
        /// </summary>
        public static string LocalLoginedUserName = UNDEFINE;

        /// <summary>
        /// 获取本地登录用户是否为管理员
        /// 若获取到的值为默认，则尝试调用Initialize函数进行加载配置
        /// </summary>
        public static bool LocalLoginedUserIsAdmin = false;

        /// <summary>
        /// 获取当前时间，默认为第一次访问该类的时间。
        /// 可以调用Initialize()函数刷新该数据
        /// </summary>
        public static DateTime CurrentDatetime = DateTime.Now;

        /// <summary>
        /// 获取操作系统版本号
        /// 若获取到的值为默认，则尝试调用Initialize函数进行加载配置
        /// </summary>
        public static string OperationVersionInformation = UNDEFINE;

        /// <summary>
        /// 配置或设置一些配置信息,其中包括当前系统的用户名,本地IP地址,当前登录用户是否为管理员...
        /// 在本类下其他数据为默认值时,可以尝试调用此函数查询并设置数据
        /// </summary>
        public static void Initialize()
        {
            LocalHostIPAddress = GetLocalHostIPAddress();//设置本地IP地址
            LocalHostName = System.Environment.MachineName;//设置本地计算机名
            LocalLoginedUserName = System.Environment.UserName;//设置本地计算机登陆用户名
            LocalLoginedUserIsAdmin = IsLocalHostLoginedAdmin();//设置本地计算机登陆用户类型[管理员|普通用户]
            CurrentDatetime = DateTime.Now;//设置当前时间
            OperationVersionInformation = GetOperationVersion();//设置操作系统版本号信息
        }

        /// <summary>
        /// 检查在客户机上是否为第一次使用
        /// </summary>
        /// <returns></returns>
        public static bool IsFirstUserd()
        {
            bool isFirstUserd = false;//默认为在此客户机上运行过
            ConfigFilePath = "config.ini";
            if (ConfigFilePath.Equals(UNDEFINE))
                return true;
            else
            {
                try
                {
                    FileInfo file = new FileInfo(Application.StartupPath + @"\" + ConfigFilePath);
                    if (!file.Exists)
                    {
                        isFirstUserd = true;
                        CanDoConfig = true;
                        return true;
                    }
                    else
                        CanDoConfig = false;
                    using (FileStream fs = new FileStream(ConfigFilePath, FileMode.Open))
                    {
                        StreamReader reader = new StreamReader(fs);
                        string currentLine = "";
                        List<string> strList = new List<string>();
                        while ((currentLine = reader.ReadLine()) != null)
                        {
                            strList.Add(currentLine);
                        }
                        foreach (string item in strList)
                        {
                            string[] reg = item.Split('=');
                            if (reg[0].Trim().Length != 0 && reg[1].Trim().Length == 0)
                            {
                                MessageBox.Show(string.Format("配置文件可能已经损坏,File path:[{0}].请检查并且联系管理员.", ConfigFilePath),
                                    "配置文件读取失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                CanDoConfig = false;//设置为不允许进入配置界面,因为配置文件存在,但是损坏状态
                                isFirstUserd = true;
                                break;
                            }
                            else
                                CanDoConfig = true;//设置为允许进入配置界面,配置文件允许打开[配置文件存在,但是内容为空]
                        }
                    }

                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show(string.Format("配置文件可能已经损坏,File path:[{0}].请检查并且联系管理员.", ConfigFilePath),
                                    "配置文件读取失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    isFirstUserd = true;
                }
                //检查配置文件[当前路径]是否有值
                return isFirstUserd;
            }
        }

        /// <summary>
        /// 获取操作系统版本号信息
        /// </summary>
        /// <returns></returns>
        public static string GetOperationVersion()
        {
            OperatingSystem os = System.Environment.OSVersion;
            PlatformID id = os.Platform;
            return "[OSVersion]=" + os.ToString() + "|[PlatformID]=" + id.ToString();
        }

        /// <summary>
        /// 获取本地主机IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetLocalHostIPAddress()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        /// <summary>
        /// 检查当前登录的用户是否为管理员
        /// </summary>
        /// <returns></returns>
        public static bool IsLocalHostLoginedAdmin()
        {
            if (Runcmd("net localgroup administrators |find \"%username%\"").IndexOf(System.Environment.UserName) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 控制台执行
        /// </summary>
        /// <param name="command">传入需要让cmd执行的命令</param>
        /// <returns>返回控制台的打印内容</returns>
        private static string Runcmd(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + command;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            return p.StandardOutput.ReadToEnd();
        }
    }
}
