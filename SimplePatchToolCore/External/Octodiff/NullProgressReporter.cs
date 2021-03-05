using FastRsync.Diagnostics;
using System;

namespace SimplePatchToolCore
{
    public class NullProgressReporter : IProgressReporter
    {
        public void Report(ProgressReport value)
        {
        }
    }
}