namespace DbConfigEditor.Forms
{
    partial class DbConfigMainForm
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
            label1 = new Label();
            txtSourceAddr = new TextBox();
            label2 = new Label();
            txtSourceDbName = new TextBox();
            label3 = new Label();
            txtSourceId = new TextBox();
            label4 = new Label();
            txtSourcePassword = new TextBox();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            label6 = new Label();
            txtTargetAddr = new TextBox();
            txtTargetPassword = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtTargetDbName = new TextBox();
            txtTargetId = new TextBox();
            label9 = new Label();
            groupBox1 = new GroupBox();
            panel2 = new Panel();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnClose = new Button();
            btnSave = new Button();
            btnKeygen = new Button();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 38);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "DB주소";
            // 
            // txtSourceAddr
            // 
            txtSourceAddr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSourceAddr.Location = new Point(78, 36);
            txtSourceAddr.Name = "txtSourceAddr";
            txtSourceAddr.Size = new Size(160, 23);
            txtSourceAddr.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 67);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "DB이름";
            // 
            // txtSourceDbName
            // 
            txtSourceDbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSourceDbName.Location = new Point(78, 65);
            txtSourceDbName.Name = "txtSourceDbName";
            txtSourceDbName.Size = new Size(160, 23);
            txtSourceDbName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 96);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "로그인ID";
            // 
            // txtSourceId
            // 
            txtSourceId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSourceId.Location = new Point(78, 94);
            txtSourceId.Name = "txtSourceId";
            txtSourceId.Size = new Size(160, 23);
            txtSourceId.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 125);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 6;
            label4.Text = "비밀번호";
            // 
            // txtSourcePassword
            // 
            txtSourcePassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSourcePassword.Location = new Point(78, 123);
            txtSourcePassword.Name = "txtSourcePassword";
            txtSourcePassword.Size = new Size(160, 23);
            txtSourcePassword.TabIndex = 7;
            txtSourcePassword.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(574, 207);
            panel1.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtTargetAddr);
            groupBox2.Controls.Add(txtTargetPassword);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtTargetDbName);
            groupBox2.Controls.Add(txtTargetId);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(296, 17);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(267, 172);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "저장DB";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 38);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 2;
            label6.Text = "DB주소";
            // 
            // txtTargetAddr
            // 
            txtTargetAddr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTargetAddr.Location = new Point(78, 36);
            txtTargetAddr.Name = "txtTargetAddr";
            txtTargetAddr.Size = new Size(160, 23);
            txtTargetAddr.TabIndex = 0;
            // 
            // txtTargetPassword
            // 
            txtTargetPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTargetPassword.Location = new Point(78, 123);
            txtTargetPassword.Name = "txtTargetPassword";
            txtTargetPassword.Size = new Size(160, 23);
            txtTargetPassword.TabIndex = 7;
            txtTargetPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 67);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 3;
            label7.Text = "DB이름";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 125);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 6;
            label8.Text = "비밀번호";
            // 
            // txtTargetDbName
            // 
            txtTargetDbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTargetDbName.Location = new Point(78, 65);
            txtTargetDbName.Name = "txtTargetDbName";
            txtTargetDbName.Size = new Size(160, 23);
            txtTargetDbName.TabIndex = 1;
            // 
            // txtTargetId
            // 
            txtTargetId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTargetId.Location = new Point(78, 94);
            txtTargetId.Name = "txtTargetId";
            txtTargetId.Size = new Size(160, 23);
            txtTargetId.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 96);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 4;
            label9.Text = "로그인ID";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSourceAddr);
            groupBox1.Controls.Add(txtSourcePassword);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtSourceDbName);
            groupBox1.Controls.Add(txtSourceId);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(267, 172);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "조회DB";
            // 
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(5, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(574, 49);
            panel2.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label5.Location = new Point(12, 13);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 0;
            label5.Text = "DB설정";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnKeygen);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(5, 261);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(574, 40);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(406, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(165, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "닫기";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(235, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(165, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "저장";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnKeygen
            // 
            btnKeygen.Location = new Point(64, 3);
            btnKeygen.Name = "btnKeygen";
            btnKeygen.Size = new Size(165, 30);
            btnKeygen.TabIndex = 2;
            btnKeygen.Text = "키 생성";
            btnKeygen.UseVisualStyleBackColor = true;
            // 
            // DbConfigMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 306);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel2);
            Name = "DbConfigMainForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DbConfig Editor";
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox txtSourceAddr;
        private Label label2;
        private TextBox txtSourceDbName;
        private Label label3;
        private TextBox txtSourceId;
        private Label label4;
        private TextBox txtSourcePassword;
        private Panel panel1;
        private Panel panel2;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSave;
        private Button btnClose;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label6;
        private TextBox txtTargetAddr;
        private TextBox txtTargetPassword;
        private Label label7;
        private Label label8;
        private TextBox txtTargetDbName;
        private TextBox txtTargetId;
        private Label label9;
        private Button btnKeygen;
    }
}