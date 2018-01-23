using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.IServices;

namespace WeatherApiCore.Services
{
    /// <summary>
    /// Class which manages all the debug out put
    /// </summary>
    /// <typeparam name="T">Object derive type</typeparam>
    public class Logger<T> : ILogger<T>
    {
        private static DateTime StartingTime = DateTime.UtcNow; //Help message from the start of the service.

#if DEBUG
        private static bool autoflush = true;
#else
        private static bool autoflush = false;
#endif 

        const string EMPTY_FUNC = "<EmptyFunc>";
        string TAG = "<EmptyTag>";

        /// <summary>
        /// Constructor
        /// </summary>
        public Logger()
        {
            TAG = typeof(T).Name;
            flush = false;
        }

        /// <summary>
        /// if it is true, the trace will be written on console, otherwise,  will be written on cache
        /// </summary>
        public bool flush { get; set; }

        //Traces calls out/in
        /// <summary>
        /// Function which write a debug line and  returns now date time 
        /// </summary>
        /// <param name="func">Caller function.</param>
        /// <param name="msg">Message which appears on trace</param>
        /// <returns>Now date time</returns>
        public DateTime TraceCallIn(string func, string msg)
        {
            string rStr = DbgHelperGetFormatedString(">>>", func, msg, DateTime.MinValue);

            //log to output
            //return DateTime.UtcNow;
            return DbgHelperTraceCallIn(rStr, false);
        }

        /// <summary>
        /// Function which write a debug line and returns the duration call
        /// </summary>
        /// <param name="func">Caller function.</param>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="callStart">The date when the call starts</param>
        /// <returns>The duration of the call</returns>
        public TimeSpan TraceCallReturnOut(string func, string msg, DateTime callStart)
        {
            string rStr = DbgHelperGetFormatedString("<<<", func, msg, callStart);

            return DbgHelperTraceCallReturnOut(msg, callStart, false);
        }

        //Critical
        /// <summary>
        /// Function which traces on debug an critical message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        public void TraceCritical(string msg, string func = "<Empty>")
        {
            var str = string.Format("{0} ###", TAG);

            //msg = "[CRITICAL] " + msg;

            str = DbgHelperGetFormatedString(str, func, msg, DateTime.MinValue);

            DbgHelperTraceError(str, flush);
        }

        //Error
        /// <summary>
        /// Function which traces on debug an error message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        public void TraceError(string msg, string func)
        {
            var str = string.Format("{0} XXX", TAG);

            //msg = "[ERROR] " + msg;

            str = DbgHelperGetFormatedString(str, func, msg, DateTime.MinValue);

            DbgHelperTraceError(str, flush);
        }

        /// <summary>
        /// Function which traces on debug an error message
        /// </summary>
        /// <param name="format">Message format</param>
        /// <param name="args">Parameters with data</param>
        public void TraceError(string format, params object[] args)
        {
            var str = string.Format(format, args);
            TraceError(str, EMPTY_FUNC);
        }

        /// <summary>
        /// Function which traces on debug an error message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="ex">The occurred exception</param>
        /// <param name="func">Caller function.</param>
        public void TraceError(string msg, Exception ex, string func)
        {
            string str;

            if (ex == null)
                str = string.Format("{0}.", msg);
            else
                str = string.Format("{0}. {1}\n {2}", msg, ex.Message, ex.ToString());

            TraceError(str, func);
        }

        /// <summary>
        /// Function which traces on debug an error message
        /// </summary>
        /// <param name="ex">The occurred exception</param>
        /// <param name="format">Message format</param>
        /// <param name="args">Optional parameters.</param>
        public void TraceError(Exception ex, string format, params object[] args)
        {
            var str = string.Format(format, args);
            TraceError(str, ex, EMPTY_FUNC);
        }

        //Info

        /// <summary>
        /// Function which traces on debug an information message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        public void TraceInfo(string msg, string func)
        {
            var str = string.Format("{0} |||", TAG);

            str = DbgHelperGetFormatedString(str, func, msg, DateTime.MinValue);

            DbgHelperTraceInfo(str, flush);
        }

        /// <summary>
        /// Function which traces on debug an information message
        /// </summary>
        /// <param name="format">Message format</param>
        /// <param name="args">Optional parameters.</param>
        public void TraceInfo(string format, params object[] args)
        {
            var str = string.Format(format, args);
            TraceInfo(str, EMPTY_FUNC);
        }

        /// <summary>
        /// Function which traces on debug an information message
        /// </summary>
        /// <param name="str">Message which appears on trace</param>
        public void TraceInfo(string str)
        {
            TraceInfo(str, EMPTY_FUNC);
        }

