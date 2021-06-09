
namespace MDINotepad
{
    partial class FrmNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNote));
            this.rTxtNote = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rTxtNote
            // 
            this.rTxtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtNote.ForeColor = System.Drawing.SystemColors.MenuText;
            this.rTxtNote.Location = new System.Drawing.Point(0, 0);
            this.rTxtNote.Name = "rTxtNote";
            this.rTxtNote.Size = new System.Drawing.Size(577, 370);
            this.rTxtNote.TabIndex = 0;
            this.rTxtNote.Text = "";
            this.rTxtNote.CursorChanged += new System.EventHandler(this.rTxtNote_CursorChanged);
            this.rTxtNote.TextChanged += new System.EventHandler(this.rTxtNote_CursorChanged);
            // 
            // FrmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 370);
            this.Controls.Add(this.rTxtNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNote";
            this.Text = "FrmNote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNote_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rTxtNote;
    }
}