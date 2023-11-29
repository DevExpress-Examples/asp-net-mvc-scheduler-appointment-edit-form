Imports System.Linq
Imports System.Collections

Namespace SchedulerSimpleCustomFormMvc.Models

    Public Class SchedulerDataObject

        Public Property Appointments As IEnumerable

        Public Property Resources As IEnumerable
    End Class

    Public Class SchedulerDataHelper

        Public Shared Function GetResources() As IEnumerable
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Return From res In db.Cars Select res
        End Function

        Public Shared Function GetAppointments() As IEnumerable
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Return From apt In db.CarSchedulings Select apt
        End Function

        Public Shared ReadOnly Property DataObject As SchedulerDataObject
            Get
                Return New SchedulerDataObject() With {.Appointments = GetAppointments(), .Resources = GetResources()}
            End Get
        End Property

        Public Shared Sub InsertAppointment(ByVal appt As CarScheduling)
            If appt Is Nothing Then Return
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            appt.ID = appt.GetHashCode()
            db.CarSchedulings.InsertOnSubmit(appt)
            db.SubmitChanges()
        End Sub

        Public Shared Sub UpdateAppointment(ByVal appt As CarScheduling)
            If appt Is Nothing Then Return
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Dim query As CarScheduling = CType((From carSchedule In db.CarSchedulings Where carSchedule.ID = appt.ID Select carSchedule).SingleOrDefault(), CarScheduling)
            query.ID = appt.ID
            query.StartTime = appt.StartTime
            query.EndTime = appt.EndTime
            query.AllDay = appt.AllDay
            query.Subject = appt.Subject
            query.Description = appt.Description
            query.Location = appt.Location
            query.RecurrenceInfo = appt.RecurrenceInfo
            query.ReminderInfo = appt.ReminderInfo
            query.Status = appt.Status
            query.EventType = appt.EventType
            query.Label = appt.Label
            query.CarId = appt.CarId
            query.Price = appt.Price
            db.SubmitChanges()
        End Sub

        Public Shared Sub RemoveAppointment(ByVal appt As CarScheduling)
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Dim query As CarScheduling = CType((From carSchedule In db.CarSchedulings Where carSchedule.ID = appt.ID Select carSchedule).SingleOrDefault(), CarScheduling)
            db.CarSchedulings.DeleteOnSubmit(query)
            db.SubmitChanges()
        End Sub
    End Class
End Namespace
