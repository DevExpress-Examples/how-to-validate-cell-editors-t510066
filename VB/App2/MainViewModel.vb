Public Class MainViewModel
    Public Sub New()
        CreateList()
    End Sub

    Public Property ProductList() As ObservableCollection(Of Product)
        Get
            Return m_ProductList
        End Get
        Set
            m_ProductList = Value
        End Set
    End Property
    Private m_ProductList As ObservableCollection(Of Product)
    Private Sub CreateList()
        ProductList = New ObservableCollection(Of Product)()
        Dim r As New Random()
        For i As Integer = 0 To 19
            Dim p As New Product(i)
            p.UnitPrice = r.[Next](1, 50)
            ProductList.Add(p)
        Next
    End Sub
End Class


Public Class Product
    Public Sub New(i As Integer)
        ProductName = "Product" + i.ToString()
        Discontinued = i Mod 5 = 0
    End Sub

    Public Property ProductName() As String
        Get
            Return m_ProductName
        End Get
        Set
            m_ProductName = Value
        End Set
    End Property
    Private m_ProductName As String
    Public Property UnitPrice() As Double
        Get
            Return m_UnitPrice
        End Get
        Set
            m_UnitPrice = Value
        End Set
    End Property
    Private m_UnitPrice As Double
    Public Property Discontinued() As Boolean
        Get
            Return m_Discontinued
        End Get
        Set
            m_Discontinued = Value
        End Set
    End Property
    Private m_Discontinued As Boolean
End Class
