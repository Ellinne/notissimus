using notissimus.Core;
using notissimus.Core.Site;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notissimus
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                   new SiteParser()
               );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Continue...");
        }

        private void button1_Click(object sender, EventArgs e)  //Start
        {
            listBox1.Items.Clear();
            parser.Settings = new SiteSettings((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            parser.Start();
        }

        private void button2_Click(object sender, EventArgs e)  //Abort
        {
            parser.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter myOutputStream = new StreamWriter("Import.csv", false, System.Text.Encoding.GetEncoding("Windows-1251"));

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (String.IsNullOrEmpty(listBox1.Items[i].ToString()))
                {
                    listBox1.Items.RemoveAt(i--);
                }
            }

            foreach (var item in listBox1.Items)
            {
                myOutputStream.WriteLine(item.ToString());
            }

            myOutputStream.Close();
        }
    }
}
