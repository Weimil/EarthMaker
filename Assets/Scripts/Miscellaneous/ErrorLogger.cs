using System;
using UnityEngine;

namespace Miscellaneous
{
    public static class ErrorLogger
    {
        private static string _errorLog;

        public static void Error(int errorCode)
        {
            _errorLog += (ErrorCode) errorCode + "\n";
        }
    }
}