Imports System.Data.SqlClient


Public Class usuariosok

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub usuariosok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Visible = False
        MOSTRAR()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel4.Visible = True
    End Sub

    Sub MOSTRAR()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("mostrar_usuario", conexion)
            da.Fill(dt)
            datalistado.DataSource = dt
            cerrar()
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click

        Try
            Dim cmd As New SqlCommand
            abrir()

            cmd = New SqlCommand("Insertar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@nombres", txtNOMBRE.Text)
            cmd.Parameters.AddWithValue("@Login", txtNOMBRE.Text)
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text)

            cmd.ExecuteNonQuery()
            cerrar()
            MOSTRAR()
            Panel4.Visible = False


        Catch ex As Exception : MsgBox(ex.Message)

        End Try
        
    End Sub

    Private Sub datalistado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellClick
        If e.ColumnIndex = Me.datalistado.Columns.Item("Eli").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("¿Realmente desea eliminar al usuario?", "Eliminando registros...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Try
                    Dim cmd As New SqlCommand
                    abrir()

                    cmd = New SqlCommand("eliminar_usuario", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@idusuario", datalistado.SelectedCells.Item(1).Value)

                    cmd.ExecuteNonQuery()
                    cerrar()
                    MOSTRAR()

                Catch ex As Exception : MsgBox(ex.Message)

                End Try
            Else
                MessageBox.Show("Cancelando eliminacion de registros", "Eliminando registros...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End If
        End If
        
    End Sub

    Private Sub datalistado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellContentClick

    End Sub

    Private Sub datalistado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellDoubleClick
        Try
            Panel4.Visible = True
            GuardarToolStripMenuItem.Visible = False
            GuardarCambiosToolStripMenuItem.Visible = True


            txtNOMBRE.Text = datalistado.SelectedCells.Item(2).Value
            txtLogin.Text = datalistado.SelectedCells.Item(3).Value
            txtPassword.Text = datalistado.SelectedCells.Item(4).Value
            lblIdusuario.Text = datalistado.SelectedCells.Item(1).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarCambiosToolStripMenuItem.Click
        Try
            Dim cmd As New SqlCommand
            abrir()

            cmd = New SqlCommand("editar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idusuario", lblIdusuario.Text)
            cmd.Parameters.AddWithValue("@nombres", txtNOMBRE.Text)
            cmd.Parameters.AddWithValue("@Login", txtNOMBRE.Text)
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text)

            cmd.ExecuteNonQuery()
            cerrar()
            MOSTRAR()
            Panel4.Visible = False
            '@idusuario int,
            '@nombres varchar(50),
            '@Login varchar(50),
            '@Password varchar(50)


        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Sub buscar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("buscar_usuarios", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscar.Text)
            da.Fill(dt)
            datalistado.DataSource = dt
            cerrar()
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        buscar()

    End Sub
End Class