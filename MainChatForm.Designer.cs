namespace OnlyUsChat
{
    partial class MainChatForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(12, 12);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.ReadOnly = true;
            this.chatTextBox.Size = new System.Drawing.Size(677, 399);
            this.chatTextBox.TabIndex = 0;
            this.chatTextBox.Text = "";
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(12, 417);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(677, 21);
            this.sendTextBox.TabIndex = 1;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendTextBox_KeyDown);
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(695, 417);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(97, 23);
            this.send_btn.TabIndex = 2;
            this.send_btn.Text = "전송";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // MainChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.chatTextBox);
            this.Name = "MainChatForm";
            this.Text = "OnlyUsChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button send_btn;
    }
}

