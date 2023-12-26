using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetFinder
{
    public static class ModLogs
    {
        private static ManualLogSource Logger { get; set; }

        public static void SetLogger(ManualLogSource logger)
        {
            Logger = logger;
        }

        public static void Assert(bool condition)
        {
            UnityEngine.Assertions.Assert.IsTrue(condition);
        }

        public static void Log(object message)
        {
            Logger.Log(LogLevel.Info, message);
        }
        public static void Error(object message)
        {
            Logger.Log(LogLevel.Error, message);
        }

        public static void Trace(object message)
        {
#if TRACE
            Logger.Log(LogLevel.Info, "PLANET_FINDER-" + message);
            //BepInEx.Logging.
#endif
        }
    }
}
