using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDINotepad.Controller
{
    class NotepadController
    {
        public static void CreateNewDocument(Form parent, List<FrmNote> frmNotes)
        {
            FrmNote frmNote = new FrmNote();
            frmNote.Text = "New " + (frmNotes.Count);
            frmNote.MdiParent = parent;
            frmNotes.Add(frmNote);
            frmNote.Show();
        }
        public static void OpenFile(Form parent, OpenFileDialog openFileDialog, List<FrmNote> frmNotes)
        {
            using (openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String filename = openFileDialog.FileName;
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        FrmNote active = (FrmNote)parent.ActiveMdiChild;
                        if (active == null)
                        {
                            CreateNewDocument(parent, frmNotes);
                            active = frmNotes.ElementAt(frmNotes.Count - 1);
                        }
                        active.Content = reader.ReadToEnd();
                        active.Text = filename;
                        active.Path = filename;
                        if (active.PreviousContent == null)
                        {
                            active.PreviousContent = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static void SaveFile(Form parent, SaveFileDialog saveFileDialog)
        {
            FrmNote active = (FrmNote)parent.ActiveMdiChild;
            if (active != null)
            {
                // if does not have path
                if (!File.Exists(active.Path))
                {
                    SaveCommon(saveFileDialog,active);
                }
                else
                {
                    String filename = active.Path;
                    SaveToFile(filename,active.Content);
                    active.Text = filename;
                }
                active.PreviousContent = active.Content;
            }
        }
        public static void SaveAsFile(Form parent, SaveFileDialog saveFileDialog)
        {
            FrmNote active = (FrmNote)parent.ActiveMdiChild;
            if(active != null)
            {
                SaveCommon(saveFileDialog, active);
            }
        }
        public static void SaveToFile(String path, String content)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(content);
                streamWriter.WriteLine("\n");
                streamWriter.Close();
            }
        }
        public static void SaveCommon(SaveFileDialog saveFileDialog, FrmNote active)
        {
            using (saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "text files (*.txt)|*.txt|All File(*.*)|*.*";
                saveFileDialog.Title = "Save text box";
                saveFileDialog.CheckPathExists = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String filename = saveFileDialog.FileName;
                    using (StreamWriter streamWriter = new StreamWriter(filename))
                    {
                        streamWriter.WriteLine(active.Content);
                        streamWriter.WriteLine("\n");
                        streamWriter.Close();
                    }
                    active.Text = filename;
                    active.Path = filename;
                }
            }
        }
        public static void ExitAndSave(Form parent, SaveFileDialog dialogSave)
        {
           
        }
        public static void PrintText(Form parent, PrintDialog printDialog, System.Drawing.Printing.PrintDocument printDocument)
        {
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
