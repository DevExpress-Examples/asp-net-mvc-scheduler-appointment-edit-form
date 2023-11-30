Imports System
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.ASPxScheduler

Namespace SchedulerSimpleCustomFormMvc.Models

    Public Class CustomAppointmentFormTemplateContainer
        Inherits AppointmentFormTemplateContainer

        Public Sub New(ByVal scheduler As MVCxScheduler)
            MyBase.New(scheduler)
        End Sub

        Public ReadOnly Property Price As Decimal?
            Get
                Dim lPrice As Object = Appointment.CustomFields("Price")
                Return If(lPrice Is DBNull.Value, 0, CType(lPrice, Decimal?))
            End Get
        End Property
    End Class
End Namespace
