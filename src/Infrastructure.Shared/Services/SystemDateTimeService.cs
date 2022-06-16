using MVWorkflows.Application.Interfaces.Services;
using System;

namespace MVWorkflows.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}