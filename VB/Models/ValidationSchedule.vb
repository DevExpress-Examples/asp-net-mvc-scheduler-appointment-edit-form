Imports System.ComponentModel.DataAnnotations

Namespace SchedulerSimpleCustomFormMvc.Models

    Public Class ValidationSchedule

        Public Property ID As Integer

        <Required(ErrorMessage:="The Subject must contain at least one character.")>
        Public Property Subject As String

        Public Property Price As Decimal?

        <Required>
        Public Property StartTime As Date

        <Required>
        Public Property EndTime As Date
    End Class
End Namespace
