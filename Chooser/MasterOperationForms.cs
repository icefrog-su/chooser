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
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace Chooser
{
    public partial class MasterOperationForms : Form
    {
        public MasterOperationForms()
        {
            InitializeComponent();
        }

        //实现窗体特效
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarinset);
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Right;
            public int left;
            public int Top;
            public int Bottom;
        }

        private void MasterOperationForms_Load(object sender, EventArgs e)
        {
            
            //检查在客户机上是否为第一次启动
            if (Config.IsFirstUserd())
            {//第一次运行在此客户机上的代码块
                //拿到当前运行的程序的绝对路径
                //Application.StartupPath
                //检查是否具备打开配置窗体的条件
                if (Config.CanDoConfig)
                {
                    ConfigForm cf = new ConfigForm();
                    cf.ShowDialog();
                }
            }
            else
            {
                //MessageBox.Show(Application.StartupPath);
               
            }
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            this.btn_Development.Size = new Size(100,100);
        }

        private void btn_Development_MouseLeave(object sender, EventArgs e)
        {
            this.btn_Development.Size = new Size(91,91);
        }

        private void btn_Development_Click(object sender, EventArgs e)
        {
            DeveloperInfo dev = new DeveloperInfo();
            dev.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            ut.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OnlineWeb ow = new OnlineWeb();
            ow.Show();
        }

        private void btn_Tools_MouseLeave(object sender, EventArgs e)
        {
            this.btn_Tools.Size = new Size(91, 91);
        }

        private void btn_Tools_MouseMove(object sender, MouseEventArgs e)
        {
            this.btn_Tools.Size = new Size(100, 100);
        }

        private void btn_Player_MouseLeave(object sender, EventArgs e)
        {
            this.btn_Player.Size = new Size(91, 91);
        }

        private void btn_Player_MouseMove(object sender, MouseEventArgs e)
        {
            this.btn_Player.Size = new Size(100, 100);
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            //TODO 配置按钮目前是单独配置开发工具, 应该更改为可以选择三个配置选项 可以使用下拉列表 或者使用新窗体


            for (int i = 0; i < 100; i++)
            {
                if (progressBarConfig.Value < progressBarConfig.Maximum)
                {
                    this.progressBarConfig.Value++;
                }
                if (this.progressBarConfig.Value == this.progressBarConfig.Maximum)
                {
                    break;
                }
            }
            inConfig inc = new inConfig();
            inc.ShowDialog();
            this.progressBarConfig.Value = 0;
        }

        /// <summary>
        /// 手动配置开发工具配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void developerToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Config.Appconfig);
        }

        /// <summary>
        /// 手动配置用户工具配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Config.Userconfig);
        }

        /// <summary>
        /// 手动配置在线网站工具配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onlineWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Config.Onlineconfig);
        }
    }
}
