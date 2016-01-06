Imports Dalboth.Dalboth
Imports Cal.Cal
Public Class Calculator
    Dim mybuttons = New List(Of Button)

    Dim stretch As Double = 1
    Dim tempstretch = stretch
    Dim oldXY As Point = Point.Empty
    Dim X0 As Integer
    Dim X1 As Integer
    Dim X2 As Integer
    Dim X3 As Integer
    Dim X4 As Integer
    Dim circlemode = False
    Private Sub Calculator_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim o As Object
        For Each o In Me.Controls
            If TypeOf o Is Button Then
                mybuttons.add(o)
            End If
        Next
        For Each btn As Button In mybuttons
            btn.BackColor = Color.BlanchedAlmond
            AddHandler btn.Click, AddressOf myButton_Click
        Next
    End Sub
    Sub drawaxis()
        Dim g As Graphics
        g = Graph.CreateGraphics
        Dim blackpen As New Drawing.Pen(Color.Black, 3)
        Dim redpen As New Drawing.Pen(Color.Red, 3)
        g.DrawLine(blackpen, 0, 200, 400, 200)
        g.DrawLine(blackpen, 200, 0, 200, 400)
        For i = -10 To 10
            If i Mod 5 = 0 Then
                g.DrawLine(redpen, 200 + (i * 20), 200, 200 + (i * 20), 220)
            Else
                g.DrawLine(blackpen, 200 + (i * 20), 200, 200 + (i * 20), 210)
            End If

        Next
        For i = -10 To 10
            If i Mod 5 = 0 Then
                g.DrawLine(redpen, 200, 200 + (i * 20), 220, 200 + (i * 20))
            Else
                g.DrawLine(blackpen, 200, 200 + (i * 20), 210, 200 + (i * 20))
            End If
            Label14.Text = "Scale = (" + Str(Math.Round(tempstretch, 1)) + " To " + Str(Math.Round(-tempstretch, 1)) + ")"
        Next
        
    End Sub
    Private Sub myButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        For Each btnn As Button In mybuttons
            btnn.BackColor = Color.BlanchedAlmond
        Next
        btn.BackColor = Color.Beige
    End Sub
    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs)
        Dim doublekey As Double = 0.0
        Try
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = add(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub SubBtn_Click(sender As System.Object, e As System.EventArgs)
        Dim doublekey As Double = 0.0
        Try
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = Subtract(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub MultBtn_Click(sender As System.Object, e As System.EventArgs)
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = Multiply(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub DivBtn_Click(sender As System.Object, e As System.EventArgs)
        Dim doublekey As Double = 0.0
        Try
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = Divide(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub SqrtBtn_Click(sender As System.Object, e As System.EventArgs) Handles SqrtBtn.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                OUTTB.Text = Sqrt(ATB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub QUADbtn_Click(sender As System.Object, e As System.EventArgs) Handles QUADbtn.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) And Double.TryParse(CTB.Text, doublekey) Then
                OUTTB.Text = QuadSolve(ATB.Text, BTB.Text, CTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub LogB10_Click(sender As System.Object, e As System.EventArgs) Handles LogB10.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                OUTTB.Text = Log(ATB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub LogB_Click(sender As System.Object, e As System.EventArgs) Handles LogBBtn.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = LogB(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub FahrToCel_Click(sender As System.Object, e As System.EventArgs) Handles FahrToCelBtn.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                OUTTB.Text = FahrToCel(ATB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub CTF_Click(sender As System.Object, e As System.EventArgs) Handles CTF.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                OUTTB.Text = CelToFahr(ATB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Factorial_Click(sender As System.Object, e As System.EventArgs) Handles FactorialBtn.Click
        Try
            Dim Longkey As Long = 0
            If Long.TryParse(ATB.Text, Longkey) Then
                OUTTB.Text = Factorial(ATB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Tuppers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start("D:\StudentData\Year12\Dalboth, James\CalPackage\CalculatorCOMP\Tuppers\Tuppers\Tuppers\Tuppers\bin\Debug\Tuppers.exe")
    End Sub

    Private Sub PIVBtn_Click(sender As System.Object, e As System.EventArgs) Handles PIVBtn.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = PowerIV(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub CurrentBtn_Click(sender As System.Object, e As System.EventArgs) Handles CurrentBtn.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = CurrentPV(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start("D:\StudentData\Year12\Dalboth, James\Binary Added\Binary Added\bin\Debug\Binary Added.exe")
    End Sub

    Private Sub VPI_Click(sender As System.Object, e As System.EventArgs) Handles VPI.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) Then
                OUTTB.Text = VoltagePI(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub RLRA_Click(sender As System.Object, e As System.EventArgs) Handles RLRA.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) And Double.TryParse(CTB.Text, doublekey) Then
                OUTTB.Text = RestivityLRA(ATB.Text, BTB.Text, CTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub RLPA_Click(sender As System.Object, e As System.EventArgs) Handles RLPA.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) And Double.TryParse(BTB.Text, doublekey) And Double.TryParse(CTB.Text, doublekey) Then
                OUTTB.Text = ResistanceLPA(ATB.Text, BTB.Text, CTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub L_Click(sender As System.Object, e As System.EventArgs) Handles L.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                OUTTB.Text = Ln(ATB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub NPR_Click(sender As System.Object, e As System.EventArgs) Handles NPRbtn.Click
        Try
            Dim intkey As Integer = 0.0
            If Integer.TryParse(ATB.Text, intkey) And Integer.TryParse(BTB.Text, intkey) And Int(ATB.Text) > Int(BTB.Text) Then
                OUTTB.Text = nPr(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub NCRbtn_Click(sender As System.Object, e As System.EventArgs) Handles NCRbtn.Click
        Try
            Dim intkey As Integer = 0.0
            If Integer.TryParse(ATB.Text, intkey) And Integer.TryParse(BTB.Text, intkey) And Int(ATB.Text) > Int(BTB.Text) Then
                OUTTB.Text = nCr(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub BinDis_Click(sender As System.Object, e As System.EventArgs) Handles BinDis.Click
        Try
            Dim intkey As Integer = 0.0
            Dim doublekey As Integer = 0.0
            If Integer.TryParse(ATB.Text, intkey) And Integer.TryParse(BTB.Text, intkey) And Double.TryParse(CTB.Text, doublekey) And Val(CTB.Text) < 1 And Val(CTB.Text) > 0 Then
                OUTTB.Text = BDis(ATB.Text, BTB.Text, CTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub GEodis_Click(sender As System.Object, e As System.EventArgs) Handles GEodis.Click
        Try
            Dim intkey As Integer = 0.0
            Dim doublekey As Integer = 0.0
            If Integer.TryParse(ATB.Text, intkey) And Double.TryParse(BTB.Text, doublekey) And Val(BTB.Text) < 1 And Val(BTB.Text) > 0 Then
                OUTTB.Text = GDis(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Powbtn_Click(sender As System.Object, e As System.EventArgs)
        Try
            Dim intkey As Integer = 0.0
            Dim doublekey As Integer = 0.0
            If Integer.TryParse(BTB.Text, intkey) And Double.TryParse(ATB.Text, doublekey) Then
                OUTTB.Text = POW(ATB.Text, BTB.Text)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub SuvatBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuvatBtn.Click
        Dim doublekey As Integer = 0.0
        Dim S As String
        Dim U As String
        Dim V As String
        Dim A As String
        Dim T As String
        Dim count = 0
        If ATB.Text = "" Or Double.TryParse(ATB.Text, doublekey) = False Then
            S = "*"
        Else
            S = (ATB.Text)
        End If
        If BTB.Text = "" Or Double.TryParse(BTB.Text, doublekey) = False Then
            U = "*"
        Else
            U = (BTB.Text)
        End If
        If CTB.Text = "" Or Double.TryParse(CTB.Text, doublekey) = False Then
            V = "*"
        Else
            V = (CTB.Text)
        End If
        If DTB.Text = "" Or Double.TryParse(DTB.Text, doublekey) = False Then
            A = "*"
        Else
            A = (DTB.Text)
        End If
        If ETB.Text = "" Or Double.TryParse(ETB.Text, doublekey) = False Then
            T = "*"
        Else
            T = (ETB.Text)
        End If
        If S = "*" Then count += 1
        If U = "*" Then count += 1
        If V = "*" Then count += 1
        If A = "*" Then count += 1
        If T = "*" Then count += 1
        Try
            If count < 3 Then

                If count <= 2 Then
                    Do Until count = 0
                        If S = "*" Then
                            If U = "*" Then
                                S = (Val(V) * Val(T)) - ((0.5) * Val(A) * Val(T) * Val(T))
                            ElseIf V = "*" Then
                                S = (Val(U) * Val(T)) + ((0.5) * Val(A) * Val(T) * Val(T))
                            ElseIf A = "*" Then
                                S = (Val(U) + Val(V)) * Val(T) * 0.5
                            ElseIf T = "*" Then
                                S = ((Val(V) ^ 2) - (Val(U) ^ 2) / Val(A) * 2)
                            Else
                                S = ((Val(V) ^ 2) - (Val(U) ^ 2) / Val(A) * 2)
                            End If
                        ElseIf U = "*" Then
                            If S = "*" Then
                                U = Val(V) - Val(A) * Val(T)
                            ElseIf V = "*" Then
                                U = (Val(S) / Val(T)) + (0.5 * Val(A) * Val(T))
                            ElseIf A = "*" Then
                                U = (2 * Val(S) / Val(T)) - Val(V)
                            ElseIf T = "*" Then
                                U = ((Val(V) ^ 2) - 1 * Val(A) * Val(S)) ^ 0.5
                            Else
                                U = ((Val(V) ^ 2) - 2 * Val(A) * Val(S)) ^ 0.5
                            End If
                        ElseIf V = "*" Then
                            If S = "*" Then
                                V = Val(U) + Val(A) * Val(T)
                            ElseIf U = "*" Then
                                V = (Val(S) / Val(T)) - (0.5 * Val(A) * Val(T))
                            ElseIf A = "*" Then
                                V = (2 * Val(S) / Val(T)) - Val(U)
                            ElseIf T = "*" Then
                                V = ((Val(U) ^ 2) + 2 * Val(A) * Val(S)) ^ 0.5
                            Else
                                V = ((Val(U) ^ 2) + 2 * Val(A) * Val(S)) ^ 0.5
                            End If
                        ElseIf A = "*" Then
                            If S = "*" Then
                                A = (Val(V) - Val(U)) / Val(T)
                            ElseIf U = "*" Then
                                A = (2 * ((Val(V) * Val(T)) - Val(S)) / (Val(T) ^ 2))
                            ElseIf V = "*" Then
                                A = (2 * ((Val(V) * Val(T)) + Val(S)) / (Val(T) ^ 2))
                            ElseIf T = "*" Then
                                A = ((Val(V) ^ 2) - (Val(U) ^ 2) / Val(S) * 2)
                            Else
                                A = ((Val(V) ^ 2) - (Val(U) ^ 2) / Val(S) * 2)
                            End If
                        ElseIf T = "*" Then
                            If S = "*" Then
                                T = (Val(V) - Val(U)) / Val(A)
                            ElseIf U = "*" Then
                                Dim B = -Val(V)
                                Dim Adis = 0.5 * (Val(A))
                                Dim C = Val(S)
                                Dim ans = QuadSolve(Adis, B, C)
                                T = ans
                            ElseIf V = "*" Then
                                Dim B = Val(U)
                                Dim Adis = 0.5 * (Val(A))
                                Dim C = -Val(S)
                                Dim ans = QuadSolve(Adis, B, C)
                                T = ans
                            ElseIf A = "*" Then
                                T = (2 * Val(S)) / (Val(U) + Val(V))
                            Else
                                T = (2 * Val(S)) / (Val(U) + Val(V))
                            End If
                        End If
                        count = 0
                        If S = "*" Then count += 1
                        If U = "*" Then count += 1
                        If V = "*" Then count += 1
                        If A = "*" Then count += 1
                        If T = "*" Then count += 1
                    Loop
                    Try
                        Label7.Text = "S : " + Str(Math.Round(Val(S), 4))
                        Label8.Text = "U : " + Str(Math.Round(Val(U), 4))
                        Label9.Text = "V : " + Str(Math.Round(Val(V), 4))
                        Label10.Text = "A : " + Str(Math.Round(Val(A), 4))
                        Label11.Text = "T : " + Str(Math.Round(Val(T), 4))
                    Catch
                    End Try
                End If

            End If
        Catch
            MsgBox("CRASH")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim Longkey As Long = 0
            If Long.TryParse(ATB.Text, Longkey) Then
                Dim Cur As Long = 1
                Dim N As Long
                Dim Prime As Double = 2
                Dim foundPrime As Double
                Dim test As Double
                Dim IsPrime As Boolean

                N = Val(ATB.Text)
                While (Cur <= N)
                    IsPrime = True

                    test = 2
                    Do While IsPrime And (test <= Sqrt(Prime))
                        IsPrime = (Prime Mod test > 0)
                        test = test + 1 - CDbl(test > 2)
                    Loop
                    If IsPrime Then
                        foundPrime = Prime
                        Cur += 1
                    End If
                    Prime += 1
                End While
                OUTTB.Text = Prime - 1
            Else
                OUTTB.Text = "ERROR"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                If Val(ATB.Text) Mod 90 = 0 And Val(ATB.Text) Mod 180 > 0 Then
                    OUTTB.Text = "ERROR"
                Else
                    If circlemode = False Then
                        OUTTB.Text = Math.Round(Math.Tan((Val(ATB.Text) * Math.PI) / 180), 4)
                    Else
                        OUTTB.Text = Math.Round(Math.Tan(Val(ATB.Text)), 4)
                    End If
                End If
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                If circlemode = False Then
                    OUTTB.Text = Math.Round(Math.Cos((Val(ATB.Text) * Math.PI) / 180), 4)
                Else
                    OUTTB.Text = Math.Round(Math.Cos(Val(ATB.Text)), 4)
                End If
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(ATB.Text, doublekey) Then
                If circlemode = False Then
                    OUTTB.Text = Math.Round(Math.Sin((Val(ATB.Text) * Math.PI) / 180), 4)
                Else
                    OUTTB.Text = Math.Round(Math.Sin(Val(ATB.Text)), 4)
                End If
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim intkey As Integer = 0
        Try
            Dim ans
            If Integer.TryParse(ATB.Text, intkey) And Val(ATB.Text) < 5000 Then
                ans = ""
                Dim num = Val(ATB.Text)
                Dim CoM = Math.Floor(num / 1000)
                For i = 1 To CoM
                    ans += "M"
                    num -= 1000
                Next
                Dim CoD = Math.Floor(num / 500)
                For i = 1 To CoD
                    ans += "D"
                    num -= 500
                Next
                Dim CoC = Math.Floor(num / 100)
                For i = 1 To CoC
                    ans += "C"
                    num -= 100
                Next
                Dim CoL = Math.Floor(num / 50)
                For i = 1 To CoL
                    ans += "L"
                    num -= 50
                Next
                Dim CoX = Math.Floor(num / 10)
                For i = 1 To CoX
                    ans += "X"
                    num -= 10
                Next
                Dim CoV = Math.Floor(num / 5)
                For i = 1 To CoV
                    ans += "V"
                    num -= 5
                Next
                Dim CoI = Math.Floor(num / 1)
                For i = 1 To CoI
                    ans += "I"
                    num -= 1
                Next
                ans = Replace(ans, "IIII", "IV")
                ans = Replace(ans, "XXXX", "XL")
                ans = Replace(ans, "VIV", "IX")
                ans = Replace(ans, "LXL", "XC")
                ans = Replace(ans, "CCCC", "CD")
                ans = Replace(ans, "DCD", "CM")
            End If
            OUTTB.Text = ans
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub Graph_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Graph.Paint

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        drawaxis()
    End Sub
    Sub drawgraph(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Dim g As Graphics
        g = Graph.CreateGraphics
        Dim blackpen As New Drawing.Pen(Color.Red, 3)
        g.DrawLine(blackpen, x1 + 200, -(y1 - 200), x2 + 200, -(y2 - 200))
    End Sub
    Sub drawplot()
        Graph.Refresh()
        Dim xf = -200 * (stretch / 200)
        Dim yf = (X0 + (X1 * xf) + (X2 * xf ^ 2) + (X3 * xf ^ 3) + (X4 * xf ^ 4))
        xf /= (stretch / 200)
        yf *= (200 / stretch)
        For i = -199 To 200
            Dim x = i * (stretch / 200)
            Dim y = (X0 + (X1 * x) + (X2 * x ^ 2) + (X3 * x ^ 3) + (X4 * x ^ 4))
            y = y * (200 / stretch)
            y = (Math.Round(y))

            If y < 400 And y > -400 And yf < 400 And yf > -400 Then
                drawgraph(xf, yf, i, y)
            End If
            xf = i
            yf = y
        Next
    End Sub
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        X0 = Val(ATB.Text)
        X1 = Val(BTB.Text)
        X2 = Val(CTB.Text)
        X3 = Val(DTB.Text)
        X4 = Val(ETB.Text)
        Dim text As String = "Y="
        If X4 <> 0 Then
            text += Str(X4) + "X^4 + "
        End If
        If X3 <> 0 Then
            text += Str(X3) + "X^3 + "
        End If
        If X2 <> 0 Then
            text += Str(X2) + "X^2 + "
        End If
        If X1 <> 0 Then
            text += Str(X1) + "X + "
        End If
        If X0 <> 0 Then
            text += Str(X0)
        Else
            text += "0"
        End If
        drawplot()
        Button6.Text = text
    End Sub

    Private Sub Graph_MouseDown(sender As System.Object, e As System.EventArgs) Handles Graph.MouseDown
        Graph.Cursor = Cursors.Cross
        Graph.Tag = "SCROLL"

    End Sub

    Private Sub Graph_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Graph.MouseUp
        Graph.Cursor = Cursors.Default
        Graph.Tag = ""
        tempstretch = stretch
        drawplot()
    End Sub

    Private Sub Graph_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Graph.MouseMove
        If Graph.Tag = "SCROLL" Then
            If e.Y < oldXY.Y Then
                stretch += 0.1
            ElseIf e.Y > oldXY.Y Then
                stretch -= 0.1
            End If
            If stretch < 0.1 Then
                stretch = 0.1
            Else
                If stretch > 10000 Then
                    stretch = 10000
                End If
            End If
            oldXY.X = e.X
            oldXY.Y = e.Y

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(TextBox1.Text, doublekey) And Val(TextBox1.Text) > 0.09 And Val(TextBox1.Text) < 10000.1 Then
                stretch = Val(TextBox1.Text)
                tempstretch = stretch
                drawaxis()
                drawplot()
            Else
            End If
        Catch
        End Try
    End Sub

    Private Sub DegreeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DegreeToolStripMenuItem.Click
        circlemode = False

    End Sub

    Private Sub RadiansToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RadiansToolStripMenuItem.Click
        circlemode = True
    End Sub
    Dim BaseNums As New Dictionary(Of String, Integer)

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Try
            Dim iNumber As Integer = Val(ATB.Text)
            Dim IfromBase As Integer = Val(BTB.Text)
            Dim Itobase As Integer = Val(CTB.Text)
            Dim A As Long
            Dim Temp As String
            Dim Length As Long
            Dim Number As Long
            Dim Base10 As Long
            Dim Result As Long
            Dim Minus As Long
            Minus = Math.Sign(iNumber)
            If IfromBase = 10 Then
                Base10 = Math.Abs(CLng(iNumber))
            Else
                Temp = CStr(Math.Abs(CLng(iNumber)))
                Length = Len(Temp)
                For A = 0 To Length - 1
                    Number = CLng(Mid(Temp, Length - A, 1))
                    Base10 = Base10 + (IfromBase ^ A) * Number
                Next
            End If
            If Itobase = 10 Then
                OUTTB.Text = Str(Minus * (CDbl(Base10)))
                Exit Sub
            End If
            Length = 0
            While Base10 > 0
                If Base10 < Itobase Then
                    Result = Result + (10 ^ Length) * Base10
                    Base10 = 0

                Else
                    Number = Base10 Mod Itobase
                    Result = Result + (10 ^ Length) * Number
                    Base10 = Int(Base10 / Itobase)
                End If
                Length = Length + 1
            End While
            OUTTB.Text = Str(Minus * (CDbl(Result)))
        Catch
            OUTTB.Text = "ERROR"
        End Try
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Try
            Dim Operands As New Dictionary(Of String, Integer)
            Operands.Add(")", 4)
            Operands.Add("(", 4)
            Operands.Add("^", 1)
            Operands.Add("*", 2)
            Operands.Add("/", 2)
            Operands.Add("\", 2)
            Operands.Add("+", 3)
            Operands.Add("-", 3)
            Dim stack As New Stack
            Dim Postfix As New List(Of String)
            Dim INPUT = INFIXTb.Text
            Dim INFIX = ""
            For i = 1 To INPUT.Length
                INFIX += Mid(INPUT, i, 1)
            Next
            INFIX += "="
            Dim num As String = ""
            For Each I In INFIX
                If IsNumeric(I) Or I = "." Or (num.Length = 0 And I = "-") Then
                    num += I
                ElseIf I = "=" Then
                    Postfix.Add(num)
                ElseIf Operands.ContainsKey(I) Then
                    Postfix.Add(num)
                    num = ""
                    If stack.Count = 0 Then
                        stack.Push(I)
                    ElseIf I = ")" Then
                        Dim stackchar = stack.Pop
                        Do Until stackchar = "("
                            Postfix.Add(stackchar)
                            stackchar = stack.Pop
                        Loop
                    ElseIf I = "(" Then
                        stack.Push(I)
                    Else
                        Dim cur = Operands.Item(I)
                        Dim stackpres = Operands.Item(stack.Peek)
                        Do Until (cur < stackpres)
                            Postfix.Add(stack.Pop)
                            If stack.Count = 0 Then
                                stackpres = 100
                            Else
                                stackpres = Operands.Item(stack.Peek)
                            End If
                        Loop
                        stack.Push(I)
                    End If
                Else
                    Exit Sub
                End If
            Next
            For i = 1 To stack.Count
                Postfix.Add(stack.Pop)
            Next
            Dim Result As New Stack
            Dim temp As Double = 0.0
            For i = 0 To Postfix.Count - 1
                If Postfix(i) = "" Then
                Else
                    If Operands.ContainsKey(Postfix(i)) Then
                        If Postfix(i) = "+" Then
                            temp = (Convert.ToDouble(Result.Pop)) + (Convert.ToDouble(Result.Pop))
                            Result.Push(Str(temp))
                        ElseIf Postfix(i) = "-" Then
                            Dim minus = Result.Pop
                            temp = (Convert.ToDouble(Result.Pop)) - (Convert.ToDouble(minus))
                            Result.Push(Str(temp))
                        ElseIf Postfix(i) = "\" Or Postfix(i) = "/" Then
                            Dim denominator = Result.Pop
                            temp = (Convert.ToDouble(Result.Pop)) / (Convert.ToDouble(denominator))
                            Result.Push(Str(temp))
                        ElseIf Postfix(i) = "*" Then
                            temp = (Convert.ToDouble(Result.Pop)) * (Convert.ToDouble(Result.Pop))
                            Result.Push(Str(temp))
                        ElseIf Postfix(i) = "^" Then
                            Dim power = Result.Pop
                            Dim base = Result.Pop
                            temp = (Convert.ToDouble(base)) ^ (Convert.ToDouble(power))
                            Result.Push(Str(temp))
                        End If
                    Else
                        Result.Push(Postfix(i))
                    End If
                End If
            Next
            OUTTB.Text = Result.Pop
        Catch ex As Exception
            OUTTB.Text = "ERROR"
        End Try

    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Try
            Dim doublekey As Double = 0.0
            If Double.TryParse(MinTb.Text, doublekey) And Double.TryParse(MaxTb.Text, doublekey) And (Convert.ToDouble(MinTb.Text) < Convert.ToDouble(MaxTb.Text)) Then
                Dim rand = Convert.ToDouble(MinTb.Text) + (Rnd() * (Convert.ToDouble(MaxTb.Text) - Convert.ToDouble(MinTb.Text)))
                OUTTB.Text = Str(rand)
            Else
                OUTTB.Text = "N/A"
            End If
        Catch
            OUTTB.Text = "Error"
        End Try
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class
