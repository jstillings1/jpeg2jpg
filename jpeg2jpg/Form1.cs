using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Diagnostics;

namespace jpeg2jpg
{
    public partial class Form1 : Form
    {
        private Button selectButton;
        private OpenFileDialog openFileDialog1;
        public Form1()
        {
            InitializeComponent();

            // Basic copy paste from MS help site
            // It creates a file open dialog off a button click to pick the .jpeg file

            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a file",
                Filter = "Picture files (*.jpeg)|*.jpeg",
                Title = "Open .jpeg file"
            };

            selectButton = new Button()
            {
                Size = new Size(200, 100),
                Location = new Point(300, 200),
                Text = "Select file"
            };
            selectButton.Click += new EventHandler(selectButton_Click);
            Controls.Add(selectButton);
        }
            private void selectButton_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                try
                {
                    // This takes a file and streams it into a drawing where we can...
                    var filePath = openFileDialog1.FileName;
                    string currentDirectory = Path.GetDirectoryName(filePath);
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        System.Drawing.Image oldImage = System.Drawing.Image.FromFile(filePath);
                        
                        // ... save it as another file type using C#'s build in file conversion class called imageformat
                        oldImage.Save(currentDirectory + "/new.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        // let user know its done
                        System.Windows.Forms.MessageBox.Show("File Converted. It is called new.jpg in the folder that opens.");

                        
                    }
                    // little scary but will open the file explorer where they saved it:)
                    Process.Start("explorer.exe", currentDirectory);

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                }
          
        }
        }

       
       
    }

