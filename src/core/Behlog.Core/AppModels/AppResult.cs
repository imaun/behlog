using System;

namespace Behlog.Core.AppModels {
    public class AppResult {
        
        public AppResult() { }

        public AppResult(bool success, string message) {
            Success = success;
            Message = message;
        }
        
        public string Message { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }

        public static AppResult Fail(string message = "") {
            return new AppResult(false, message);
        }

        public static AppResult Ok(string message = "") {
            return new AppResult(true, message);
        }

        public static AppResult<TValue> Fail<TValue>(TValue value, string message = "") {
            return new AppResult<TValue>(
                value, 
                false, 
                message
            );
        }

        public static AppResult<TValue> Ok<TValue>(TValue value, string message = "") {
            return new AppResult<TValue>(
                value, 
                true, 
                message
            );
        }

    }

    public class AppResult<TValue> : AppResult {

        protected internal AppResult(
            TValue value, 
            bool success, 
            string message) :base(success, message) {

            Value = value;
        } 

        public TValue Value { get; set; }
    }
}
