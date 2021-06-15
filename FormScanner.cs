using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace SalesGenerator
{
    public partial class FormScanner : Form
    {


        public FormScanner()
        {
            InitializeComponent();
            initConfig();
            DataClass.startConnection();
        }

        private void initConfig()
        {
            richTextBoxSale.Text = string.Format("{0,-20} | {1,-20} | {2,-10} | {3,-5}\n", "PRODUCTO", "MARCA", "PRECIO", "CANTIDAD");
            DataClass.checkInfoList = new List<Check_info>();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int quantity = 1;
            int line = 1;

            textBoxReader.Select();

            foreach (Check_info item in DataClass.checkInfoList)//count same product
            {
                if (item.Id.ToString().Equals(textBoxReader.Text))
                {
                    quantity = item.Amount + 1;
                }
            }

            foreach (Check_info item in DataClass.checkInfoList)//finds product on first line
            {
                line++;
                if (item.Id.ToString().Equals(textBoxReader.Text))
                {
                    break;
                }
            }

            sb = DataClass.selectProductManage(textBoxReader.Text, quantity);

            if (quantity > 1)
            {
                changeLine(richTextBoxSale, line - 1, sb.ToString());
            }
            else
            {
                richTextBoxSale.Text += sb.ToString();
            }

            richTextBoxSale.Text = Regex.Replace(richTextBoxSale.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);
            textBoxReader.Clear();
        }

       

        void changeLine(RichTextBox RTB, int line, string text)
        {
            int s1 = RTB.GetFirstCharIndexFromLine(line);
            int s2 = line < RTB.Lines.Count() - 1 ?
                      RTB.GetFirstCharIndexFromLine(line + 1) - 1 :
                      RTB.Text.Length;
            RTB.Select(s1, s2 - s1);
            RTB.SelectedText = text;
        }

        private void textBoxReader_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            FormRemover formchk = new FormRemover();
            formchk.FormClosed += FormRemover_FormClosed;
            formchk.Show();
            timer1.Start();
        }

        private void FormRemover_FormClosed(object sender, FormClosedEventArgs e)
        {
            richTextBoxSale.Text = string.Format("{0,-20} | {1,-20} | {2,-10} | {3,-5}\n", "PRODUCTO", "MARCA", "PRECIO", "CANTIDAD");

            timer1.Start();
            for (int i = 0; i < DataClass.checkInfoList.Count; i++)
            {
                if  (DataClass.checkInfoList[i].Amount == 0)
                {
                    DataClass.checkInfoList.Remove(DataClass.checkInfoList[i]);
                }
            }

            for (int i = 0; i < DataClass.checkInfoList.Count; i++)
            {
                richTextBoxSale.Text += string.Format("{0,-20} | {1,-20} | {2,-10} | {3,-5}\n", DataClass.checkInfoList[i].Name, DataClass.checkInfoList[i].Brand, DataClass.checkInfoList[i].Price.ToString("c2"), "X" + DataClass.checkInfoList[i].Amount);

            }
            richTextBoxSale.Text = Regex.Replace(richTextBoxSale.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);

        }



        private void FormCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataClass.checkInfoList = new List<Check_info>();
            richTextBoxSale.Text = string.Format("{0,-20} | {1,-20} | {2,-10} | {3,-5}\n", "PRODUCTO", "MARCA", "PRECIO", "CANTIDAD");
            timer1.Start();
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            richTextBoxSale.Clear();
            initConfig();
        }

        private void buttonDelete_Enter(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void buttonDelete_Leave(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            insertSale();
            FormCheck formchk = new FormCheck();
            formchk.Show();
        }

        private bool insertSale()
        {
            int sale_id = 0;

            try
            {
                timer1.Stop();
                DataClass.stopConnection();
                DataClass.startConnection();

                DataClass.insertSale();
                sale_id = DataClass.getLastSale();

                DataClass.sequentialInserSales_detail(sale_id);

                richTextBoxSale.Text = string.Format("{0,-20} | {1,-20} | {2,-10} | {3,-5}\n", "PRODUCTO", "MARCA", "PRECIO", "CANTIDAD");
                timer1.Start();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

