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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace Chooser
{
    public partial class inConfig : Form
    {
        public inConfig()
        {
            InitializeComponent();
        }

        private bool canDoConfigByAppconfig = false;
        private bool canDoConfigByUserTools = false;


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            string path = open.FileName;
            txt_toolurl.Text = path;

            //检查路径是否为可执行文件
            string url = txt_toolurl.Text.Trim();
            if (url.Length == 0 || url == null)
            {
                MessageBox.Show("请选择一个需要配置的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                canDoConfigByAppconfig = false;
                return;
            }
            //截取检查文件后缀名
            if (url.IndexOf('.') == -1)
            {
                MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_toolurl.SelectAll();
                txt_toolurl.Focus();
                canDoConfigByAppconfig = false;
                return;
            }
            string[] names = url.Split('.');
            string name = names[names.Length - 1];
            if (name.ToLower().Equals("exe") || name.ToLower().Equals("bat") || name.ToLower().Equals("jar") || name.ToLower().Equals("msi"))
            {
                FileInfo file = new FileInfo(url);
                if (file.Exists)
                {
                    //为可执行的程序,获取程序信息.
                    canDoConfigByAppconfig = true;
                    string date = file.CreationTime.ToString("yyyy-MM-dd");//文件创建时间
                    Icon icon = Icon.ExtractAssociatedIcon(url);//获取文件图标
                    bool isReadOnly = file.IsReadOnly;//文件是否只读
                    lb_filename.Text = file.Name;
                    lb_createtime.Text = date;
                    lb_url.Text = url;
                    lb_isreadonly.Text = isReadOnly ? "[是]" : "[否]";
                }
                else
                {
                    MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txt_toolurl.SelectAll();
                    txt_toolurl.Focus();
                    canDoConfigByAppconfig = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_toolurl.SelectAll();
                txt_toolurl.Focus();
                canDoConfigByAppconfig = false;
                return;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            writeConfig(lb_filename.Text.Trim(), lb_url.Text, Config.Appconfig);
            if (canDoConfigByAppconfig)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (this.progressBar1.Value < this.progressBar1.Maximum)
                    {
                        this.progressBar1.Value++;
                    }
                }
                //提示配置完成
                MessageBox.Show("配置完成");
            }
            else
            {
                MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        /// <summary>
        /// 写入配置文件
        /// </summary>
        private void writeConfig(string appName, string appPath, string configName)
        {
            if(appName.IndexOf('.')>-1)
              appName = appName.Substring(0, appName.IndexOf('.'));
            //MessageBox.Show(appName + "," + appPath);
            FileStream fs = new FileStream(configName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(System.Environment.NewLine + appName + "=" + appPath);
            sw.Close();
            fs.Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            string path = open.FileName;
            txt_choosePath.Text = path;

            //检查路径是否为可执行文件
            string url = txt_choosePath.Text.Trim();
            if (url.Length == 0 || url == null)
            {
                MessageBox.Show("请选择一个需要配置的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                canDoConfigByUserTools = false;
                return;
            }
            //截取检查文件后缀名
            if (url.IndexOf('.') == -1)
            {
                MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_choosePath.SelectAll();
                txt_choosePath.Focus();
                canDoConfigByUserTools = false;
                return;
            }
            string[] names = url.Split('.');
            string name = names[names.Length - 1];
            if (name.ToLower().Equals("exe") || name.ToLower().Equals("bat") || name.ToLower().Equals("jar") || name.ToLower().Equals("msi"))
            {
                FileInfo file = new FileInfo(url);
                if (file.Exists)
                {
                    //为可执行的程序,获取程序信息.
                    canDoConfigByUserTools = true;
                    string date = file.CreationTime.ToString("yyyy-MM-dd");//文件创建时间
                    Icon icon = Icon.ExtractAssociatedIcon(url);//获取文件图标
                    bool isReadOnly = file.IsReadOnly;//文件是否只读
                    lbs_filename.Text = file.Name;
                    lbs_fileCreateTime.Text = date;
                    lbs_filepath.Text = url;
                    lbs_isReadOnly.Text = isReadOnly ? "[是]" : "[否]";
                }
                else
                {
                    MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txt_choosePath.SelectAll();
                    txt_choosePath.Focus();
                    canDoConfigByUserTools = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_choosePath.SelectAll();
                txt_choosePath.Focus();
                canDoConfigByUserTools = false;
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            writeConfig(lbs_filename.Text, lbs_filepath.Text, Config.Userconfig);
            if (canDoConfigByUserTools)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (this.progressBar2.Value < this.progressBar2.Maximum)
                    {
                        this.progressBar2.Value++;
                    }
                }
                //提示配置完成
                MessageBox.Show("配置完成");
            }
            else
            {
                MessageBox.Show("必须配置可执行的软件路径!", "配置失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        /// <summary>
        /// 检查域名的三种状态
        /// iCheckStatus==0 未检查
        /// iCheckStatus==1 检查失败
        /// iCheckStatus==3 检查成功
        /// </summary>
        private int iCheckStatus = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                btn_checkStatus.Text = "Loading...";
                pb_status.BackgroundImage = Image.FromFile(Config.WebStatusLoadingIconUrl);
                //使用一个线程来检测url是否可以访问，防止主页面(主进程)假死状态.
                ThreadStart thread = new ThreadStart(delegate()
                {
                    try
                    {
                        Ping ping = new Ping();
                        PingReply reply = ping.Send(txt_webUrl.Text.Trim());
                        lb1.Text = reply.Address == null ? "获取失败.可尝试开启VPN连接" : reply.Address.ToString();
                        lb2.Text = reply.RoundtripTime.ToString();
                        lb3.Text = reply.Status.ToString();
                        if (reply.Status.Equals(IPStatus.Success))
                        {
                            this.iCheckStatus = 2;
                            pb_status.BackgroundImage = Image.FromFile(Config.WebStatusOKIconUrl);
                            btn_checkStatus.Text = "Ping";
                        }
                        else
                        {
                            this.iCheckStatus = 1;
                            pb_status.BackgroundImage = Image.FromFile(Config.WebStatusErrIconUrl);
                            btn_checkStatus.Text = "Ping";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "请检查请求地址是否正确或者网络连接是否打开.");
                        btn_checkStatus.Text = "Ping";
                        pb_status.BackgroundImage = Image.FromFile(Config.WebStatusErrIconUrl);
                    }
                });
                Thread t1 = new Thread(thread);
                t1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "请检查请求地址是否正确或者网络连接是否打开.");
                btn_checkStatus.Text = "Ping";
                pb_status.BackgroundImage = Image.FromFile(Config.WebStatusErrIconUrl);
            }
        }

        private void inConfig_Load(object sender, EventArgs e)
        {
            try
            {
                this.iCheckStatus = 0;
                pb_status.BackgroundImage = Image.FromFile(Config.WebStatusNotCheckIconUrl);

            }
            catch
            {
                MessageBox.Show("根目录图标文件可能出现损坏情况。", "图标", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txt_webUrl_TextChanged(object sender, EventArgs e)
        {
            this.iCheckStatus = 0;
            pb_status.BackgroundImage = Image.FromFile(Config.WebStatusNotCheckIconUrl);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (txt_webUrl.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入网站访问路径", "键入网站路径", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_webName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入网站名称[自定义输入]", "键入网站名称", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (iCheckStatus == 0)
            {
                DialogResult dr = MessageBox.Show("当前网络地址未检测,无法确保是否为可链接的目标主机,确定要保存到配置文件中吗?","未检测",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.No)
                    return;
            }
            if (iCheckStatus == 1)
            {
                DialogResult dr = MessageBox.Show("当前网络地址检测失败,保存到配置文件可能导致日后无法访问该主机,确定保存吗?", "检测失败", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.No)
                    return;
            }
            writeConfig(txt_webName.Text.Trim(), txt_webUrl.Text.Trim(), Config.Onlineconfig);
            for (int i = 0; i < 200; i++)
            {
                if (this.progressBar3.Value < this.progressBar3.Maximum)
                {
                    this.progressBar3.Value++;
                }
            }
            //提示配置完成
            MessageBox.Show("配置完成");
        }
    }
}