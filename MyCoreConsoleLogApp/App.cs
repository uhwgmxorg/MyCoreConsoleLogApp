using NLog;
using System;

namespace MyCoreConsoleLogApp
{
    /// <summary>
    /// Class App
    /// </summary>
    public class App
    {
        private String _debugRelease;
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private int _to = 100;

        public String Version { get; set; } = "0.0.0.0";

        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            // Set the config of the Logger
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "NLog.config" };

#if DEBUG
            _debugRelease = "Debug";
#else
            _debugRelease = "Release";
#endif

            _logger.Info(String.Format("START Program {0}", typeof(Program).Assembly.GetName().Name));
            _logger.Info(String.Format("Program MyCoreConsoleLogApp {0} Version {1}", _debugRelease, Version));
        }

        /// <summary>
        /// Run
        /// Run the program
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Run(string[] args)
        {
            Console.WriteLine(String.Format("Program MyCoreConsoleLogApp {0} Version {1}", _debugRelease, Version));

            #region LogFile Stress Test
            _logger.Fatal(String.Format("Writing with Trace"));
            for (int i = 1; i <= _to; i++)
            {
                Console.Write(String.Format("Trace i={0} ", i));
                _logger.Trace(String.Format("Trace {0}", i));
            }
            Console.Write(String.Format("\n"));

            _logger.Fatal(String.Format("Writing with Debug"));
            for (int j = 1; j <= _to; j++)
            {
                Console.Write(String.Format("Debug j={0} ", j));
                _logger.Debug(String.Format("Debug {0}", j));
            }
            Console.Write(String.Format("\n"));

            _logger.Fatal(String.Format("Writing with Info"));
            for (int k = 1; k <= _to; k++)
            {
                Console.Write(String.Format("Info k={0} ", k));
                _logger.Info(String.Format("Info {0}", k));
            }
            Console.Write(String.Format("\n"));

            _logger.Fatal(String.Format("Writing with Warn"));
            for (int l = 1; l <= _to; l++)
            {
                Console.Write(String.Format("Warn l={0} ", l));
                _logger.Warn(String.Format("Warn {0}", l));
            }
            Console.Write(String.Format("\n"));

            _logger.Fatal(String.Format("Writing with Error"));
            for (int m = 1; m <= _to; m++)
            {
                Console.Write(String.Format("Error m={0} ", m));
                _logger.Error(String.Format("Error {0}", m));
            }
            Console.Write(String.Format("\n"));

            _logger.Fatal(String.Format("Writing with Fatal"));
            for (int n = 1; n <= _to; n++)
            {
                Console.Write(String.Format("Fatal n={0} ", n));
                _logger.Fatal(String.Format("Fatal {0}", n));
            }
            Console.Write(String.Format("\n"));
            #endregion

            Console.WriteLine(String.Format("press any key to exit."));
            Console.ReadKey();
            _logger.Info(String.Format("TERMINATE Program {0}", typeof(Program).Assembly.GetName().Name));
            return 0;
        }
    }
}
