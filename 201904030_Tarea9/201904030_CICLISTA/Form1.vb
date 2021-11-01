Public Class Form1
    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click

        'guardando datos de ingreso 
        nombre(fila) = TextBox12.Text
        etapa(fila) = ComboBox1.SelectedItem
        km(fila) = TextBox1.Text
        tiempo(fila) = TextBox2.Text
        nacionalidad(fila) = ComboBox2.SelectedItem


    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub MostrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarToolStripMenuItem.Click

        'mostrar datos de ingreso en datagridview
        DataGridView1.Rows.Add(nombre(fila), etapa(fila), km(fila), tiempo(fila), nacionalidad(fila))



    End Sub

    Private Sub EstadísticasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadísticasToolStripMenuItem.Click

        'estadísticas


        While indice <= 12

            'estadistica numero de competidores nacionales y más de 45 km
            If (nacionalidad(fila) = "guatemaltecto" And (km(fila) >= 45)) Then
                est1 = est1 + 1
            End If
            'estadistica km sky 
            If (etapa(fila) = "sky") Then
                est2 = est2 + Val(km(fila))
            End If
            'estadistica km movistar
            If (etapa(fila) = "movistar") Then
                est3 = est3 + Val(km(fila))
            End If
            'estadistica km cycling
            If (etapa(fila) = "Pro Cycling") Then
                est4 = est4 + Val(km(fila))
            End If
            'estadistica km team
            If (etapa(fila) = "Pro Team") Then
                est5 = est5 + Val(km(fila))
            End If
            'estadistica tiempo sky 
            If (etapa(fila) = "sky") Then
                est6 = est6 + Val(tiempo(fila))
            End If
            'estadistica tiempo movistar
            If (etapa(fila) = "movistar") Then
                est7 = est7 + Val(tiempo(fila))
            End If
            'estadistica tiempo cycling
            If (etapa(fila) = "Pro Cycling") Then
                est8 = est8 + Val(tiempo(fila))
            End If
            'estadistica tiempo team
            If (etapa(fila) = "Pro Team") Then
                est9 = est9 + Val(tiempo(fila))
            End If

            'mostrar valores en textbox´s
            TextBox3.Text = Str(est1)
            TextBox4.Text = Str(est2)
            TextBox5.Text = Str(est3)
            TextBox6.Text = Str(est4)
            TextBox7.Text = Str(est5)
            TextBox8.Text = Str(est6)
            TextBox9.Text = Str(est7)
            TextBox10.Text = Str(est8)
            TextBox11.Text = Str(est9)

        End While





    End Sub

    Private Sub LimpiarEntradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarEntradasToolStripMenuItem.Click

        'limpiar entradas
        DataGridView1.Rows.Clear()


    End Sub

    Private Sub LimpiarEstadísticasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarEstadísticasToolStripMenuItem.Click

        'limpiar estadisticas
        est1 = 0
        est2 = 0
        est3 = 0
        est4 = 0
        est5 = 0
        est6 = 0
        est7 = 0
        est8 = 0
        est9 = 0

        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()


    End Sub

    Private Sub ConsultarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarToolStripMenuItem.Click

        'consultar
        If TextBox12.Text = "" Then
            MsgBox("NO SELECCIÓNÓ NINGÚN COMPETIDOR")
            Exit Sub
        End If

        For fila As Integer = 0 To 11
            If (fila <> Nothing) Then
                If (nombre(fila) = TextBox12.Text) Then
                    ComboBox1.SelectedIndex = etapa(fila)
                    TextBox1.Text = km(fila)
                    TextBox2.Text = tiempo(fila)
                    ComboBox2.SelectedIndex = nacionalidad(fila)
                    Exit Sub
                End If
            End If
        Next


    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        'eliminar
        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)


    End Sub

    Private Sub OrdenarAscendenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenarAscendenteToolStripMenuItem.Click

        'ordenar ascendentemente

        Dim columna As DataGridViewColumn
        Dim ds As New DataSet()
        Dim dt As New DataTable("Columnas")
        Dim dc As New DataColumn("nombre", GetType(String))
        dt.Columns.Add(dc)
        For Each columna In Me.DataGridView1.Columns
            Dim dr As DataRow = dt.NewRow
            dr("nombre") = columna.HeaderText
            dt.Rows.Add(dr)
        Next
        ds.Tables.Add(dt)
        ds.WriteXml("C:\datagridview.xml")



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'salir
        Form2.Show()

    End Sub
End Class
