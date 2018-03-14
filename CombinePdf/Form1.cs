using iTextSharp.text;
using iTextSharp.text.pdf;
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

namespace CombinePdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCombinar_Click(object sender, EventArgs e)
        {
            Document document = new Document();

            PdfCopy writer = new PdfCopy(document, new FileStream(@"C:\Users\agaspari\Documents\Temp\telecurso\matematica_1.pdf", FileMode.Create));
            if (writer == null)
                return;

            document.Open();

            foreach(string fileName in Directory.GetFiles(@"C:\Users\agaspari\Documents\Temp\telecurso\matematica_1", "*.pdf", SearchOption.TopDirectoryOnly))
            {
                PdfReader reader = new PdfReader(fileName);
                reader.ConsolidateNamedDestinations();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.AddPage(page);
                }

                reader.Close();
            }

            writer.Close();
            document.Close();
        }
    }
}
