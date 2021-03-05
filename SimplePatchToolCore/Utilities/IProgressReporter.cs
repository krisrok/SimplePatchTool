using FastRsync.Diagnostics;
using System;

namespace SimplePatchToolCore
{
    internal interface IProgressReporter : IProgress<ProgressReport>
    {
    }
}