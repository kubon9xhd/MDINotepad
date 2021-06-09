using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDINotepad
{
    public partial class FrmNote : Form
    {
        public String Content{
            get { return rTxtNote.Text; }
            set { rTxtNote.Text = value; }
        }
        public String PreviousContent
        {
            get;
            set;
        }
        public int Line { get; set; }
        public int Col { get; set; }
        public String Path
        {
            get;set;
        }
        public FrmNote()
        {
            InitializeComponent();
        }
        public FrmNote(String name)
        {
            this.Text = name;
            rTxtNote.SelectionFont = new Font("Tahoma", 12, FontStyle.Regular);
        }

        private void FrmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
  
        }

        private void rTxtNote_CursorChanged(object sender, EventArgs e)
        {
            MDINotepad notepad = (MDINotepad)this.MdiParent;
            // Get the line.
            int index = rTxtNote.SelectionStart;
            Line = rTxtNote.GetLineFromCharIndex(index);

            // Get the column.
            int firstChar = rTxtNote.GetFirstCharIndexFromLine(Line);
            Col = index - firstChar;
            notepad.mntrCount.Text = "Ln " + Line + ", Col " + Col;
        }
    }
}
