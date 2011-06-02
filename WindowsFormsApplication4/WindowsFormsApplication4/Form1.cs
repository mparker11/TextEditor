/* Creator: Martavis Parker
 * 
 * This sample program (WinForm) allows for a user to
 * load a file, edit and save it. The coding is broken
 * into a few methods. The methods created makes for 
 * easier debugging, great organzation and erases 
 * redundancy from parts that are similar to one
 * another.
 * 
 *****May be upgraded some day to mimic Notepad :-)*****
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }    


//=================================== Dirty Work ==================================================
        //Uses a dialog to open a file and load it to the textbox
        private void loadFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt|Word 97-2003 Document (*.doc)|*.doc";
 
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFile.FileName.EndsWith(".txt") || openFile.FileName.EndsWith(".doc"))
                {
                    using (StreamReader strRead = new StreamReader(openFile.FileName))
                    {
                        String line;

                        if (textBox1.Text.Length == 0)
                        {
                            while ((line = strRead.ReadLine()) != null)
                            {
                                textBox1.AppendText(line + "\n");
                            }
                        }
                        else
                        {
                            textBox1.Text = "";
                            while ((line = strRead.ReadLine()) != null)
                            {
                                textBox1.AppendText(line + "\n");
                            }
                        }
                        strRead.Close();
                    }   
                }
                else
                {
                    MessageBox.Show("Please choose a text file or Word document");
                }
            }   
        }

        //checks if the textbox is empty before saving
        private void saveFile()
        {
            if (textBox1.Text.Length != 0)
            {
                saveIntoSet();
            }     
            else
            {
                switch(MessageBox.Show("Are you sure you would like to save an empty file?", "Warning", MessageBoxButtons.YesNo))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        saveIntoSet();
                        break;

                    case System.Windows.Forms.DialogResult.No:
                        break;
                }  
            } 
        }

        //uses hashset for intermediate step of writing to file - hashset used for speed vs list 
        //(never know when a bigger file will be created)
        private void saveIntoSet()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            HashSet<string> set = new HashSet<string>();
            set.Add(textBox1.Text);

            saveFile.Filter = "Text files (*.txt)|*.txt|Word 97-2003 Document (*.doc)|*.doc";

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFile.FileName.EndsWith(".txt") || saveFile.FileName.EndsWith(".doc"))
                {
                    using (TextWriter strWrite = new StreamWriter(saveFile.FileName))
                    {
                        foreach (string line in set)
                        {
                            strWrite.Write(line);
                        }
                        strWrite.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a text file or Word document");
                }
            }

            MessageBox.Show("File has been saved");

            //Finally erase textbox text
            if (textBox1.Text.Length != 0)
            {
                textBox1.Text = "";
            }
        }    
    }
}
