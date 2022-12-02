using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace PuntoLaLuz
{
    internal class Nominas
    {

        public void ImprimirNomina(System.Drawing.Image image, string num, string fecha, string puesto, string sal, string horasT, string horasE, string info, string salT)
        {   
            //Declarando tamaño y ubicación del documento de nóminas
            MessageBox.Show("Documento creado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MenuAdmin menu = new MenuAdmin();
            FileStream fs = new FileStream(@"C:\Users\vinke\Desktop\Pdfs\Nomina.pdf", FileMode.Create);
            Document doc = new Document(PageSize.POSTCARD, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);
            iTextSharp.text.Image fotopdf;
                       
            //Abriendo el documento
            doc.Open();

            //Titulo y autor
            doc.AddAuthor("Punto La Luz");
            doc.AddTitle("Nómina");

            //Definir la fuente
            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //Encabezado
            fotopdf = iTextSharp.text.Image.GetInstance(image, BaseColor.WHITE);
            fotopdf.ScaleAbsolute(270, 40);
            doc.Add(fotopdf);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("                         NÓMINA SEMANAL"));
            doc.Add(Chunk.NEWLINE);

            //Encabezado de columnas
            PdfPTable tblNominas = new PdfPTable(4);
            tblNominas.WidthPercentage = 100;

            PdfPCell cell1= new PdfPCell(new Phrase("", standarFont));
            cell1.BorderWidth = 0;
            cell1.BorderWidthBottom = 0.75f;

            PdfPCell cell2 = new PdfPCell(new Phrase("", standarFont));
            cell2.BorderWidth = 0;
            cell2.BorderWidthBottom = 0.75f;

            PdfPCell cell3 = new PdfPCell(new Phrase("", standarFont));
            cell3.BorderWidth = 0;
            cell3.BorderWidthBottom = 0.75f;

            PdfPCell cell4 = new PdfPCell(new Phrase("", standarFont));
            cell4.BorderWidth = 0;
            cell4.BorderWidthBottom = 0.75f;

            tblNominas.AddCell(cell1);
            tblNominas.AddCell(cell2);
            tblNominas.AddCell(cell3);
            tblNominas.AddCell(cell4);

            //Columna 1
            cell1 = new PdfPCell(new Phrase("Nombre del empleado: ", standarFont));
            cell1.BorderWidth = 1;
            tblNominas.AddCell(cell1);
            cell2 = new PdfPCell(new Phrase(num, standarFont));
            cell2.BorderWidth = 1;
            tblNominas.AddCell(cell2);
            cell3 = new PdfPCell(new Phrase("Horas trabajadas: ", standarFont));
            cell3.BorderWidth = 1;
            tblNominas.AddCell(cell3);
            cell4 = new PdfPCell(new Phrase(horasT, standarFont));
            cell4.BorderWidth = 1;
            tblNominas.AddCell(cell4);
           
            //Columna 2
            cell1 = new PdfPCell(new Phrase("Fecha de ingreso: ", standarFont));
            cell1.BorderWidth = 1;
            tblNominas.AddCell(cell1);
            cell2 = new PdfPCell(new Phrase(fecha, standarFont));
            cell2.BorderWidth = 1;
            tblNominas.AddCell(cell2);
            cell3 = new PdfPCell(new Phrase("Horas Extra: ", standarFont));
            cell3.BorderWidth = 1;
            tblNominas.AddCell(cell3);
            cell4 = new PdfPCell(new Phrase(horasE, standarFont));
            cell4.BorderWidth = 1;
            tblNominas.AddCell(cell4);

            //Columna 3
            cell1 = new PdfPCell(new Phrase("Puesto: ", standarFont));
            cell1.BorderWidth = 1;
            tblNominas.AddCell(cell1);
            cell2 = new PdfPCell(new Phrase(puesto, standarFont));
            cell2.BorderWidth = 1;
            tblNominas.AddCell(cell2);
            cell3 = new PdfPCell(new Phrase("INFONACOT: ", standarFont));
            cell3.BorderWidth = 1;
            tblNominas.AddCell(cell3);
            cell4 = new PdfPCell(new Phrase(info, standarFont));
            cell4.BorderWidth = 1;
            tblNominas.AddCell(cell4);

            //Columna 4
            cell1 = new PdfPCell(new Phrase("Salario por hora: ", standarFont));
            cell1.BorderWidth = 1;
            tblNominas.AddCell(cell1);
            cell2 = new PdfPCell(new Phrase(sal, standarFont));
            cell2.BorderWidth = 1;
            tblNominas.AddCell(cell2);
            cell3 = new PdfPCell(new Phrase("", standarFont));
            cell3.BorderWidth = 1;
            tblNominas.AddCell(cell3);
            cell4 = new PdfPCell(new Phrase("", standarFont));
            cell4.BorderWidth = 1;
            tblNominas.AddCell(cell4);

            //Añadiendo tabla: Nominas
            doc.Add(tblNominas);

            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            //Encabezado de columnas
            PdfPTable tblSalarioT = new PdfPTable(4);
            tblNominas.WidthPercentage = 100;

            PdfPCell cell5 = new PdfPCell(new Phrase("", standarFont));
            cell5.BorderWidth = 0;
            cell5.BorderWidthBottom = 0.75f;
            PdfPCell cell6 = new PdfPCell(new Phrase("", standarFont));
            cell6.BorderWidth = 0;
            cell6.BorderWidthBottom = 0.75f;
            PdfPCell cell7 = new PdfPCell(new Phrase("", standarFont));
            cell7.BorderWidth = 0;
            cell7.BorderWidthBottom = 0.75f;
            PdfPCell cell8 = new PdfPCell(new Phrase("", standarFont));
            cell8.BorderWidth = 0;
            cell8.BorderWidthBottom = 0.75f;

            //Insertando datos en tabla: Salario Total
            cell5 = new PdfPCell(new Phrase("                           ", standarFont));
            cell5.BorderWidth = 0;
            tblSalarioT.AddCell(cell5);            
            cell6 = new PdfPCell(new Phrase("                           ", standarFont));
            cell6.BorderWidth = 0;
            tblSalarioT.AddCell(cell6);
            cell7 = new PdfPCell(new Phrase("Salario total neto: ", standarFont));
            cell7.BorderWidth = 1;
            tblSalarioT.AddCell(cell7);
            cell8 = new PdfPCell(new Phrase(salT, standarFont));
            cell8.BorderWidth = 1;
            tblSalarioT.AddCell(cell8);

            //Insertando tabla: Salario Total
            doc.Add(tblSalarioT);

            //Cerrando documento
            doc.Close();
            pw.Close();
        }
    }
}
