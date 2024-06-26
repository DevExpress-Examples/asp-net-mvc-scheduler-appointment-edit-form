<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128553412/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4676)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Scheduler for ASP.NET MVC - A simple implementation of an appointment edit form

This example illustrates a simple implementation of a custom appointment edit form. You can find the form view in the following file: [CustomAppointmentFormPartial.cshtml](./CS/Views/Home/CustomAppointmentFormPartial.cshtml).

## Implementation Details

The following list covers important aspects of example implementation:

1. The example implements the `SchedulerHelper` class that initializes Scheduler settings for its view.
2. Pass the Scheduler settings to the corresponding overloads of [SchedulerExtension.GetAppointmentsToInsert<T>](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToInsert.overloads), [SchedulerExtension.GetAppointmentsToUpdate<T>](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToUpdate.overloads), and [SchedulerExtension.GetAppointmentsToRemove<T>](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToRemove.overloads) methods.
3. The [Scheduler](https://docs.devexpress.com/AspNetMvc/11431/components/scheduler) extension should be defined in a separate Partial View ([SchedulerPartial.cshtml](./CS/Views/Home/SchedulerPartial.cshtml)).

## Files to Review

* [SchedulerHelper.cs](./CS/Code/SchedulerHelper.cs) (VB: [SchedulerHelper.vb](./VB/Code/SchedulerHelper.vb))
* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [SchedulerPartial.cshtml](./CS/Views/Home/SchedulerPartial.cshtml)
* [CustomAppointmentFormPartial.cshtml](./CS/Views/Home/CustomAppointmentFormPartial.cshtml)

## Documentation

* [Use Scheduler in Complex Views](https://docs.devexpress.com/AspNetMvc/11629/components/scheduler/get-started/lesson-3-use-scheduler-in-complex-views)
* [Callback-Based Functionality](https://docs.devexpress.com/AspNetMvc/9052/common-features/callback-based-functionality)

## More Examples

* [How to implement a custom edit appointment form](https://github.com/DevExpress-Examples/asp-net-mvc-scheduler-custom-appointment-form)

## Online Demo

* [Scheduling - Custom Forms](https://demos.devexpress.com/MVCxSchedulerDemos/Customization/CustomForms)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-scheduler-appointment-edit-form&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-scheduler-appointment-edit-form&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
