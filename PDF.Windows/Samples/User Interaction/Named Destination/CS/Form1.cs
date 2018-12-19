#region Copyright Syncfusion Inc. 2001 - 2016
//
//  Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Pdf;
using Syncfusion.Windows.Forms;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Licensing;

namespace EssentialPDFSamples
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : MetroForm
    {
        # region Private Members
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        # endregion

        # region Constructor
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.MinimizeBox = true;
            Application.EnableVisualStyles();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
           //
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(286, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "PDF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click the button to view an PDF document generated by Essential PDF.  Please note" +
                " that Adobe Reader or its equivalent is required to view the resultant document." +
                "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
                      this.pictureBox1.Image = System.Drawing.Image.FromFile(GetFullTemplatePath("pdf_header.png", true));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 89);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 196);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
              this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Named Destination";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());
            Application.Run(new Form1());
        }
        #endregion

        # region Fields
        PdfDocument document = null;
        PdfFont font = null;
        PdfBrush brush = null;
        #endregion

        # region Methods
        public PdfBookmark AddBookmark(PdfPage page, string title, PointF point)
        {
            PdfGraphics graphics = page.Graphics;
            //Add bookmark in PDF document
            PdfBookmark bookmarks = document.Bookmarks.Add(title);

            //Draw the content in the PDF page
            graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

            //Adding bookmark with named destination
            PdfNamedDestination namedDestination = new PdfNamedDestination(title);
            namedDestination.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
            namedDestination.Destination.Mode = PdfDestinationMode.FitToPage;
            document.NamedDestinationCollection.Add(namedDestination);
            bookmarks.NamedDestination = namedDestination;

            return bookmarks;
        }

        public PdfBookmark AddSection(PdfBookmark bookmark, PdfPage page, string title, PointF point, bool isSubSection)
        {
            PdfGraphics graphics = page.Graphics;
            //Add bookmark in PDF document
            PdfBookmark bookmarks = bookmark.Add(title);

            //Draw the content in the PDF page
            graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

            //Adding bookmark with named destination
            PdfNamedDestination namedDestination = new PdfNamedDestination(title);
            namedDestination.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
            if (isSubSection == true)
            {
                namedDestination.Destination.Zoom = 2f;
            }
            else
            {
                namedDestination.Destination.Zoom = 1f;
            }
            document.NamedDestinationCollection.Add(namedDestination);
            bookmarks.NamedDestination = namedDestination;

            return bookmarks;
        }
        #endregion

        # region Events
        private void button1_Click(object sender, System.EventArgs e)
        {

            document = new PdfDocument();
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
            brush = new PdfSolidBrush(Color.Black);

            for (int i = 1; i <= 6; i++)
            {
                PdfPage pages = document.Pages.Add();
                //Add bookmark in PDF document
                PdfBookmark bookmark = AddBookmark(pages, "Chapter " + i, new PointF(10, 10));
                //Add sections to bookmark
                PdfBookmark section1 = AddSection(bookmark, pages, "Section " + i + ".1", new PointF(30, 30), false);
                PdfBookmark section2 = AddSection(bookmark, pages, "Section " + i + ".2", new PointF(30, 400), false);
                //Add subsections to section
                PdfBookmark subsection1 = AddSection(section1, pages, "Paragraph " + i + ".1.1", new PointF(50, 50), true);
                PdfBookmark subsection2 = AddSection(section1, pages, "Paragraph " + i + ".1.2", new PointF(50, 150), true);
                PdfBookmark subsection3 = AddSection(section1, pages, "Paragraph " + i + ".1.3", new PointF(50, 250), true);
                PdfBookmark subsection4 = AddSection(section2, pages, "Paragraph " + i + ".2.1", new PointF(50, 420), true);
                PdfBookmark subsection5 = AddSection(section2, pages, "Paragraph " + i + ".2.2", new PointF(50, 560), true);
                PdfBookmark subsection6 = AddSection(section2, pages, "Paragraph " + i + ".2.3", new PointF(50, 680), true);
            }

            document.Save("Sample.pdf");
            document.Close(true);
            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("Sample.pdf");
                this.Close();
            }
            else
            {
                // Exit
                this.Close();
            }
        }
		
        # endregion

		# region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
            string fullPath = @"..\..\..\..\..\..\..\Common\";
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        # endregion
    }
	/// <summary>
    /// Represents a class that is used to find the licensing file for Syncfusion controls.
    /// </summary>
    public class DemoCommon
    {

        /// <summary>
        /// Finds the license key from the Common folder.
        /// </summary>
        /// <returns>Returns the license key.</returns>
        public static string FindLicenseKey()
        {
            string licenseKeyFile = "..\\Common\\SyncfusionLicense.txt";
            for (int n = 0; n < 20; n++)
            {
                if (!System.IO.File.Exists(licenseKeyFile))
                {
                    licenseKeyFile = @"..\" + licenseKeyFile;
                    continue;
                }
                return System.IO.File.ReadAllText(licenseKeyFile);
            }
            return string.Empty;
        }
    }
}