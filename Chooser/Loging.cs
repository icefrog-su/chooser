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

namespace Chooser
{
    public partial class Loging : Form
    {
        public Loging()
        {
            InitializeComponent();
        }

        private int index = 0;

        //设置软件介绍窗体显示时间
        private void timerLogo_Tick(object sender, EventArgs e)
        {
            index++;
            if (index == 2)
            {
                timerLogo.Stop();
                this.Close();
            }
        }

        private void Loging_Load(object sender, EventArgs e)
        {
            timerLogo.Start();
        }
    }
}