        //Warning
        /// <summary>
        /// Output on debug an warning message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        public void TraceWarning(string msg, string func)
        {
            var str = string.Format("{0} ///", TAG);

            //msg = "[WARNING] " + msg;

            str = DbgHelperGetFormatedString(str, func, msg, DateTime.MinValue);


            DbgHelperTraceWarning(str, flush);
        }

        /// <summary>
        /// Output on debug an warning message
        /// </summary>
        /// <param name="format">The format will be apply</param>
        /// <param name="args">Optional parameters.</param>
        public void TraceWarning(string format, params object[] args)
        {
            var str = string.Format(format, args);
            TraceWarning(str, EMPTY_FUNC);
        }

        //Assert

        /// <summary>
        /// Testing function
        /// </summary>
        public void Assert()
        {
            Assert(false, string.Empty);
        }

        /// <summary>
        /// Testing function
        /// </summary>
        /// <param name="msg">String message which will be tested</param>
        public void Assert(string msg)
        {
            Assert(false, msg);
        }

        /// <summary>
        /// Testing function
        /// </summary>
        /// <param name="cond">Testing condition</param>
        /// <param name="msg">String message which will be tested.</param>
        public void Assert(bool cond, string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
                Debug.Assert(cond);
            else
                Debug.Assert(cond, msg);
        }

        //Testing
        /// <summary>
        /// Output on debug an testing message
        /// </summary>
        /// <param name="msg">Message which appears on trace</param>
        /// <param name="func">Caller function.</param>
        public void TraceTesting(string msg, string func)
        {
            TraceInfo(msg, EMPTY_FUNC);
        }

        //Privates
        private string DbgHelperGetFormatedString(string tag, string func, string msg, DateTime RefTime)
        {
            DateTime dt = DateTime.UtcNow;
            string strDt = dt.TimeOfDay.ToString();
            string strDelta = RefTime == DateTime.MinValue ? "00:00:00.0000000" : (dt - RefTime).Duration().ToString();
            string deltaFromStart = (dt - StartingTime).Duration().ToString();

            string rStr = String.Format("{0} | {1} | {2} | {3} | {4} | {5}",
                dt.TimeOfDay,
                deltaFromStart,
                strDelta,
                tag,
                func,
                msg);

            return rStr;
        }
        /// <summary>
        /// Traces the start of a call
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="bFlush"></param>
        /// <returns></returns>
        private DateTime DbgHelperTraceCallIn(string msg, bool bFlush)
        {
            DateTime dt = DateTime.UtcNow;

            //string rStr = String.Format(">>> {0} | {1} | {2} ", dt.TimeOfDay, func, msg);
            //string rStr = GetFormatedString(">>>", func, msg, DateTime.MinValue);

            DbgHelperTraceInfo(msg, bFlush);

            DebugOutput(msg);

            return dt;
        }
        /// <summary>
        /// Trace return calls
        /// </summary>
        /// <param name="msg">Text to trace. </param>
        /// <param name="bFlush"></param>
        /// <remarks>Suggest to specify the same msg as teh call to <ref>TraceCallOut</ref> to allow an easy matching between them.</remarks>
        /// <param name="callStart">Points when the call was done to show on the trace the duration of the call.</param>
        /// <returns>The duration of the call based on the <ref>callStart</ref> parameter</returns>
        private TimeSpan DbgHelperTraceCallReturnOut(string msg, DateTime callStart, bool bFlush)
        {
            //string rStr = String.Format("<<< {0} | {1} | {2} | {3} ", dt.TimeOfDay, delta.Duration() , func, msg);
            //String rStr = GetFormatedString("<<<", func, msg, callStart);

            DbgHelperTraceInfo(msg, bFlush);

            DebugOutput(msg);

            DateTime dt = DateTime.UtcNow;
            TimeSpan delta = dt - callStart;

            return delta;
        }
        private void DbgHelperTraceInfo(string msg, bool bFlush)
        {
            //var str = GetFormatedString("|||", "<Empty>", msg, DateTime.MinValue);

            Trace.TraceInformation(msg);

            CheckFlush(bFlush);

            DebugOutput(msg);
        }
        private void DbgHelperTraceWarning(string msg, bool bFlush)
        {
            //var str = GetFormatedString("|||", "<Empty>", msg, DateTime.MinValue);

            Trace.TraceWarning(msg);
            CheckFlush(bFlush);

            DebugOutput(msg);
        }
        private void DbgHelperTraceError(string msg, bool bFlush)
        {
            //var str = GetFormatedString("|||", "<Empty>", msg, DateTime.MinValue);

            Trace.TraceError(msg);

            CheckFlush(bFlush);

            DebugOutput(msg);
        }
        private void CheckFlush(bool bFlush)
        {
            if (Trace.AutoFlush == true)
                return;

            if (autoflush || bFlush)
                Trace.Flush();
        }
        private void DebugOutput(string msg)
        {
            //Debug.WriteLine(msg);
        }
    }
}
