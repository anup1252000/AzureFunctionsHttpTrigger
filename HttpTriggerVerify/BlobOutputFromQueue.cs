using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;

namespace HttpTriggerVerify
{
    public class BlobOutputFromQueue
    {
        [FunctionName("QueueTrigger")]
        public void QueueTriggerAndBlobOutput(
            [QueueTrigger("order", Connection = "AzureWebJobsStorage")] Employee employee,
            [Blob("employee/{rand-guid}.json")] TextWriter textWriter)
        {
            textWriter.WriteLine($"id:{employee.Id}");
            textWriter.WriteLine($"Name:{employee.Name}");
            textWriter.WriteLine($"Age:{employee.Age}");
            textWriter.WriteLine($"City:{employee.City}");
            textWriter.WriteLine($"State:{employee.State}");
        }
    }
}
