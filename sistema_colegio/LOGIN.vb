Public Class login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub txtLogin_Click(sender As Object, e As EventArgs) Handles txtLogin.Click
        txtLogin.Text = ""
        txtLogin.Focus()
    End Sub

    Private Sub txtLogin_TextChanged(sender As Object, e As EventArgs) Handles txtLogin.TextChanged

    End Sub

    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click
        txtPassword.Text = ""
        txtPassword.Focus()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class
