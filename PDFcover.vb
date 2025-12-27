Imports System.IO
Imports iText.Kernel.Pdf
Imports iText.Kernel.Utils

Module PDFcover

    Public Sub AppendPdfToMany(sourcePdfs As List(Of String), appendPdf As String, outputFolder As String)

        For Each src In sourcePdfs

            Dim outFile As String = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(src) & "_merged.pdf")

            ' --- 1. PDF oryginalny (źródło)
            Using pdfSrc As New PdfReader(src)
                ' --- 2. Pdf do doklejenia
                Using pdfAppend As New PdfReader(appendPdf)
                    ' --- 3. Plik wynikowy
                    Using pdfWriter As New PdfWriter(outFile)
                        Using pdfDoc As New PdfDocument(pdfWriter)
                            Dim merger As New PdfMerger(pdfDoc)

                            ' Otwieramy źródła jako PdfDocument
                            Using srcDoc As New PdfDocument(pdfSrc)
                                Using appendDoc As New PdfDocument(pdfAppend)
                                    ' --- kopiowanie stron oryginału
                                    merger.Merge(srcDoc, 1, srcDoc.GetNumberOfPages())

                                    ' --- doklejenie stron z 2. PDF
                                    merger.Merge(appendDoc, 1, appendDoc.GetNumberOfPages())
                                End Using
                            End Using

                        End Using
                    End Using
                End Using
            End Using

        Next

    End Sub

    Sub testmerge()
        Dim lista As New List(Of String) From {
    "C:\Temp\plik1.pdf",
    "C:\Temp\plik2.pdf"
}

        Dim pdfDoDoklejenia As String = "C:\Temp\append.pdf"
        Dim folderWyjscia As String = "C:\Temp\wynik"

        AppendPdfToMany(lista, pdfDoDoklejenia, folderWyjscia)
    End Sub

End Module
