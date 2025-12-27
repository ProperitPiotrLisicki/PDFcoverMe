Imports System.IO
Imports iText.Kernel.Pdf
Imports iText.Kernel.Utils

Public Class Form1

    Private sourceFiles As New List(Of String)
    Private appendFiles As New List(Of String)

    ' ------------------------------
    ' Wybór PDF-ów źródłowych
    ' ------------------------------
    Private Sub btnSelectSources_Click(sender As Object, e As EventArgs) Handles btnSelectSources.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "PDF Files|*.pdf",
            .Multiselect = True
        }

        If ofd.ShowDialog() = DialogResult.OK Then
            sourceFiles = ofd.FileNames.ToList()
            lstSources.Items.Clear()
            For Each f In sourceFiles
                lstSources.Items.Add(f)
            Next
        End If
    End Sub

    ' ------------------------------
    ' Wybór PDF-ów do doklejenia
    ' ------------------------------
    Private Sub btnSelectAppends_Click(sender As Object, e As EventArgs) Handles btnSelectAppends.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "PDF Files|*.pdf",
            .Multiselect = True
        }

        If ofd.ShowDialog() = DialogResult.OK Then
            appendFiles = ofd.FileNames.ToList()
            lstAppend.Items.Clear()
            For Each f In appendFiles
                lstAppend.Items.Add(f)
            Next
        End If
    End Sub


    ' --------------------------------------------------------
    ' START – proces łączenia i NADPISYWANIA źródłowych PDF
    ' --------------------------------------------------------
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If sourceFiles.Count = 0 Then
            MessageBox.Show("Brak plików źródłowych!")
            Return
        End If

        If appendFiles.Count = 0 Then
            MessageBox.Show("Brak plików do doklejenia!")
            Return
        End If

        ProgressBar1.Value = 0

        Dim total = sourceFiles.Count
        Dim processed = 0

        For i = 0 To sourceFiles.Count - 1

            Dim src = sourceFiles(i)

            ' sprawdzamy, czy plik jest otwarty
            If IsFileLocked(src) Then
                lstSources.Items(i) = src & "   [OTWARTY – POMINIĘTY]"
                lstSources.ForeColor = Color.Red
                Continue For
            End If

            Try
                AppendAndOverwrite(src, appendFiles)
                lstSources.Items(i) = src & "   ✔ PRZETWORZONO"
            Catch ex As Exception
                lstSources.Items(i) = src & "   ❌ BŁĄD"
            End Try

            processed += 1
            ProgressBar1.Value = CInt((processed / total) * 100)

            Application.DoEvents()
        Next

        MessageBox.Show("Zakończono przetwarzanie.")
    End Sub


    ' --------------------------------------------------------
    ' Łączenie PDF → zapis do pliku tymczasowego → nadpisanie
    ' --------------------------------------------------------
    Private Sub AppendAndOverwrite(src As String, appends As List(Of String))

        Dim tempFile = src & ".tmp"

        Using writer As New PdfWriter(tempFile)
            Using target As New PdfDocument(writer)
                Dim merger As New PdfMerger(target)

                Using srcDoc As New PdfDocument(New PdfReader(src))
                    merger.Merge(srcDoc, 1, srcDoc.GetNumberOfPages())
                End Using

                For Each file In appends
                    Using appDoc As New PdfDocument(New PdfReader(file))
                        merger.Merge(appDoc, 1, appDoc.GetNumberOfPages())
                    End Using
                Next

            End Using
        End Using

        File.Delete(src)
        File.Move(tempFile, src)
    End Sub


    ' --------------------------------------------------------
    ' Sprawdzenie czy PDF jest otwarty (zablokowany do zapisu)
    ' --------------------------------------------------------
    Private Function IsFileLocked(path As String) As Boolean
        Try
            Using fs As FileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                ' jeśli się uda, plik NIE jest zablokowany
                Return False
            End Using
        Catch
            Return True
        End Try
    End Function


    ' --------------------------------------------------------
    ' DRAG & DROP dla lstAppend – zmiana kolejności PDF-ów
    ' --------------------------------------------------------
    Private dragIndex As Integer = -1

    Private Sub lstAppend_MouseDown(sender As Object, e As MouseEventArgs) Handles lstAppend.MouseDown
        dragIndex = lstAppend.IndexFromPoint(e.Location)
    End Sub

    Private Sub lstAppend_DragOver(sender As Object, e As DragEventArgs) Handles lstAppend.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub lstAppend_DragDrop(sender As Object, e As DragEventArgs) Handles lstAppend.DragDrop
        Dim point = lstAppend.PointToClient(New Point(e.X, e.Y))
        Dim dropIndex = lstAppend.IndexFromPoint(point)

        If dragIndex < 0 Or dropIndex < 0 Or dragIndex = dropIndex Then Exit Sub

        Dim item = lstAppend.Items(dragIndex)
        lstAppend.Items.RemoveAt(dragIndex)
        lstAppend.Items.Insert(dropIndex, item)

        ' aktualizacja listy appendFiles
        appendFiles = lstAppend.Items.Cast(Of String).ToList()
    End Sub

    Private Sub lstAppend_MouseMove(sender As Object, e As MouseEventArgs) Handles lstAppend.MouseMove
        If e.Button = MouseButtons.Left AndAlso dragIndex >= 0 Then
            lstAppend.DoDragDrop(lstAppend.Items(dragIndex), DragDropEffects.Move)
        End If
    End Sub

    Private Sub btnRemoveSelected_Click(sender As Object, e As EventArgs) Handles btnRemoveSelected.Click

        ' Usuwanie ze źródłowych
        If lstSources.SelectedItems.Count > 0 Then
            Dim toRemove = lstSources.SelectedIndices.Cast(Of Integer).OrderByDescending(Function(x) x)
            For Each idx In toRemove
                sourceFiles.RemoveAt(idx)
            Next
        End If

        ' Usuwanie z doklejanych
        If lstAppend.SelectedItems.Count > 0 Then
            Dim toRemove = lstAppend.SelectedIndices.Cast(Of Integer).OrderByDescending(Function(x) x)
            For Each idx In toRemove
                appendFiles.RemoveAt(idx)
            Next
        End If

        RefreshLists()
    End Sub


    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click

        If MessageBox.Show("Wyczyścić cały formularz?", "Potwierdzenie",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
            Return
        End If

        lstSources.Items.Clear()
        lstAppend.Items.Clear()

        sourceFiles.Clear()
        appendFiles.Clear()

        ProgressBar1.Value = 0
        dragIndex = -1

        ' MessageBox.Show("Wyczyszczono.")
    End Sub

    Private Sub RefreshLists()
        lstSources.Items.Clear()
        For i = 0 To sourceFiles.Count - 1
            lstSources.Items.Add((i + 1).ToString() & ") " & sourceFiles(i))
        Next

        lstAppend.Items.Clear()
        For i = 0 To appendFiles.Count - 1
            lstAppend.Items.Add((i + 1).ToString() & ") " & appendFiles(i))
        Next
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then
            If lstSources.Focused Then
                RemoveSelectedFromList(lstSources, sourceFiles)
            ElseIf lstAppend.Focused Then
                RemoveSelectedFromList(lstAppend, appendFiles)
            End If
        End If
    End Sub

    Private Sub RemoveSelectedFromList(lst As ListBox, list As List(Of String))
        If lst.SelectedIndices.Count = 0 Then Return

        Dim toRemove = lst.SelectedIndices.Cast(Of Integer).OrderByDescending(Function(x) x)
        For Each idx In toRemove
            list.RemoveAt(idx)
        Next

        RefreshLists()
    End Sub


End Class
