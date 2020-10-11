namespace OnlyUsChat_SERVER
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consoleTextBox = new System.Windows.Forms.RichTextBox();
            this.exAddressTxtBox = new System.Windows.Forms.TextBox();
            this.exlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inAddressTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(7, 12);
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.Size = new System.Drawing.Size(647, 423);
            this.consoleTextBox.TabIndex = 0;
            this.consoleTextBox.Text = "";
            // 
            // exAddressTxtBox
            // 
            this.exAddressTxtBox.Location = new System.Drawing.Point(660, 30);
            this.exAddressTxtBox.Name = "exAddressTxtBox";
            this.exAddressTxtBox.ReadOnly = true;
            this.exAddressTxtBox.Size = new System.Drawing.Size(124, 21);
            this.exAddressTxtBox.TabIndex = 1;
            // 
            // exlbl
            // 
            this.exlbl.AutoSize = true;
            this.exlbl.Location = new System.Drawing.Point(662, 15);
            this.exlbl.Name = "exlbl";
            this.exlbl.Size = new System.Drawing.Size(97, 12);
            this.exlbl.TabIndex = 2;
            this.exlbl.Text = "외부아이피 주소:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "내부아이피 주소 :";
            // 
            // inAddressTxtBox
            // 
            this.inAddressTxtBox.Location = new System.Drawing.Point(660, 93);
            this.inAddressTxtBox.Name = "inAddressTxtBox";
            this.inAddressTxtBox.ReadOnly = true;
            this.inAddressTxtBox.Size = new System.Drawing.Size(124, 21);
            this.inAddressTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(662, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "포트 번호 :";
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(660, 158);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.ReadOnly = true;
            this.portTxtBox.Size = new System.Drawing.Size(124, 21);
            this.portTxtBox.TabIndex = 5;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inAddressTxtBox);
            this.Controls.Add(this.exlbl);
            this.Controls.Add(this.exAddressTxtBox);
            this.Controls.Add(this.consoleTextBox);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox consoleTextBox;
        private System.Windows.Forms.TextBox exAddressTxtBox;
        private System.Windows.Forms.Label exlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inAddressTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTxtBox;
    }
}