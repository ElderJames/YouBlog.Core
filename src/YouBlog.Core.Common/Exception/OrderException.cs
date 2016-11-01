using System;

namespace YouBlog.Core.Common.Exception
{
    /// <summary>
    /// 权限异常
    /// </summary>
    public class AuthorizationException : BaseException
    {
        public AuthorizationException(AuthorizationExceptionCode exceptionCode)
            : this(exceptionCode, Enum.GetName(typeof(AuthorizationExceptionCode), exceptionCode))
        {
        }


        public AuthorizationException(AuthorizationExceptionCode exceptionCode, string errorMsg)
            : base(ExceptionLevel.Normal, (int)exceptionCode, errorMsg)
        {
        }
    }
}