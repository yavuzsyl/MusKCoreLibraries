using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireExample.BackgroundJobs
{
    public class ContinuationsJobs
    {
        public static void WriteWaterMarkStatusJob(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{fileName}:watermark added"));

        }
    }
}
