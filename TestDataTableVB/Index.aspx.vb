Imports System.Web.Services

Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    <WebMethod>
    Public Shared Function ListarAsistencias() As List(Of Asistencia)
        Dim Lista As List(Of Asistencia) = New List(Of Asistencia)()
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000767", .Entrada = DateTime.Now, .Salida = DateTime.Now.AddHours(8), .Canal = 1})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000768", .Entrada = DateTime.Now, .Salida = Nothing, .Canal = 2})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000769", .Entrada = Nothing, .Salida = Nothing, .Canal = 1})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000770", .Entrada = DateTime.Now, .Salida = DateTime.Now.AddHours(8), .Canal = 1})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000771", .Entrada = DateTime.Now, .Salida = DateTime.Now.AddHours(8), .Canal = 2})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000772", .Entrada = DateTime.Now, .Salida = DateTime.Now.AddHours(8), .Canal = 1})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000773", .Entrada = DateTime.Now, .Salida = DateTime.Now.AddHours(8), .Canal = 2})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000774", .Entrada = Nothing, .Salida = Nothing, .Canal = 1})
        Lista.Add(New Asistencia() With {.MASPE_CARNE = "20000775", .Entrada = Nothing, .Salida = Nothing, .Canal = 1})

        For i As Integer = 0 To 30 - 1
            Lista.Add(New Asistencia() With {.MASPE_CARNE = "3000020" & i, .Entrada = DateTime.Now, .Salida = Nothing, .Canal = 1})
        Next

        Return Lista
    End Function

End Class