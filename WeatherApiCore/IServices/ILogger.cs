using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WeatherApiCore.IServices
{
    public interface ILogger<T>
    {
        /// <summary>
        /// Function which write a debug line and  returns now date time 
        /// </summary>
        /// <param name="func">Caller function.</param>
        /// <param name="msg">Message which appears on trace</param>
        /// <returns>Now date time</returns>
        DateTime TraceCallIn(string func, string msg);

        /// <summary>
        /// Function which write a debug line and returns the duration call
        /// </summary>
        /// <param name="func">Caller function.</param>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="callStart">The date when the call starts</param>
        /// <returns>The duration of the call</returns>
        TimeSpan TraceCallReturnOut(string func, string msg, DateTime callStart);

        /// <summary>
        /// if it is true, the trace will be written on console, otherwise,  will be written on cache
        /// </summary>
        bool flush { get; set; }

        /// <summary>
        /// Output on debug an critical message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        void TraceCritical(string msg, [CallerMemberName] string func = "<Empty>");

        /// <summary>
        /// Output on debug an error message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        void TraceError(string msg, [CallerMemberName] string func = "<Empty>");

        /// <summary>
        /// Output on debug an error message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="ex">The occurred exception</param>
        /// <param name="func">Caller function.</param>
        void TraceError(string msg, Exception ex, [CallerMemberName] string func = "<Empty>");

        /// <summary>
        /// Output on debug an warning message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        void TraceWarning(string msg, [CallerMemberName] string func = "<Empty>");

        /// <summary>
        /// Output on debug an information message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        void TraceInfo(string msg, [CallerMemberName] string func = "<Empty>");

        /// <summary>
        /// Output on debug an error message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="args">Optional arguments.</param>
        void TraceError(string msg, params object[] args);

        /// <summary>
        /// Output on debug an error message
        /// </summary>
        /// <param name="ex">The occurred exception</param>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="args">Optional arguments.</param>
        void TraceError(Exception ex, string msg, params object[] args);

        /// <summary>
        /// Output on debug an warning message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="args">Optional arguments.</param>
        void TraceWarning(string msg, params object[] args);

        /// <summary>
        /// Output on debug an information message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="args">Optional arguments.</param>
        void TraceInfo(string msg, params object[] args);

        /// <summary>
        /// Output on debug an testing message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        void TraceTesting(string msg, [CallerMemberName] string func = "<Empty>");

        /// <summary>
        /// Force a hard-coded Assert. Throw in case of running on Debug mode.
        /// </summary>
        void Assert();

        /// <summary>
        /// Force a hard-coded Assert. Throw in case of running on Debug mode.
        /// </summary>
        /// <param name="msg">Message to display in the assertion.</param>
        void Assert(string msg);
    }
}
