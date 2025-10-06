Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq


Public Class Dashboard
    ' Processed attendance data
    Private attendanceData As Dictionary(Of Date, (InCount As Integer, OutCount As Integer))
    Private studentIn As Integer = 0
    Private studentOut As Integer = 0
    Private employeeIn As Integer = 0
    Private employeeOut As Integer = 0
    Private bgImage As Image

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties for better appearance
        Me.DoubleBuffered = True
        Me.BackColor = Color.FromArgb(240, 240, 240)
        Me.Font = New Font("Segoe UI", 9)

        ' Create a gradient background image
        bgImage = CreateBackgroundImage(Me.ClientSize.Width, Me.ClientSize.Height)

        LoadAttendanceData()
    End Sub

    Private Function CreateBackgroundImage(width As Integer, height As Integer) As Image
        Dim img As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(img)
            ' Light gray to white gradient
            Dim bgBrush As New LinearGradientBrush(
                New Point(0, 0),
                New Point(0, height),
                Color.FromArgb(245, 245, 245),
                Color.White)

            g.FillRectangle(bgBrush, 0, 0, width, height)

            ' Add subtle grid lines
            Dim gridPen As New Pen(Color.FromArgb(230, 230, 230), 1)
            For x As Integer = 0 To width Step 20
                g.DrawLine(gridPen, x, 0, x, height)
            Next
            For y As Integer = 0 To height Step 20
                g.DrawLine(gridPen, 0, y, width, y)
            Next
        End Using
        Return img
    End Function

    Private Sub LoadAttendanceData()
        Dim rawData As New List(Of (DateTime As Date, Status As String, Type As String))
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDataBase.mdf;Integrated Security=True"
        ' Calculate date range (today and past 9 days)
        Dim endDate As Date = Date.Today
        Dim startDate As Date = endDate.AddDays(-9)

        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("SELECT DateTime, InOut, Type FROM tblAttendance WHERE DateTime >= @StartDate AND DateTime < DATEADD(day, 1, @EndDate)", con)
                    cmd.Parameters.AddWithValue("@StartDate", startDate)
                    cmd.Parameters.AddWithValue("@EndDate", endDate)

                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        rawData.Add((
                            DateTime:=reader.GetDateTime(0),
                            Status:=reader.GetString(1),
                            Type:=If(reader.IsDBNull(2), "Unknown", reader.GetString(2))
                        ))
                    End While
                End Using
            End Using

            ' Process data to count IN/OUT per date
            attendanceData = rawData.
                GroupBy(Function(x) x.DateTime.Date).
                ToDictionary(
                    Function(g) g.Key,
                    Function(g) (
                        InCount:=g.Count(Function(x) x.Status = "IN"),
                        OutCount:=g.Count(Function(x) x.Status = "OUT")
                    )
                )

            ' Calculate totals for pie chart by type and status
            studentIn = rawData.Where(Function(x) x.Type = "Student" AndAlso x.Status = "IN").Count()
            studentOut = rawData.Where(Function(x) x.Type = "Student" AndAlso x.Status = "OUT").Count()
            employeeIn = rawData.Where(Function(x) x.Type = "Employee" AndAlso x.Status = "IN").Count()
            employeeOut = rawData.Where(Function(x) x.Type = "Employee" AndAlso x.Status = "OUT").Count()

            ' Ensure we have all 10 days (even if no records exist)
            For i As Integer = 0 To 9
                Dim currentDate As Date = endDate.AddDays(-i)
                If Not attendanceData.ContainsKey(currentDate) Then
                    attendanceData.Add(currentDate, (0, 0))
                End If
            Next

            ' Sort by date (newest first)
            attendanceData = attendanceData.
                Where(Function(x) x.Key >= startDate AndAlso x.Key <= endDate).
                OrderByDescending(Function(x) x.Key).
                ToDictionary(Function(x) x.Key, Function(x) x.Value)

        Catch ex As Exception
            MessageBox.Show("Error loading attendance data: " & ex.Message,
                          "Database Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Dashboard_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If attendanceData Is Nothing OrElse attendanceData.Count = 0 Then
            Dim noDataFont As New Font("Arial", 12, FontStyle.Bold)
            Dim noDataText As String = "No attendance data available for the last 10 days"
            Dim textSize As SizeF = e.Graphics.MeasureString(noDataText, noDataFont)
            e.Graphics.DrawString(noDataText, noDataFont, Brushes.Red,
                                (Me.ClientSize.Width - textSize.Width) / 4,
                                (Me.ClientSize.Height - textSize.Height) / 4)
            Return
        End If

        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        ' Split the form into two sections (60% for bar chart, 40% for pie chart)
        Dim barChartWidth As Integer = CInt(Me.ClientSize.Width * 0.7)
        Dim pieChartWidth As Integer = Me.ClientSize.Width - barChartWidth

        ' Draw the bar chart on the left side
        DrawBarChart(g, barChartWidth)

        ' Draw the pie chart on the right side
        DrawPieChart(g, barChartWidth, pieChartWidth)
    End Sub

    Private Sub DrawBarChart(g As Graphics, chartWidth As Integer)
        ' Chart dimensions
        Dim margin As Integer = 70
        Dim chartHeight As Integer = Me.ClientSize.Height - 2 * margin
        Dim barWidth As Integer = 20 ' Width of each individual bar
        Dim totalPairWidth As Integer = barWidth * 2 ' Total width for IN+OUT pair

        ' Calculate scaling
        Dim maxValue As Integer = attendanceData.Values.Max(Function(x) Math.Max(x.InCount, x.OutCount))
        Dim scaleFactor As Single = If(maxValue > 0, chartHeight / (maxValue * 1.2F), 1)

        ' Draw title with date range
        Dim titleFont As New Font("Arial", 16, FontStyle.Bold)
        Dim subTitleFont As New Font("Arial", 10, FontStyle.Regular)
        Dim startDate As Date = Date.Today.AddDays(-9)
        Dim endDate As Date = Date.Today

        ' Main title
        Dim titleText As String = "Daily Attendance"
        Dim titleSize As SizeF = g.MeasureString(titleText, titleFont)
        g.DrawString(titleText, titleFont, Brushes.DarkSlateBlue,
                 (chartWidth - titleSize.Width) / 2, 7)

        ' Date range
        Dim dateText As String = $"({startDate:MM/dd/yyyy} to {endDate:MM/dd/yyyy})"
        Dim dateSize As SizeF = g.MeasureString(dateText, subTitleFont)
        g.DrawString(dateText, subTitleFont, Brushes.DarkSlateBlue,
                 (chartWidth - dateSize.Width) / 2, 7 + titleSize.Height + 2)

        ' IN/OUT labels
        Dim inOutSpacing As Integer = 20
        Dim inOutY As Integer = 7 + titleSize.Height + dateSize.Height + 10

        ' IN label with color indicator
        Dim inLabel As String = "IN"
        Dim inLabelSize As SizeF = g.MeasureString(inLabel, subTitleFont)
        Dim inLabelX As Integer = (chartWidth / 2) - inOutSpacing - inLabelSize.Width
        g.FillRectangle(New SolidBrush(Color.FromArgb(65, 105, 225)), inLabelX - 20, inOutY + 3, 15, 15)
        g.DrawString(inLabel, subTitleFont, Brushes.Black, inLabelX, inOutY)

        ' OUT label with color indicator
        Dim outLabel As String = "OUT"
        Dim outLabelSize As SizeF = g.MeasureString(outLabel, subTitleFont)
        Dim outLabelX As Integer = (chartWidth / 2) + inOutSpacing
        g.FillRectangle(New SolidBrush(Color.FromArgb(220, 20, 60)), outLabelX - 20, inOutY + 3, 15, 15)
        g.DrawString(outLabel, subTitleFont, Brushes.Black, outLabelX, inOutY)

        ' Draw axes
        Dim axisPen As New Pen(Color.Black, 2)
        Dim originX As Integer = margin
        Dim originY As Integer = margin + chartHeight + 20

        ' X-axis
        g.DrawLine(axisPen, originX, originY, chartWidth - margin, originY)

        ' Y-axis
        g.DrawLine(axisPen, originX, originY, originX, originY - chartHeight)

        ' Draw grid and Y labels
        Dim gridPen As New Pen(Color.LightGray, 1) With {.DashStyle = DashStyle.Dot}
        Dim labelFont As New Font("Arial", 8)

        For i As Integer = 0 To maxValue
            Dim y As Integer = originY - CInt(i * scaleFactor)
            g.DrawLine(gridPen, originX, y, chartWidth - margin, y)
            g.DrawString(i.ToString(), labelFont, Brushes.Black, originX - 30, y - 8)
        Next

        ' Draw bars - perfectly stuck together
        Dim groupLeft As Integer = originX
        Dim perDateGroupWidth As Integer = (chartWidth - 2 * margin) / 10 ' Fixed for 10 days
        Dim statusColors As Brush() = {
            New SolidBrush(Color.FromArgb(65, 105, 225)),   ' Blue for IN
            New SolidBrush(Color.FromArgb(220, 20, 60))    ' Pink for OUT
        }

        ' Display only the last 10 days (already sorted newest first)
        For Each day In attendanceData.Take(10)
            ' Calculate center position for the bar pair
            Dim pairCenter As Integer = groupLeft + perDateGroupWidth / 2

            ' IN bar (left half of the pair)
            Dim inBarLeft As Integer = pairCenter - barWidth
            Dim inHeight As Integer = CInt(day.Value.InCount * scaleFactor)
            g.FillRectangle(statusColors(0), inBarLeft, originY - inHeight, barWidth, inHeight)
            g.DrawRectangle(Pens.DarkBlue, inBarLeft, originY - inHeight, barWidth, inHeight)
            If day.Value.InCount > 0 Then
                g.DrawString(day.Value.InCount.ToString(), labelFont, Brushes.Black,
                            inBarLeft + (barWidth - g.MeasureString(day.Value.InCount.ToString(), labelFont).Width) / 2,
                            originY - inHeight - 15)
            End If

            ' OUT bar (right half of the pair - immediately next to IN bar)
            Dim outBarLeft As Integer = pairCenter
            Dim outHeight As Integer = CInt(day.Value.OutCount * scaleFactor)
            g.FillRectangle(statusColors(1), outBarLeft, originY - outHeight, barWidth, outHeight)
            g.DrawRectangle(Pens.DarkRed, outBarLeft, originY - outHeight, barWidth, outHeight)
            If day.Value.OutCount > 0 Then
                g.DrawString(day.Value.OutCount.ToString(), labelFont, Brushes.Black,
                            outBarLeft + (barWidth - g.MeasureString(day.Value.OutCount.ToString(), labelFont).Width) / 2,
                            originY - outHeight - 15)
            End If

            ' Date label
            Dim dateLabel As String = day.Key.ToString("MM/dd")
            Dim dateLabelSize As SizeF = g.MeasureString(dateLabel, labelFont)
            g.DrawString(dateLabel, labelFont, Brushes.Black,
                        groupLeft + (perDateGroupWidth - dateLabelSize.Width) / 2,
                        originY + 10)

            groupLeft += perDateGroupWidth
        Next

        ' Axis titles
        Dim axisTitleFont As New Font("Arial", 10, FontStyle.Bold)
        Dim xAxisTitle As String = "Date (Last 10 Days)"
        Dim xAxisTitleSize As SizeF = g.MeasureString(xAxisTitle, axisTitleFont)
        g.DrawString(xAxisTitle, axisTitleFont, Brushes.Black,
                    (chartWidth - xAxisTitleSize.Width) / 2,
                    originY + 30)

        ' Rotated Y-axis title
        Dim yTitle As String = "Student / Faculty Total Entry"
        Dim yTitleSize As SizeF = g.MeasureString(yTitle, axisTitleFont)
        g.TranslateTransform(5, originY - chartHeight / 2 + yTitleSize.Width / 2)
        g.RotateTransform(-90)
        g.DrawString(yTitle, axisTitleFont, Brushes.Black, 0, 0)
        g.ResetTransform()
    End Sub

    Private Sub DrawPieChart(g As Graphics, barChartWidth As Integer, pieChartWidth As Integer)
        ' Only draw pie chart if we have data
        If studentIn + studentOut + employeeIn + employeeOut = 0 Then Return

        ' Chart dimensions
        Dim margin As Integer = 50
        Dim chartHeight As Integer = Me.ClientSize.Height - 2 * margin
        Dim centerX As Integer = barChartWidth + (pieChartWidth / 2)
        Dim centerY As Integer = margin + (chartHeight / 2)
        Dim radius As Integer = Math.Min(pieChartWidth, chartHeight) / 2 - margin

        ' Calculate dynamic font size based on pie chart radius
        Dim titleFontSize As Single = Math.Max(8, radius / 8) ' Minimum 8pt, scales with radius
        Dim titleFont As New Font("Arial", titleFontSize, FontStyle.Bold)

        ' Get date range for title
        Dim endDate As Date = Date.Today
        Dim startDate As Date = endDate.AddDays(-9)
        Dim titleText As String = "Attendance and Status"
        Dim titleSize As SizeF = g.MeasureString(titleText, titleFont)

        ' Position title above pie chart with proper spacing
        Dim titleY As Integer = centerY - radius - titleSize.Height - 5 ' 5px padding
        g.DrawString(titleText, titleFont, Brushes.DarkSlateBlue,
                centerX - (titleSize.Width / 2), titleY)

        ' Pie chart colors
        Dim pieColors As Brush() = {
        New SolidBrush(Color.FromArgb(100, 149, 237)),   ' Blue for Student IN
        New SolidBrush(Color.FromArgb(255, 105, 97)),  ' Pink for Student OUT
        New SolidBrush(Color.FromArgb(154, 205, 50)),    ' Green for Employee IN
        New SolidBrush(Color.FromArgb(148, 0, 211))     ' Orange for Employee OUT
    }

        ' Calculate angles
        Dim total As Integer = studentIn + studentOut + employeeIn + employeeOut
        Dim studentInAngle As Single = 360 * (studentIn / total)
        Dim studentOutAngle As Single = 360 * (studentOut / total)
        Dim employeeInAngle As Single = 360 * (employeeIn / total)
        Dim employeeOutAngle As Single = 360 * (employeeOut / total)

        ' Draw pie chart segments
        Dim currentAngle As Single = 0
        g.FillPie(pieColors(0), centerX - radius, centerY - radius, radius * 2, radius * 2, currentAngle, studentInAngle)
        currentAngle += studentInAngle
        g.FillPie(pieColors(1), centerX - radius, centerY - radius, radius * 2, radius * 2, currentAngle, studentOutAngle)
        currentAngle += studentOutAngle
        g.FillPie(pieColors(2), centerX - radius, centerY - radius, radius * 2, radius * 2, currentAngle, employeeInAngle)
        currentAngle += employeeInAngle
        g.FillPie(pieColors(3), centerX - radius, centerY - radius, radius * 2, radius * 2, currentAngle, employeeOutAngle)

        ' Draw outline
        g.DrawEllipse(New Pen(Color.Black, 2), centerX - radius, centerY - radius, radius * 2, radius * 2)

        ' Draw legend
        Dim legendFont As New Font("Arial", 10)
        Dim legendX As Integer = centerX - 70
        Dim legendY As Integer = centerY + radius + 10
        Dim legendItemHeight As Integer = 15
        Dim legendSpacing As Integer = 5

        ' Student IN legend
        g.FillRectangle(pieColors(0), legendX, legendY, 15, legendItemHeight)
        g.DrawRectangle(Pens.Black, legendX, legendY, 15, legendItemHeight)
        g.DrawString($"Student IN: {studentIn} ({Math.Round(100 * studentIn / total)}%)", legendFont, Brushes.Black, legendX + 20, legendY)
        legendY += legendItemHeight + legendSpacing

        ' Student OUT legend
        g.FillRectangle(pieColors(1), legendX, legendY, 15, legendItemHeight)
        g.DrawRectangle(Pens.Black, legendX, legendY, 15, legendItemHeight)
        g.DrawString($"Student OUT: {studentOut} ({Math.Round(100 * studentOut / total)}%)", legendFont, Brushes.Black, legendX + 20, legendY)
        legendY += legendItemHeight + legendSpacing

        ' Employee IN legend
        g.FillRectangle(pieColors(2), legendX, legendY, 15, legendItemHeight)
        g.DrawRectangle(Pens.Black, legendX, legendY, 15, legendItemHeight)
        g.DrawString($"Employee IN: {employeeIn} ({Math.Round(100 * employeeIn / total)}%)", legendFont, Brushes.Black, legendX + 20, legendY)
        legendY += legendItemHeight + legendSpacing

        ' Employee OUT legend
        g.FillRectangle(pieColors(3), legendX, legendY, 15, legendItemHeight)
        g.DrawRectangle(Pens.Black, legendX, legendY, 15, legendItemHeight)
        g.DrawString($"Employee OUT: {employeeOut} ({Math.Round(100 * employeeOut / total)}%)", legendFont, Brushes.Black, legendX + 20, legendY)
    End Sub


End Class