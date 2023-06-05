namespace RsaSigantureServer
{
    partial class Form1
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
            messsageTextBox = new RichTextBox();
            startServerbtn = new Button();
            infoTextBox = new RichTextBox();
            label1 = new Label();
            keyTextBox = new RichTextBox();
            signatureTextBox = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            sendBtn = new Button();
            stopServerbtn = new Button();
            SuspendLayout();
            // 
            // messsageTextBox
            // 
            messsageTextBox.Location = new Point(22, 35);
            messsageTextBox.Name = "messsageTextBox";
            messsageTextBox.Size = new Size(425, 93);
            messsageTextBox.TabIndex = 0;
            messsageTextBox.Text = "";
            // 
            // startServerbtn
            // 
            startServerbtn.Location = new Point(478, 339);
            startServerbtn.Name = "startServerbtn";
            startServerbtn.Size = new Size(75, 23);
            startServerbtn.TabIndex = 1;
            startServerbtn.Text = "Start Server";
            startServerbtn.UseVisualStyleBackColor = true;
            startServerbtn.Click += startServerbtn_Click;
            // 
            // infoTextBox
            // 
            infoTextBox.Location = new Point(478, 35);
            infoTextBox.Name = "infoTextBox";
            infoTextBox.Size = new Size(299, 298);
            infoTextBox.TabIndex = 2;
            infoTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 9);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 3;
            label1.Text = "Message";
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(22, 154);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(425, 145);
            keyTextBox.TabIndex = 4;
            keyTextBox.Text = "";
            // 
            // signatureTextBox
            // 
            signatureTextBox.Location = new Point(22, 320);
            signatureTextBox.Name = "signatureTextBox";
            signatureTextBox.Size = new Size(425, 118);
            signatureTextBox.TabIndex = 5;
            signatureTextBox.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 131);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 6;
            label2.Text = "Key";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 302);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 7;
            label3.Text = "Signature";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(478, 9);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 8;
            label4.Text = "Logs";
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(666, 415);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(111, 23);
            sendBtn.TabIndex = 9;
            sendBtn.Text = "Send To Verify";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // stopServerbtn
            // 
            stopServerbtn.Location = new Point(702, 339);
            stopServerbtn.Name = "stopServerbtn";
            stopServerbtn.Size = new Size(75, 23);
            stopServerbtn.TabIndex = 10;
            stopServerbtn.Text = "Stop Server";
            stopServerbtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(stopServerbtn);
            Controls.Add(sendBtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(signatureTextBox);
            Controls.Add(keyTextBox);
            Controls.Add(label1);
            Controls.Add(infoTextBox);
            Controls.Add(startServerbtn);
            Controls.Add(messsageTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }






        #endregion

        private RichTextBox messsageTextBox;
        private Button startServerbtn;
        private RichTextBox infoTextBox;
        private Label label1;
        private RichTextBox keyTextBox;
        private RichTextBox signatureTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button sendBtn;
        private Button stopServerbtn;
    }
}