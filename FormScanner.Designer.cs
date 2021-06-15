
namespace SalesGenerator
{
    partial class FormScanner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScanner));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.richTextBoxSale = new System.Windows.Forms.RichTextBox();
            this.textBoxReader = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BackgroundImage = global::SalesGenerator.Properties.Resources.background;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.buttonRemoveItem);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonAccept);
            this.panel1.Controls.Add(this.richTextBoxSale);
            this.panel1.Controls.Add(this.textBoxReader);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 607);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::SalesGenerator.Properties.Resources.shopfy;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::SalesGenerator.Properties.Resources.shopfy;
            this.pictureBox1.Location = new System.Drawing.Point(271, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 50);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Location = new System.Drawing.Point(10, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 12);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(10, 547);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 12);
            this.panel3.TabIndex = 7;
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.buttonRemoveItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRemoveItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRemoveItem.Location = new System.Drawing.Point(468, 564);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(124, 33);
            this.buttonRemoveItem.TabIndex = 6;
            this.buttonRemoveItem.Text = "Remove";
            this.buttonRemoveItem.UseVisualStyleBackColor = false;
            this.buttonRemoveItem.Click += new System.EventHandler(this.button1_Click);
            this.buttonRemoveItem.Enter += new System.EventHandler(this.buttonDelete_Enter);
            this.buttonRemoveItem.Leave += new System.EventHandler(this.buttonDelete_Leave);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDelete.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDelete.Location = new System.Drawing.Point(10, 565);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(124, 32);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Reset";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.Enter += new System.EventHandler(this.buttonDelete_Enter);
            this.buttonDelete.Leave += new System.EventHandler(this.buttonDelete_Leave);
            // 
            // buttonAccept
            // 
            this.buttonAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.buttonAccept.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAccept.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAccept.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAccept.Location = new System.Drawing.Point(140, 565);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(322, 32);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            this.buttonAccept.Enter += new System.EventHandler(this.buttonDelete_Enter);
            this.buttonAccept.Leave += new System.EventHandler(this.buttonDelete_Leave);
            // 
            // richTextBoxSale
            // 
            this.richTextBoxSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxSale.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxSale.Location = new System.Drawing.Point(10, 79);
            this.richTextBoxSale.Name = "richTextBoxSale";
            this.richTextBoxSale.Size = new System.Drawing.Size(582, 462);
            this.richTextBoxSale.TabIndex = 1;
            this.richTextBoxSale.Text = "";
            // 
            // textBoxReader
            // 
            this.textBoxReader.Location = new System.Drawing.Point(10, 492);
            this.textBoxReader.Name = "textBoxReader";
            this.textBoxReader.Size = new System.Drawing.Size(100, 23);
            this.textBoxReader.TabIndex = 3;
            this.textBoxReader.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxReader_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(628, 630);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBoxSale;
        private System.Windows.Forms.TextBox textBoxReader;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

