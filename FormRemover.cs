using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SalesGenerator
{
    public partial class FormRemover : Form
    {



        public FormRemover()
        {
            InitializeComponent();
            initConfig();
            DataClass.startConnection();
        }

        private void initConfig()
        {
            richTextBoxSale.Text = string.Format("{0,-20} | {1,-20} | {2,-10} | {3,-5}\n", "PRODUCTO", "MARCA", "PRECIO", "CANTIDAD");
            DataClass.removedInfoList = new List<Check_info>();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int quantity = 1;
            int line = 1;

            textBoxReader.Select();

            foreach (Check_info item in DataClass.removedInfoList)//count same product
            {
                if (item.Id.ToString().Equals(textBoxReader.Text))
                {
                    quantity = item.Amount + 1;
                }
            }

            foreach (Check_info item in DataClass.removedInfoList)//finds product on first line
            {
                line++;
                if (item.Id.ToString().Equals(textBoxReader.Text))
                {
                    break;
                }
            }

            sb = DataClass.selectProductManageRemover(textBoxReader.Text, quantity);

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
            removeItem();
            this.Close();
        }

        private void removeItem()
        {

            foreach (Check_info item in DataClass.removedInfoList)
            {
                foreach (Check_info el in DataClass.checkInfoList)
                {
                    if (item.Id.ToString().Equals(el.Id.ToString()))
                    {
                        el.Amount = el.Amount - item.Amount;
                        el.Price = el.Price - item.Price;

                        int mstockremove = item.Market_stock;
                        int mstockadd = el.Market_stock;

                        el.Market_stock = el.Market_stock + item.Market_stock;
                    }
                }
            }
        }

    }
}
