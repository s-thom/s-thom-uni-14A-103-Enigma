namespace Enigma
{
    partial class Form1
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
            this.buttonLoadRotors = new System.Windows.Forms.Button();
            this.buttonDecodeFile = new System.Windows.Forms.Button();
            this.openFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.buttonEncryptFile = new System.Windows.Forms.Button();
            this.saveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // buttonLoadRotors
            // 
            this.buttonLoadRotors.Location = new System.Drawing.Point(13, 12);
            this.buttonLoadRotors.Name = "buttonLoadRotors";
            this.buttonLoadRotors.Size = new System.Drawing.Size(259, 47);
            this.buttonLoadRotors.TabIndex = 0;
            this.buttonLoadRotors.Text = "Load Rotors";
            this.buttonLoadRotors.UseVisualStyleBackColor = true;
            this.buttonLoadRotors.Click += new System.EventHandler(this.buttonLoadRotors_Click);
            // 
            // buttonDecodeFile
            // 
            this.buttonDecodeFile.Location = new System.Drawing.Point(13, 65);
            this.buttonDecodeFile.Name = "buttonDecodeFile";
            this.buttonDecodeFile.Size = new System.Drawing.Size(259, 47);
            this.buttonDecodeFile.TabIndex = 1;
            this.buttonDecodeFile.Text = "Decode File";
            this.buttonDecodeFile.UseVisualStyleBackColor = true;
            this.buttonDecodeFile.Click += new System.EventHandler(this.buttonDecodeFile_Click);
            // 
            // openFileDialogOpen
            // 
            this.openFileDialogOpen.FileName = " ";
            // 
            // buttonEncryptFile
            // 
            this.buttonEncryptFile.Location = new System.Drawing.Point(13, 118);
            this.buttonEncryptFile.Name = "buttonEncryptFile";
            this.buttonEncryptFile.Size = new System.Drawing.Size(259, 47);
            this.buttonEncryptFile.TabIndex = 2;
            this.buttonEncryptFile.Text = "Encrypt File";
            this.buttonEncryptFile.UseVisualStyleBackColor = true;
            this.buttonEncryptFile.Click += new System.EventHandler(this.buttonEncryptFile_Click);
            // 
            // saveFileDialogSave
            // 
            this.saveFileDialogSave.FileName = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 186);
            this.Controls.Add(this.buttonEncryptFile);
            this.Controls.Add(this.buttonDecodeFile);
            this.Controls.Add(this.buttonLoadRotors);
            this.Name = "Form1";
            this.Text = "Enigma";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadRotors;
        private System.Windows.Forms.Button buttonDecodeFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpen;
        private System.Windows.Forms.Button buttonEncryptFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSave;
    }
}

