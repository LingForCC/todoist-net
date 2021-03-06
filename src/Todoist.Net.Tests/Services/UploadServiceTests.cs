﻿using System;
using System.Linq;
using System.Text;

using Todoist.Net.Tests.Settings;

using Xunit;

namespace Todoist.Net.Tests.Services
{
    public class UploadServiceTests
    {
        [Fact]
        public void CreateGetDeleteAsync_Success()
        {
            var client = new TodoistClient(SettingsProvider.GetToken());

            var fileName = $"{Guid.NewGuid().ToString()}.txt";
            var upload = client.Uploads.UploadAsync(fileName, Encoding.UTF8.GetBytes("hello")).Result;

            var allUploads = client.Uploads.GetAsync().Result;
            Assert.True(allUploads.Any(u => u.FileUrl == upload.FileUrl));

            client.Uploads.DeleteAsync(upload.FileUrl).Wait();

            allUploads = client.Uploads.GetAsync().Result;
            Assert.True(allUploads.All(u => u.FileUrl != upload.FileUrl));
        }
    }
}
