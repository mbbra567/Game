Public Class Form1
    Dim direction As Integer
    Dim r As New Random()
    Dim xdir As Integer
    Dim ydir As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If direction < 0 Then
            MoveTo(Bullet, 5, 0)
        End If
        If direction < 0 Then
            MoveTo(Bullet, 5, 0)
        End If
        chase(lose)
    End Sub
    Sub Move(P As PictureBox, x As Integer, y As Integer)
        P.Location = New Point(P.Location.X + x, P.Location.Y + y)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.R
                direction = direction + 1
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Me.Refresh()
            Case Keys.F
                direction = direction - 1
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
                Me.Refresh()
            Case Keys.Left, Keys.A
                MoveTo(PictureBox1, -5, 0)
            Case Keys.Right, Keys.D
                MoveTo(PictureBox1, 5, 0)
            Case Keys.Up, Keys.W
                MoveTo(PictureBox1, 0, -5)
            Case Keys.Down, Keys.S
                MoveTo(PictureBox1, 0, 5)
            Case Keys.E
                Bullet.Location = PictureBox1.Location
                Timer2.Enabled = True
                Bullet.Visible = True
            Case Keys.Q
                bullet3.Location = PictureBox1.Location
                Timer7.Enabled = True
                bullet3.Visible = True
            Case Else

        End Select
    End Sub
    Sub randommove(p As PictureBox)
        Dim xdir As Integer = r.Next(-20, 21)
        Dim ydir As Integer = r.Next(-20, 21)

        MoveTo(p, xdir, ydir)
    End Sub
    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > PictureBox1.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < PictureBox1.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, x, y)
    End Sub
    Function Collision(p As String, t As String, Optional ByRef other As Object = vbNull)
        For Each c In Controls
            If c.name.toupper.ToString.Contains(p.ToUpper) Then
                Return Collision(c, t, other)
            End If
        Next
        Return False
    End Function

    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function

    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function


    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "PictureBox1" And Collision(p, "WIN", other) Then
            Me.BackColor = Color.Green
            other.visible = False
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose", other) Then
            Me.BackColor = Color.Red

            Return

        End If
        If p.Name = "PictureBox1" And Collision(p, "lose2", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose3", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose4", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose5", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose6", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose7", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose8", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose9", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose10", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose11", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose12", other) Then
            Me.BackColor = Color.Red
        End If
        If p.Name = "PictureBox1" And Collision(p, "lose13", other) Then
            Me.BackColor = Color.Red
        End If
    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        MoveTo(Bullet, 0, -5)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        randommove(win)
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        chase(lose2)
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        chase(lose3)
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        If direction < 0 Then
            MoveTo(bullet3, 5, 0)
        End If
        If direction < 0 Then
            MoveTo(bullet3, 5, 0)
        End If
    End Sub

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        MoveTo(bullet3, 0, -5)

    End Sub

    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        chase(lose4)
    End Sub

    Private Sub Timer9_Tick(sender As Object, e As EventArgs) Handles Timer9.Tick
        chase(lose5)
    End Sub

    Private Sub Timer10_Tick(sender As Object, e As EventArgs) Handles Timer10.Tick
        chase(lose6)
    End Sub

    Private Sub Timer11_Tick(sender As Object, e As EventArgs) Handles Timer11.Tick
        chase(lose7)
    End Sub

    Private Sub Timer12_Tick(sender As Object, e As EventArgs) Handles Timer12.Tick
        chase(lose8)
    End Sub

    Private Sub Timer13_Tick(sender As Object, e As EventArgs) Handles Timer13.Tick
        chase(lose9)
    End Sub

    Private Sub Timer14_Tick(sender As Object, e As EventArgs) Handles Timer14.Tick
        chase(lose10)
    End Sub

    Private Sub Timer15_Tick(sender As Object, e As EventArgs) Handles Timer15.Tick
        chase(lose11)
    End Sub

    Private Sub Timer16_Tick(sender As Object, e As EventArgs) Handles Timer16.Tick
        chase(lose12)
    End Sub

    Private Sub Timer17_Tick(sender As Object, e As EventArgs) Handles Timer17.Tick
        chase(lose13)
    End Sub
End Class

