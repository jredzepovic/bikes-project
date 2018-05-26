using System.Collections.Generic;
using bikes_project.Models;

namespace bikes_project.Services
{
    public partial interface IEmailService
    {
        void SendAdvertAddEmail(string emailAddress, Bike model);
    }
}
