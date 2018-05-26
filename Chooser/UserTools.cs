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

namespace Chooser
{
    public partial class UserTools : Form
    {
        public UserTools()
        {
            InitializeComponent();
        }

        private void UserTools_Load(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> dicList = GetUserLog(Config.Userconfig);
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(32, 32);
                lv_workspace.LargeImageList = imgList;
                lv_workspace.SmallImageList = imgList;
                int index = 0;

                foreach (KeyValuePair<string, string> item in dicList)
                {
                    Console.WriteLine(item.Key + "," + item.Value);
                    FileInfo currentFile = new FileInfo(item.Value);
                    ListViewItem lvi = new ListViewItem(currentFile.Name.Split('.')[0]);
                    lvi.Tag = item.Value;
                    Icon icon = Icon.ExtractAssociatedIcon(item.Value);
                    imgList.Images.Add(icon);
                    lvi.ImageIndex = index;
                    index++;
                    lv_workspace.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载软件路径失败,配置文件可能已经损坏。 " + System.Environment.NewLine + "系统错误码：" + System.Environment.NewLine + ex.Message);
            }
        }
        /// <summary>
        /// 获取用户工具中所有的数据
        ///     Key：开发工具名.
        ///     Value：开发工具所处路径.
        /// </summary>
        /// <param name="apppath">用户工具数据查找配置文件路径</param>
        /// <returns>Dictionary</returns>
        private Dictionary<string, string> GetUserLog(string apppath)
        {
            //[software]=[path]
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            using (FileStream fileStream = new FileStream(apppath, FileMode.Open))
            {
                StreamReader reader = new StreamReader(fileStream, Encoding.Default);
                string readLine = "";
                while ((readLine = reader.ReadLine()) != null)
                {
                    if (readLine.Split('=').Length != 2)
                        continue;
                    string name = readLine.Split('=')[0];
                    string path = readLine.Split('=')[1];
                    if (dicList.ContainsKey(name))
                        continue;
                    dicList.Add(name, path);
                }
            }
            return dicList;
        }

        private void lv_workspace_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lv_workspace.SelectedItems.Count >= 0)
                {
                    string path = lv_workspace.SelectedItems[0].Tag.ToString();
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开软件时出现了不可预知的错误，错误信息为:" + System.Environment.NewLine + ex.Message, "软件打开异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
