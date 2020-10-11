namespace OnlyUsChat
{
    partial class SelectModeForm
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
            this.server_btn = new System.Windows.Forms.Button();
            this.client_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // server_btn
            // 
            this.server_btn.Location = new System.Drawing.Point(12, 12);
            this.server_btn.Name = "server_btn";
            this.server_btn.Size = new System.Drawing.Size(229, 74);
            this.server_btn.TabIndex = 0;
            this.server_btn.Text = "서버모드";
            this.server_btn.UseVisualStyleBackColor = true;
            this.server_btn.Click += new System.EventHandler(this.ServerMode_Click);
            // 
            // client_btn
            // 
            this.client_btn.Location = new System.Drawing.Point(12, 92);
            this.client_btn.Name = "client_btn";
            this.client_btn.Size = new System.Drawing.Size(229, 74);
            this.client_btn.TabIndex = 1;
            this.client_btn.Text = "클라모드";
            this.client_btn.UseVisualStyleBackColor = true;
            this.client_btn.Click += new System.EventHandler(this.ClientMode_Click);
            // 
            // SelectModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 234);
            this.Controls.Add(this.client_btn);
            this.Controls.Add(this.server_btn);
            this.Name = "SelectModeForm";
            this.Text = "모드 선택";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button server_btn;
        private System.Windows.Forms.Button client_btn;
    }
}