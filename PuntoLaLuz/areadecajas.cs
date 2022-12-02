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

namespace PuntoLaLuz
{
    internal class areadecajas
    {
        public void imprimirRecibo(System.Drawing.Image image, List<string> Producto, List<string> Tipo, List<string> Extra, List<int> Precio, int precio)
        {
            //Declarando tipo de página y ubicación del recibo
            MenuAdmin menu = new MenuAdmin();
            FileStream fs = new FileStream(@"C:\Users\Megaman567\Desktop\Punto la luz. Version Final\recibo.pdf", FileMode.Create);
            Document doc = new Document(PageSize.POSTCARD, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);
            iTextSharp.text.Image fotopdf;

            //Abriendo documento
            doc.Open();

            //Titulo y autor
            doc.AddAuthor("Punto La Luz");
            doc.AddTitle("Recibo");

            //Definir la fuente
            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //Encabezado
            fotopdf = iTextSharp.text.Image.GetInstance(image, BaseColor.WHITE);
            fotopdf.ScaleAbsolute(80, 80);
            fotopdf.Alignment = Element.ALIGN_CENTER;
            doc.Add(fotopdf);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("                         Registro de venta"));
            doc.Add(Chunk.NEWLINE);

            //Encabezado de columnas
            PdfPTable tblNominas = new PdfPTable(4);
            tblNominas.WidthPercentage = 100;

            PdfPCell cell1 = new PdfPCell(new Phrase("", standarFont));
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

            //Creación de las filas
            tblNominas.AddCell(cell1);
            tblNominas.AddCell(cell2);
            tblNominas.AddCell(cell3);
            tblNominas.AddCell(cell4);

            //Llenado de la tabla: Productos
            for (int a = 0; a < Producto.Count; a++)
            {
                cell1 = new PdfPCell(new Phrase(Producto[a], standarFont));
                cell1.BorderWidth = 0;
                tblNominas.AddCell(cell1);
                cell2 = new PdfPCell(new Phrase(Tipo[a], standarFont));
                cell2.BorderWidth = 0;
                tblNominas.AddCell(cell2);
                cell3 = new PdfPCell(new Phrase(Extra[a], standarFont));
                cell3.BorderWidth = 0;
                tblNominas.AddCell(cell3);
                cell4 = new PdfPCell(new Phrase(Precio[a].ToString(), standarFont));
                cell4.BorderWidth = 0;
                tblNominas.AddCell(cell4);
            }          
            //Añadiendo tabla: Productos 
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

            //Llenado de la tabla: Precio Total
            cell5 = new PdfPCell(new Phrase("                           ", standarFont));
            cell5.BorderWidth = 0;
            tblSalarioT.AddCell(cell5);
            cell6 = new PdfPCell(new Phrase("                           ", standarFont));
            cell6.BorderWidth = 0;
            tblSalarioT.AddCell(cell6);
            cell7 = new PdfPCell(new Phrase("Precio total: ", standarFont));
            cell7.BorderWidth = 0;
            tblSalarioT.AddCell(cell7);
            cell8 = new PdfPCell(new Phrase(precio.ToString(), standarFont));
            cell8.BorderWidth = 0;
            tblSalarioT.AddCell(cell8);

            //Añadiendo tabla: Precio Total
            doc.Add(tblSalarioT);

            //Cerrando documento
            doc.Close();
            pw.Close();
        }
    }
}
