﻿using Common.Logging;
using OpenCBS.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.SchedulerService.Jobs
{
    public class InitializationJob : IJob
    {
        private ILog Log = LogManager.GetLogger("MP_WS_info");

        private static IServices ServiceProvider
        {
            get { return ServicesProvider.GetInstance(); }
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Log.Debug("");
                Log.Debug("Starting initialization job");
                var generalSettingsService = ServiceProvider.GetApplicationSettingsServices();
                generalSettingsService.FillGeneralDatabaseParameter();
                Log.Debug("Initialization job complete");
            }
            catch (Exception exc)
            {
                Log.Error(exc);
            }

        }
    }
}
