using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Reflection;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Image;
using iText.Layout.Borders;


namespace API.Services
{
    public class Generador_Pdf
    {
        public void Header(Document doc, PdfDocument pdfDocument)
        {
            // crea la fuente PDF con Times Roman
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            
            // creamos los parrafos de los encabezados
            Paragraph paragraph = new Paragraph();

            // insertamos la imagen con sus especificaciones de diseño
            Image image = new Image(ImageDataFactory.Create("/Users/alejandromunoz/Desktop/PDFDEMO/API/Image/campuslands_logo.jpg"));
            DateTime date = DateTime.Now;
            image.SetFixedPosition(pdfDocument.GetDefaultPageSize().GetWidth() - 600, pdfDocument.GetDefaultPageSize().GetHeight() - 160);
            image.ScaleToFit(100, 100);

            // consigurar los margenes y alineacion del texto
            doc.SetTextAlignment(TextAlignment.RIGHT);
            doc.SetMargins(55, 35, 70, 35);
            doc.SetTextAlignment(TextAlignment.RIGHT);
            doc.SetFontSize(10);

            // agrega elementos al inventario
            doc.Add(new Paragraph("Reporte CampusLands Medicamentos")
                .SetMargin(1)
                .SetFontSize(10)
                .SetFontSize(20));
            doc.Add(new Paragraph("Diego Muñoz").SetMargin(1));
            //metodo para agregar la fecha de creacion del pdf
            doc.Add(new Paragraph(date.ToString()).SetMargin(1));

            doc.SetTextAlignment(TextAlignment.CENTER);
            doc.Add(new Paragraph("Reporte de productos").SetFontSize(30).SetFont(font).SetUnderline());
            doc.Add(image);
        }

        // metodo para generar el documento pdf
        public void Document<T>(List<T> lstProductDto, MemoryStream ms)
        {
            // crea el documento pdf
            PdfWriter pdfWriter = new PdfWriter(ms);
            PdfDocument pdfDoc = new PdfDocument(pdfWriter);
            Document doc = new Document(pdfDoc, PageSize.LETTER);

            // configurar margenes y borde del documento
            doc.SetMargins(75, 35, 70, 35);
            doc.SetBorder(new SolidBorder(2f));

            //metodo Header para agregar el encabezado al documento
            Header(doc, pdfDoc);

            // obtener propiedades de la clase del primer elemento de la lista
            PropertyInfo[] propiedades = lstProductDto[0].GetType().GetProperties();

            // consiguramos la tabla
            doc.SetTextAlignment(TextAlignment.CENTER);
            Table table = new Table(propiedades.Length);
            table.SetMarginTop(10);
            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            // agregamos el encabezado a la tabla
            foreach (var propiedad in propiedades)
            {
                Cell headerCell = new Cell()
                    .SetPadding(0)
                    .Add(new Paragraph(propiedad.Name)
                        .SetBold()
                        .SetFontSize(12)
                        .SetBackgroundColor(new DeviceRgb(210, 210, 210))
                        .SetPadding(10));
                headerCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(headerCell);
            }

            // se agregan los datos a la tabla
            foreach (var x in lstProductDto)
            {
                foreach (var propiedad in propiedades)
                {
                    Cell dataCell = new Cell().Add(new Paragraph(propiedad.GetValue(x).ToString())
                        .SetFontSize(12)
                        .SetPadding(5));
                    dataCell.SetTextAlignment(TextAlignment.CENTER);
                    table.AddCell(dataCell);
                }
            }

            // agregamos la tabla al documento
            doc.Add(table);
            doc.Close();
        }

        // metodo para generar un MemoryStream desde la lista de DTO
        public MemoryStream Generador<T>(List<T> lstProductDto)
        {
            MemoryStream ms = new MemoryStream();

            // llamar al metodo Document para generar el documento PDF
            Document(lstProductDto, ms);

            // convertir el MemoryStream a un array de bytes y volver a crear un MemoryStream
            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return ms;
        }
    }
}
