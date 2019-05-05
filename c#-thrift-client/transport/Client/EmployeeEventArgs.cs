using System;

namespace Client
{
    public enum EmployeeEvent
    {
        BookingAdded
    }

    public class EmployeeEventArgs : EventArgs
    {
        public EmployeeEvent EmployeeEvent { get; }
        public object Data { get; }

        public EmployeeEventArgs(object data, EmployeeEvent employeeEvent)
        {
            EmployeeEvent = employeeEvent;
            Data = data;
        }
    }
}
