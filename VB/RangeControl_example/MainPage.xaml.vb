Partial Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub
End Class
Public Class DateTimeViewModel
    Public Property Count() As Integer
        Get
            Return privateCount
        End Get
        Set(value As Integer)
            privateCount = Value
        End Set
    End Property
    Private privateCount As Integer
    Public Property Start() As Double
        Get
            Return privateStart
        End Get
        Set(value As Double)
            privateStart = Value
        End Set
    End Property
    Private privateStart As Double
    Private privateitemsSource As IEnumerable
    Public ReadOnly Property ItemsSource() As IEnumerable
        Get
            Return If(privateitemsSource, (InlineAssignHelper(privateitemsSource, CreateItemsSource(Count))))
        End Get
    End Property
    Protected Function GenerateStartValue(random As Random) As Double
        Return Start + random.NextDouble() * 100
    End Function
    Protected Function GenerateAddition(random As Random) As Double
        Dim factor As Double = random.NextDouble()
        If factor = 1 Then
            factor = 50
        ElseIf factor = 0 Then
            factor = -50
        End If
        Return (factor - 0.5) * 50
    End Function
    ReadOnly random As New Random()
    Private begin As New DateTime(2000, 1, 1)
    Public Property [Step]() As TimeSpan
        Get
            Return privateStep
        End Get
        Set(value As TimeSpan)
            privateStep = Value
        End Set
    End Property
    Private privateStep As TimeSpan

    Protected Function CreateItemsSource(count As Integer) As IEnumerable
        Dim points = New List(Of DateTimeDataPoint)()

        Dim value As Double = GenerateStartValue(random)
        points.Add(New DateTimeDataPoint() With { _
            .Value = begin, _
            .DisplayValue = value _
        })
        For i As Integer = 1 To count - 1
            value += GenerateAddition(random)
            begin = begin + [Step]
            points.Add(New DateTimeDataPoint() With { _
                .Value = begin, _
                .DisplayValue = value _
            })
        Next
        Return points
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class
Public Class NumericDataPoint
    Public Property Value() As Integer
        Get
            Return privateValue
        End Get
        Set(value As Integer)
            privateValue = Value
        End Set
    End Property
    Private privateValue As Integer
    Public Property DisplayValue() As Double
        Get
            Return privateDisplayValue
        End Get
        Set(value As Double)
            privateDisplayValue = Value
        End Set
    End Property
    Private privateDisplayValue As Double
End Class
Public Class DateTimeDataPoint
    Public Property Value() As DateTime
        Get
            Return privateValue
        End Get
        Set(value As DateTime)
            privateValue = Value
        End Set
    End Property
    Private privateValue As DateTime
    Public Property DisplayValue() As Double
        Get
            Return privateDisplayValue
        End Get
        Set(value As Double)
            privateDisplayValue = Value
        End Set
    End Property
    Private privateDisplayValue As Double
End Class