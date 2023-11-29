Imports System
Imports System.Web.Mvc
Imports System.Web.Mvc.Html
Imports DevExpress.Web.Mvc
Imports SchedulerSimpleCustomFormMvc.Models
Imports System.Runtime.CompilerServices

Namespace SchedulerSimpleCustomFormMvc.Code

    Public Module SchedulerHelper

        Private settingsField As DevExpress.Web.Mvc.SchedulerSettings

        Public ReadOnly Property Settings As SchedulerSettings
            Get
                If SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.settingsField Is Nothing Then SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.settingsField = SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.CreateSchedulerSettings(Nothing)
                Return SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.settingsField
            End Get
        End Property

        <Extension()>
        Public Function CreateSchedulerSettings(ByVal htmlHelper As System.Web.Mvc.HtmlHelper) As SchedulerSettings
            Dim settings As DevExpress.Web.Mvc.SchedulerSettings = New DevExpress.Web.Mvc.SchedulerSettings()
            settings.Name = "scheduler"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "SchedulerPartial"}
            settings.EditAppointmentRouteValues = New With {.Controller = "Home", .Action = "EditAppointment"}
            settings.Storage.Appointments.Assign(SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.DefaultAppointmentStorage)
            settings.Storage.Resources.Assign(SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.DefaultResourceStorage)
            settings.AppointmentFormShowing = Sub(sender, e)
                Dim scheduler As DevExpress.Web.Mvc.MVCxScheduler = TryCast(sender, DevExpress.Web.Mvc.MVCxScheduler)
                If scheduler IsNot Nothing Then e.Container = New SchedulerSimpleCustomFormMvc.Models.CustomAppointmentFormTemplateContainer(scheduler)
            End Sub
            settings.OptionsForms.SetAppointmentFormTemplateContent(Sub(c)
                Dim container As SchedulerSimpleCustomFormMvc.Models.CustomAppointmentFormTemplateContainer = CType(c, SchedulerSimpleCustomFormMvc.Models.CustomAppointmentFormTemplateContainer)
                Dim schedule As SchedulerSimpleCustomFormMvc.Models.ValidationSchedule = New SchedulerSimpleCustomFormMvc.Models.ValidationSchedule() With {.ID = If(container.Appointment.Id Is Nothing, -1, CInt(container.Appointment.Id)), .Subject = container.Appointment.Subject, .StartTime = container.Appointment.Start, .EndTime = container.Appointment.[End], .Price = container.Price}
                htmlHelper.ViewData("DeleteButtonEnabled") = container.CanDeleteAppointment
                htmlHelper.RenderPartial("CustomAppointmentFormPartial", schedule)
            End Sub)
            settings.Storage.Appointments.ResourceSharing = True
            settings.Start = New System.DateTime(2008, 7, 11)
            Return settings
        End Function

        Private defaultAppointmentStorageField As DevExpress.Web.Mvc.MVCxAppointmentStorage

        Public ReadOnly Property DefaultAppointmentStorage As MVCxAppointmentStorage
            Get
                If SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.defaultAppointmentStorageField Is Nothing Then SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.defaultAppointmentStorageField = SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.CreateDefaultAppointmentStorage()
                Return SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.defaultAppointmentStorageField
            End Get
        End Property

        Private Function CreateDefaultAppointmentStorage() As MVCxAppointmentStorage
            Dim appointmentStorage As DevExpress.Web.Mvc.MVCxAppointmentStorage = New DevExpress.Web.Mvc.MVCxAppointmentStorage()
            appointmentStorage.Mappings.AppointmentId = "ID"
            appointmentStorage.Mappings.Start = "StartTime"
            appointmentStorage.Mappings.[End] = "EndTime"
            appointmentStorage.Mappings.Subject = "Subject"
            appointmentStorage.Mappings.Description = "Description"
            appointmentStorage.Mappings.Location = "Location"
            appointmentStorage.Mappings.AllDay = "AllDay"
            appointmentStorage.Mappings.Type = "EventType"
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo"
            appointmentStorage.Mappings.ReminderInfo = "ReminderInfo"
            appointmentStorage.Mappings.Label = "Label"
            appointmentStorage.Mappings.Status = "Status"
            appointmentStorage.Mappings.ResourceId = "CarId"
            appointmentStorage.CustomFieldMappings.Add("Price", "Price")
            Return appointmentStorage
        End Function

        Private defaultResourceStorageField As DevExpress.Web.Mvc.MVCxResourceStorage

        Public ReadOnly Property DefaultResourceStorage As MVCxResourceStorage
            Get
                If SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.defaultResourceStorageField Is Nothing Then SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.defaultResourceStorageField = SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.CreateDefaultResourceStorage()
                Return SchedulerSimpleCustomFormMvc.Code.SchedulerHelper.defaultResourceStorageField
            End Get
        End Property

        Private Function CreateDefaultResourceStorage() As MVCxResourceStorage
            Dim resourceStorage As DevExpress.Web.Mvc.MVCxResourceStorage = New DevExpress.Web.Mvc.MVCxResourceStorage()
            resourceStorage.Mappings.ResourceId = "ID"
            resourceStorage.Mappings.Caption = "Model"
            Return resourceStorage
        End Function
    End Module
End Namespace
