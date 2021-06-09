using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MDINotepad
{
    public partial class MDINotepad : Form
    {
        List<FrmNote> frmNotes;
        public MDINotepad()
        {
            InitializeComponent();
            frmNotes = new List<FrmNote>();
        }

        private void sendFeedBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendFeedBack sendFeedBack = new SendFeedBack();
            sendFeedBack.ShowDialog();
        }
        /*New*/
        private void tbrNew_Click(object sender, EventArgs e)
        {
            Controller.NotepadController.CreateNewDocument(this,frmNotes);
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                active.PreviousContent = "";
            }
        }
        private void mnuNew_Click(object sender, EventArgs e)
        {
            Controller.NotepadController.CreateNewDocument(this, frmNotes);
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                active.PreviousContent = "";
            }
        }
        /*End New*/
        /*Open*/
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            Controller.NotepadController.OpenFile(this, dialogOpen, frmNotes);
        }
        private void tbrOpen_Click(object sender, EventArgs e)
        {
            Controller.NotepadController.OpenFile(this, dialogOpen, frmNotes);
        }
        /*End Open*/
        /*Save*/
        private void mnuSave_Click(object sender, EventArgs e)
        {
            Controller.NotepadController.SaveFile(this,dialogSave);

        }
        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            Controller.NotepadController.SaveAsFile(this,dialogSave);
        }
        private void tbrSave_Click(object sender, EventArgs e)
        {
            Controller.NotepadController.SaveFile(this, dialogSave);
        }
        /*End Save*/
        /*Exit*/
        private void mnuExit_Click(object sender, EventArgs e)
        {
            
        }
        private void MDINotepad_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        /*End Exit*/
        /*Print*/
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                Controller.NotepadController.PrintText(this, printDialog, printDocument);
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                e.Graphics.DrawString(active.Content,new Font("Time New Romans",14,FontStyle.Bold),Brushes.Black, new PointF(100,100));
            }
        }
        /*End Print*/
        /*Sort*/
        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void titleHoriontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void titleVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void MDINotepad_Load(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
               
            }
           
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogFont.ShowDialog() == DialogResult.OK)
            {
                FrmNote active = (FrmNote)this.ActiveMdiChild;
                if (active != null)
                {
                    active.Font = dialogFont.Font;
                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogColor.ShowDialog() == DialogResult.OK)
            {
                FrmNote active = (FrmNote)this.ActiveMdiChild;
                if (active != null)
                {
                    active.rTxtNote.ForeColor = dialogColor.Color;
                }
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                active.rTxtNote.WordWrap = true;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                RichTextBox richTextBox = active.ActiveControl as RichTextBox;
                if (richTextBox.SelectedText != string.Empty)
                {
                    Clipboard.SetData(DataFormats.Text, richTextBox.SelectedText);
                }
                richTextBox.SelectedText = string.Empty;
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                RichTextBox richTextBox = active.ActiveControl as RichTextBox;
                if (richTextBox.SelectedText != string.Empty)
                {
                    Clipboard.SetData(DataFormats.Text, richTextBox.SelectedText);
                }
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                int position = ((RichTextBox)active.ActiveControl).SelectionStart+((RichTextBox)active.ActiveControl).SelectionLength;
                active.ActiveControl.Text = active.ActiveControl.Text.Insert(position,Clipboard.GetText());
            }
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                if (active.rTxtNote.CanUndo == true)
                {
                    active.rTxtNote.Undo();
                }
            }
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                if (active.rTxtNote.CanRedo == true)
                {
                    active.rTxtNote.Redo();
                }
            }
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMe aboutMe = new AboutMe();
            aboutMe.ShowDialog();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/hello.iamkubon/");
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                Font currentFont = active.Font;
                if (currentFont.Size+2 <= 100)
                {
                    Font font = new Font(currentFont.FontFamily,currentFont.Size+2,currentFont.Style);
                    active.Font = font;
                }
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNote active = (FrmNote)this.ActiveMdiChild;
            if (active != null)
            {
                Font currentFont = active.Font;
                if (currentFont.Size - 2 >= 4)
                {
                    Font font = new Font(currentFont.FontFamily, currentFont.Size - 2, currentFont.Style);
                    active.Font = font;
                }
            }
        }

        private void tbrHelp_Click(object sender, EventArgs e)
        {
            viewHelpToolStripMenuItem_Click(sender,e);
        }

        /*End Sort*/
    }
}
