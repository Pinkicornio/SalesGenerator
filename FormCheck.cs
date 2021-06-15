using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace SalesGenerator
{
    public partial class FormCheck : Form
    {
        public FormCheck()
        {
            InitializeComponent();

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            StringBuilder sb = new StringBuilder();
            foreach (Check_info item in DataClass.checkInfoList)
            {
                sb.Append(item.Name + "|" + item.Brand + "|" + item.Price + "|" + item.Amount + "|" + item.Id + "|" + item.Date + ";");
            }
            int length = sb.Length;
            QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(sb.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCoder.QRCode(qrData);
            var image = qrCode.GetGraphic(150);
            pictureBox.Image = image;


            richTextBoxCheck.Text = string.Format("{0,-10} | {1,-10} | {2,-5} | {3,-5}\n", "PRODUCTO", "MARCA", "PRECIO", "CANTIDAD");

            float totalprice = 0;
            foreach (Check_info item in DataClass.checkInfoList)
            {
                richTextBoxCheck.Text += string.Format("{0,-10}  {1,-10}  {2,5}  {3,5}\r\n", item.Name, item.Brand, item.Price.ToString("c2"), item.Amount);
                richTextBoxCheck.Text = Regex.Replace(richTextBoxCheck.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);
                totalprice += item.Price;

            }

            richTextBoxCheck.Text += "----------------------------------------------\n";
            richTextBoxCheck.Text += string.Format("{0,40}\r\n", "Total: " + totalprice.ToString("c2"));


            DataClass.checkInfoList = new List<Check_info>();
        }
    }
}
