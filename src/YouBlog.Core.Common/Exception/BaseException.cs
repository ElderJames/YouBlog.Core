namespace YouBlog.Core.Common.Exception
{
    public class BaseException :System.Exception
	{
		public BaseException (ExceptionLevel level, int exceptionCode)
			: base ()
		{
            _errorCode = exceptionCode;
            _level = level;
		}

		public BaseException (ExceptionLevel level, int exceptionCode, string errorMsg)
			: base (errorMsg)
		{
            _errorCode = exceptionCode;
            _level = level;
            _message = errorMsg;
		}

		string _message = null;

		public override string Message {
			get {
				if (string.IsNullOrEmpty (_message)) {
					return base.Message;
				}
				return _message;
			}
		}

		ExceptionLevel _level = ExceptionLevel.Normal;

		public ExceptionLevel Level {
			get {
				return _level;
			}
		}

		int _errorCode = 0;

		public int ErrorCode {
			get {
				return _errorCode;
			}
		}
	}
}

