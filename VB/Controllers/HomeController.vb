Imports DevExpress.Web.Mvc
Imports SchedulerSimpleCustomFormMvc.Code
Imports SchedulerSimpleCustomFormMvc.Models
Imports System.Web.Mvc

Namespace SchedulerSimpleCustomFormMvc

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View(SchedulerDataHelper.DataObject)
        End Function

        Public Function SchedulerPartial() As ActionResult
            Return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject)
        End Function

        Public Function EditAppointment() As ActionResult
            Call UpdateAppointment()
            Return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject)
        End Function

        Private Shared Sub UpdateAppointment()
            Dim insertedAppt As CarScheduling = SchedulerExtension.GetAppointmentToInsert(Of CarScheduling)(Settings, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources())
            SchedulerDataHelper.InsertAppointment(insertedAppt)
            Dim updatedAppt As CarScheduling() = SchedulerExtension.GetAppointmentsToUpdate(Of CarScheduling)(Settings, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources())
            For Each appt In updatedAppt
                SchedulerDataHelper.UpdateAppointment(appt)
            Next

            Dim removedAppt As CarScheduling() = SchedulerExtension.GetAppointmentsToRemove(Of CarScheduling)(Settings, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources())
            For Each appt In removedAppt
                SchedulerDataHelper.RemoveAppointment(appt)
            Next
        End Sub
    End Class
End Namespace
