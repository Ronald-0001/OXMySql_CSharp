using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CitizenFX.Core;
using RedLib;
using System.Threading;

namespace Resource.Server
{
    // https://overextended.github.io/docs/oxmysql/
    public static class Oxsql
    {
        public const int Timeout = 10000;
        public static dynamic Export => ServerMain.ExportRegistry["oxmysql_csharp"];
        /// <summary>
        /// awaits oxmysql & oxmysql_csharp dependency to be initialized
        /// </summary>
        public static async Task Init()
        {
            // await oxmysql
            if (Lib.GetResourceState("oxmysql") == "missing") { Print.Warn("Resource oxmysql not found!"); }
            while (true)
            {
                await BaseScript.Delay(1000);
                if (Lib.GetResourceState("oxmysql") == "started") { break; }
                Print.Warn("Awaiting oxmysql");
            }
            // await oxmysql_csharp
            if (Lib.GetResourceState("oxmysql_csharp") == "missing") { Print.Warn("Resource oxmysql_csharp not found!"); }
            while (true)
            {
                await BaseScript.Delay(1000);
                if (Lib.GetResourceState("oxmysql_csharp") == "started") { break; }
                Print.Warn("Awaiting oxmysql_csharp");
            }
        }
        /// <summary>
        /// https://overextended.github.io/docs/oxmysql/Usage/insert
        /// </summary>
        /// <param name="query">mysql query string</param>
        /// <param name="arguments">? = arg[i]</param>
        /// <returns>Inserts a new entry into the database and returns the insert id for the row, if valid.</returns>
        public static async Task<int> Insert(string query, object arguments)
        {
            try
            {
                // handel request
                Task<object> task = Export.insert(query, arguments);
                dynamic result = await task.TimeoutAfter(Timeout);
                // handel errors
                if ((bool)result.error) { throw new Exception((string)result.msg); }
                // handel result
                return (int)result.result;
            }
            catch (Exception ex) { Print.Error($"Insert Error: {ex}"); }
            // fallback result
            return -1;
        }
        /// <summary>
        /// https://overextended.github.io/docs/oxmysql/Usage/prepare
        /// </summary>
        /// <param name="query">mysql query string</param>
        /// <param name="arguments">? = arg[i]</param>
        /// <returns>single value or IDictionary<string, object></returns>
        public static async Task<object> Prepare(string query, object arguments)
        {
            try
            {
                // handel request
                Task<object> task = Export.prepare(query, arguments);
                dynamic result = await task.TimeoutAfter(Timeout);
                // handel errors
                if ((bool)result.error) { throw new Exception((string)result.msg); }
                // handel result
                return (object)result.result;
            }
            catch (Exception ex) { Print.Error($"Prepare Error: {ex}"); }
            // fallback result
            return false;
        }
        /// <summary>
        /// https://overextended.github.io/docs/oxmysql/Usage/query
        /// </summary>
        /// <param name="query">mysql query string</param>
        /// <param name="arguments">? = arg[i]</param>
        /// <returns>single value or IDictionary<string, object></returns>
        public static async Task<object> Query(string query, object arguments)
        {
            try
            {
                // handel request
                Task<object> task = Export.query(query, arguments);
                Print.Log(task.ToString());
                dynamic result = await task.TimeoutAfter(Timeout);
                // handel errors
                if ((bool)result.error) { throw new Exception((string)result.msg); }
                // handel result
                return (object)result.result;
            }
            catch (Exception ex) { Print.Error($"Query Error: {ex}"); }
            // fallback result
            return false;
        }
        /// <summary>
        /// https://overextended.github.io/docs/oxmysql/Usage/scalar
        /// </summary>
        /// <param name="query">mysql query string</param>
        /// <param name="arguments">? = arg[i]</param>
        /// <returns>Returns the first column for a single row.</returns>
        public static async Task<object> Scalar(string query, object arguments)
        {
            try
            {
                // handel request
                Task<object> task = Export.scalar(query, arguments);
                dynamic result = await task.TimeoutAfter(Timeout);
                // handel errors
                if ((bool)result.error) { throw new Exception((string)result.msg); }
                // handel result
                return result.result;
            }
            catch (Exception ex) { Print.Error($"Scalar Error: {ex}"); }
            // fallback result
            return false;
        }
        /// <summary>
        /// https://overextended.github.io/docs/oxmysql/Usage/single
        /// </summary>
        /// <param name="query">mysql query string</param>
        /// <param name="arguments">? = arg[i]</param>
        /// <returns>Returns the columns for a single row.</returns>
        public static async Task<IDictionary<string, object>> Single(string query, object arguments)
        {
            try
            {
                // handel request
                Task<object> task = Export.single(query, arguments);
                dynamic result = await task.TimeoutAfter(Timeout);
                // handel errors
                if ((bool)result.error) { throw new Exception((string)result.msg); }
                // handel result
                return (IDictionary<string, object>)result.result;
            }
            catch (Exception ex) { Print.Error($"Single Error: {ex}"); }
            // fallback result
            return new Dictionary<string, object>();
        }
        /// <summary>
        /// A transaction executes multiple queries and commits them only if all succeed. If one fails, none of the queries are committed.
        /// https://overextended.github.io/docs/oxmysql/Usage/transaction
        /// </summary>
        /// <param name="query">mysql query string</param>
        /// <param name="arguments">? = arg[i]</param>
        /// <returns>The return value is a boolean, which is the result of the transaction.</returns>
        public static async Task<bool> Transaction(object[] queries)
        {
            try
            {
                // handel request
                Task<object> task = Export.transaction(queries);
                dynamic result = await task.TimeoutAfter(Timeout);
                // handel errors
                if ((bool)result.error) { throw new Exception((string)result.msg); }
                // handel result
                return (bool)result.result;
            }
            catch (Exception ex) { Print.Error($"Transaction Error: {ex}"); }
            // fallback result
            return false;
        }
        /// <summary>
        /// https://overextended.github.io/docs/oxmysql/Usage/update
        /// </summary>
        /// <param name="query">mysql query string</param>
        /// <param name="arguments">? = arg[i]</param>
        /// <returns>Returns the number of affected rows by the query.</returns>
        public static async Task<int> Update(string query, object arguments)
        {
            try
            {
                // handel request
                Task<object> task = Export.update(query, arguments);
                dynamic result = await task.TimeoutAfter(Timeout);
                // handel errors
                if ((bool)result.error) { throw new Exception((string)result.msg); }
                // handel result
                return (int)result.result;
            }
            catch (Exception ex) { Print.Error($"Update Error: {ex}"); }
            // fallback result
            return -1;
        }
        /// <summary>
        /// handels Task<TResult> or trows timeout exception
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="timeout">timeout in ms</param>
        /// <returns>TResult</returns>
        private static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, int timeout)
        {
            using (CancellationTokenSource timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return await task;  // Very important in order to propagate exceptions
                }
                else
                { throw new TimeoutException("The operation has timed out."); }
            }
        }
    }
    public struct Blob
    {
        private readonly string value;
        private Blob(string value)
        { this.value = value; }
        public static Blob Convert(object value)
        {
            try
            {
                if (!(value is List<object> _list)) { throw new InvalidCastException($"Blob: {value.GetType().Name} !is List<object>"); }
                if (_list.Count == 0) { throw new InvalidCastException("Blob: List<object>.Count == 0"); }
                if (!(_list[0] is int)) { throw new InvalidCastException($"Blob: {_list[0].GetType().Name} ! is List<int>"); }
                byte[] blob = _list.Select(x => (byte)(int)x).ToArray();
                return new Blob(Encoding.UTF8.GetString(blob));
            }
            catch (Exception ex) { Print.Error($"Blob Error: {ex}"); }
            return new Blob("");
        }
        public static implicit operator string(Blob blob)
        { return blob.value; }
        public override string ToString()
        { return value; }
    }
    public struct TimeStamp
    {
        private readonly double value;
        private TimeStamp(double value)
        { this.value = value; }
        public static TimeStamp Convert(object value)
        {
            try
            {
                if (!(value is double timestamp)) { throw new InvalidCastException($"TimeStamp: {value.GetType().Name} !is double"); }
                return new TimeStamp(timestamp);
            }
            catch (Exception ex) { Print.Error($"TimeStamp Error: {ex}"); }
            return new TimeStamp(0);
        }
        public static implicit operator double(TimeStamp timestamp)
        { return timestamp.value; }
        public static implicit operator string(TimeStamp timestamp)
        { return timestamp.value.ToString(); }
        public override string ToString()
        { return value.ToString(); }

    }
}