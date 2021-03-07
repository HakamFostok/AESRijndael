namespace AesInterface
{
    partial class FrmAesRijndael
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.lblPlainText = new System.Windows.Forms.Label();
            this.richtxtPlain = new System.Windows.Forms.RichTextBox();
            this.lblCipher = new System.Windows.Forms.Label();
            this.richtxtCipher = new System.Windows.Forms.RichTextBox();
            this.grpBxLang = new System.Windows.Forms.GroupBox();
            this.rdbtnEnglish = new System.Windows.Forms.RadioButton();
            this.rdbtnArabic = new System.Windows.Forms.RadioButton();
            this.grpBxAESKind = new System.Windows.Forms.GroupBox();
            this.rdbtnAES256 = new System.Windows.Forms.RadioButton();
            this.rdbtnAES192 = new System.Windows.Forms.RadioButton();
            this.rdbtnAES128 = new System.Windows.Forms.RadioButton();
            this.lblKey = new System.Windows.Forms.Label();
            this.grpBxEncDec = new System.Windows.Forms.GroupBox();
            this.rdbtnEncrpyt = new System.Windows.Forms.RadioButton();
            this.rdbtnDecrypt = new System.Windows.Forms.RadioButton();
            this.txtbxKey = new System.Windows.Forms.TextBox();
            this.grpBxKey = new System.Windows.Forms.GroupBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblMaxLength = new System.Windows.Forms.Label();
            this.btnEncryptDecrypt = new System.Windows.Forms.Button();
            this.grpBxText = new System.Windows.Forms.GroupBox();
            this.fontDialogText = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.grpBxLang.SuspendLayout();
            this.grpBxAESKind.SuspendLayout();
            this.grpBxEncDec.SuspendLayout();
            this.grpBxKey.SuspendLayout();
            this.grpBxText.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(8, 19);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.lblPlainText);
            this.splitContainerMain.Panel1.Controls.Add(this.richtxtPlain);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.lblCipher);
            this.splitContainerMain.Panel2.Controls.Add(this.richtxtCipher);
            this.splitContainerMain.Size = new System.Drawing.Size(971, 376);
            this.splitContainerMain.SplitterDistance = 483;
            this.splitContainerMain.TabIndex = 0;
            // 
            // lblPlainText
            // 
            this.lblPlainText.AutoSize = true;
            this.lblPlainText.Location = new System.Drawing.Point(3, 15);
            this.lblPlainText.Name = "lblPlainText";
            this.lblPlainText.Size = new System.Drawing.Size(0, 13);
            this.lblPlainText.TabIndex = 1;
            // 
            // richtxtPlain
            // 
            this.richtxtPlain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richtxtPlain.Location = new System.Drawing.Point(3, 31);
            this.richtxtPlain.Name = "richtxtPlain";
            this.richtxtPlain.Size = new System.Drawing.Size(477, 334);
            this.richtxtPlain.TabIndex = 0;
            this.richtxtPlain.Text = "00112233445566778899aabbccddeeff";
            // 
            // lblCipher
            // 
            this.lblCipher.AutoSize = true;
            this.lblCipher.Location = new System.Drawing.Point(3, 15);
            this.lblCipher.Name = "lblCipher";
            this.lblCipher.Size = new System.Drawing.Size(0, 13);
            this.lblCipher.TabIndex = 1;
            // 
            // richtxtCipher
            // 
            this.richtxtCipher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richtxtCipher.Location = new System.Drawing.Point(3, 31);
            this.richtxtCipher.Name = "richtxtCipher";
            this.richtxtCipher.Size = new System.Drawing.Size(470, 334);
            this.richtxtCipher.TabIndex = 1;
            this.richtxtCipher.Text = "";
            // 
            // grpBxLang
            // 
            this.grpBxLang.Controls.Add(this.rdbtnEnglish);
            this.grpBxLang.Controls.Add(this.rdbtnArabic);
            this.grpBxLang.Location = new System.Drawing.Point(12, 12);
            this.grpBxLang.Name = "grpBxLang";
            this.grpBxLang.Size = new System.Drawing.Size(120, 98);
            this.grpBxLang.TabIndex = 2;
            this.grpBxLang.TabStop = false;
            // 
            // rdbtnEnglish
            // 
            this.rdbtnEnglish.AutoSize = true;
            this.rdbtnEnglish.Location = new System.Drawing.Point(15, 43);
            this.rdbtnEnglish.Name = "rdbtnEnglish";
            this.rdbtnEnglish.Size = new System.Drawing.Size(14, 13);
            this.rdbtnEnglish.TabIndex = 0;
            this.rdbtnEnglish.Tag = "1";
            this.rdbtnEnglish.UseVisualStyleBackColor = true;
            this.rdbtnEnglish.CheckedChanged += new System.EventHandler(this.rdbtnLanguage_CheckedChanged);
            // 
            // rdbtnArabic
            // 
            this.rdbtnArabic.AutoSize = true;
            this.rdbtnArabic.Location = new System.Drawing.Point(15, 20);
            this.rdbtnArabic.Name = "rdbtnArabic";
            this.rdbtnArabic.Size = new System.Drawing.Size(14, 13);
            this.rdbtnArabic.TabIndex = 0;
            this.rdbtnArabic.Tag = "0";
            this.rdbtnArabic.UseVisualStyleBackColor = true;
            this.rdbtnArabic.CheckedChanged += new System.EventHandler(this.rdbtnLanguage_CheckedChanged);
            // 
            // grpBxAESKind
            // 
            this.grpBxAESKind.Controls.Add(this.rdbtnAES256);
            this.grpBxAESKind.Controls.Add(this.rdbtnAES192);
            this.grpBxAESKind.Controls.Add(this.rdbtnAES128);
            this.grpBxAESKind.Location = new System.Drawing.Point(264, 12);
            this.grpBxAESKind.Name = "grpBxAESKind";
            this.grpBxAESKind.Size = new System.Drawing.Size(118, 98);
            this.grpBxAESKind.TabIndex = 2;
            this.grpBxAESKind.TabStop = false;
            // 
            // rdbtnAES256
            // 
            this.rdbtnAES256.AutoSize = true;
            this.rdbtnAES256.Location = new System.Drawing.Point(15, 66);
            this.rdbtnAES256.Name = "rdbtnAES256";
            this.rdbtnAES256.Size = new System.Drawing.Size(14, 13);
            this.rdbtnAES256.TabIndex = 0;
            this.rdbtnAES256.Tag = "2";
            this.rdbtnAES256.UseVisualStyleBackColor = true;
            this.rdbtnAES256.CheckedChanged += new System.EventHandler(this.rdbtnAESAlgo_CheckedChanged);
            // 
            // rdbtnAES192
            // 
            this.rdbtnAES192.AutoSize = true;
            this.rdbtnAES192.Location = new System.Drawing.Point(15, 43);
            this.rdbtnAES192.Name = "rdbtnAES192";
            this.rdbtnAES192.Size = new System.Drawing.Size(14, 13);
            this.rdbtnAES192.TabIndex = 0;
            this.rdbtnAES192.Tag = "1";
            this.rdbtnAES192.UseVisualStyleBackColor = true;
            this.rdbtnAES192.CheckedChanged += new System.EventHandler(this.rdbtnAESAlgo_CheckedChanged);
            // 
            // rdbtnAES128
            // 
            this.rdbtnAES128.AutoSize = true;
            this.rdbtnAES128.Checked = true;
            this.rdbtnAES128.Location = new System.Drawing.Point(15, 20);
            this.rdbtnAES128.Name = "rdbtnAES128";
            this.rdbtnAES128.Size = new System.Drawing.Size(14, 13);
            this.rdbtnAES128.TabIndex = 0;
            this.rdbtnAES128.TabStop = true;
            this.rdbtnAES128.Tag = "0";
            this.rdbtnAES128.UseVisualStyleBackColor = true;
            this.rdbtnAES128.CheckedChanged += new System.EventHandler(this.rdbtnAESAlgo_CheckedChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(6, 19);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(0, 13);
            this.lblKey.TabIndex = 3;
            // 
            // grpBxEncDec
            // 
            this.grpBxEncDec.Controls.Add(this.rdbtnEncrpyt);
            this.grpBxEncDec.Controls.Add(this.rdbtnDecrypt);
            this.grpBxEncDec.Location = new System.Drawing.Point(138, 12);
            this.grpBxEncDec.Name = "grpBxEncDec";
            this.grpBxEncDec.Size = new System.Drawing.Size(120, 98);
            this.grpBxEncDec.TabIndex = 2;
            this.grpBxEncDec.TabStop = false;
            // 
            // rdbtnEncrpyt
            // 
            this.rdbtnEncrpyt.AutoSize = true;
            this.rdbtnEncrpyt.Checked = true;
            this.rdbtnEncrpyt.Location = new System.Drawing.Point(6, 19);
            this.rdbtnEncrpyt.Name = "rdbtnEncrpyt";
            this.rdbtnEncrpyt.Size = new System.Drawing.Size(14, 13);
            this.rdbtnEncrpyt.TabIndex = 0;
            this.rdbtnEncrpyt.TabStop = true;
            this.rdbtnEncrpyt.Tag = "0";
            this.rdbtnEncrpyt.UseVisualStyleBackColor = true;
            this.rdbtnEncrpyt.CheckedChanged += new System.EventHandler(this.rdbtnEncrpyt_CheckedChanged);
            // 
            // rdbtnDecrypt
            // 
            this.rdbtnDecrypt.AutoSize = true;
            this.rdbtnDecrypt.Location = new System.Drawing.Point(6, 42);
            this.rdbtnDecrypt.Name = "rdbtnDecrypt";
            this.rdbtnDecrypt.Size = new System.Drawing.Size(14, 13);
            this.rdbtnDecrypt.TabIndex = 0;
            this.rdbtnDecrypt.Tag = "1";
            this.rdbtnDecrypt.UseVisualStyleBackColor = true;
            this.rdbtnDecrypt.CheckedChanged += new System.EventHandler(this.rdbtnDecrypt_CheckedChanged);
            // 
            // txtbxKey
            // 
            this.txtbxKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxKey.Location = new System.Drawing.Point(101, 17);
            this.txtbxKey.Name = "txtbxKey";
            this.txtbxKey.Size = new System.Drawing.Size(393, 20);
            this.txtbxKey.TabIndex = 4;
            this.txtbxKey.Text = "000102030405060708090a0b0c0d0e0f";
            // 
            // grpBxKey
            // 
            this.grpBxKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBxKey.Controls.Add(this.btnFont);
            this.grpBxKey.Controls.Add(this.btnFormat);
            this.grpBxKey.Controls.Add(this.btnClear);
            this.grpBxKey.Controls.Add(this.btnAbout);
            this.grpBxKey.Controls.Add(this.lblMaxLength);
            this.grpBxKey.Controls.Add(this.btnEncryptDecrypt);
            this.grpBxKey.Controls.Add(this.txtbxKey);
            this.grpBxKey.Controls.Add(this.lblKey);
            this.grpBxKey.Location = new System.Drawing.Point(388, 12);
            this.grpBxKey.Name = "grpBxKey";
            this.grpBxKey.Size = new System.Drawing.Size(609, 98);
            this.grpBxKey.TabIndex = 2;
            this.grpBxKey.TabStop = false;
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(241, 43);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 23);
            this.btnFormat.TabIndex = 1;
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(241, 69);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(102, 69);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(130, 23);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblMaxLength
            // 
            this.lblMaxLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxLength.AutoSize = true;
            this.lblMaxLength.Location = new System.Drawing.Point(500, 19);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(0, 13);
            this.lblMaxLength.TabIndex = 1;
            // 
            // btnEncryptDecrypt
            // 
            this.btnEncryptDecrypt.Location = new System.Drawing.Point(102, 42);
            this.btnEncryptDecrypt.Name = "btnEncryptDecrypt";
            this.btnEncryptDecrypt.Size = new System.Drawing.Size(130, 23);
            this.btnEncryptDecrypt.TabIndex = 5;
            this.btnEncryptDecrypt.UseVisualStyleBackColor = true;
            this.btnEncryptDecrypt.Click += new System.EventHandler(this.btnEncryptDecrypt_Click);
            // 
            // grpBxText
            // 
            this.grpBxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBxText.Controls.Add(this.splitContainerMain);
            this.grpBxText.Location = new System.Drawing.Point(12, 116);
            this.grpBxText.Name = "grpBxText";
            this.grpBxText.Size = new System.Drawing.Size(985, 401);
            this.grpBxText.TabIndex = 3;
            this.grpBxText.TabStop = false;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(322, 69);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 4;
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // FrmAesRijndael
            // 
            this.AcceptButton = this.btnEncryptDecrypt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 529);
            this.Controls.Add(this.grpBxText);
            this.Controls.Add(this.grpBxKey);
            this.Controls.Add(this.grpBxEncDec);
            this.Controls.Add(this.grpBxAESKind);
            this.Controls.Add(this.grpBxLang);
            this.MinimumSize = new System.Drawing.Size(1025, 567);
            this.Name = "FrmAesRijndael";
            this.Text = "AES Rijndael Algorithm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAesRijndael_FormClosing);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.grpBxLang.ResumeLayout(false);
            this.grpBxLang.PerformLayout();
            this.grpBxAESKind.ResumeLayout(false);
            this.grpBxAESKind.PerformLayout();
            this.grpBxEncDec.ResumeLayout(false);
            this.grpBxEncDec.PerformLayout();
            this.grpBxKey.ResumeLayout(false);
            this.grpBxKey.PerformLayout();
            this.grpBxText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.RichTextBox richtxtPlain;
        private System.Windows.Forms.RichTextBox richtxtCipher;
        private System.Windows.Forms.Label lblPlainText;
        private System.Windows.Forms.Label lblCipher;
        private System.Windows.Forms.GroupBox grpBxLang;
        private System.Windows.Forms.GroupBox grpBxAESKind;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.GroupBox grpBxEncDec;
        private System.Windows.Forms.TextBox txtbxKey;
        private System.Windows.Forms.RadioButton rdbtnEnglish;
        private System.Windows.Forms.RadioButton rdbtnArabic;
        private System.Windows.Forms.RadioButton rdbtnAES256;
        private System.Windows.Forms.RadioButton rdbtnAES192;
        private System.Windows.Forms.RadioButton rdbtnAES128;
        private System.Windows.Forms.GroupBox grpBxKey;
        private System.Windows.Forms.RadioButton rdbtnEncrpyt;
        private System.Windows.Forms.RadioButton rdbtnDecrypt;
        private System.Windows.Forms.GroupBox grpBxText;
        private System.Windows.Forms.Button btnEncryptDecrypt;
        private System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.FontDialog fontDialogText;
    }
}

