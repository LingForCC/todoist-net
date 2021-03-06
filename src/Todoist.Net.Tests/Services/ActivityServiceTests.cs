﻿using System.Linq;

using Todoist.Net.Models;
using Todoist.Net.Tests.Extensions;
using Todoist.Net.Tests.Settings;

using Xunit;

namespace Todoist.Net.Tests.Services
{
    [IntegrationPremium]
    public class ActivityServiceTests
    {
        [Fact]
        public void GetActivity_HasEntries()
        {
            var client = new TodoistClient(SettingsProvider.GetToken());

            var logEntries = client.Activity.GetAsync().Result;

            Assert.True(logEntries.Any());
        }

        [Fact]
        public void GetActivityWithEventObjectFilter_HasEntries()
        {
            var client = new TodoistClient(SettingsProvider.GetToken());

            var logFilter = new LogFilter();
            logFilter.ObjectEventTypes.Add(new ObjectEventTypes() { ObjectType = "project" });
             
            var logEntries = client.Activity.GetAsync(logFilter).Result;

            Assert.True(logEntries.Any());
        }
    }
}
