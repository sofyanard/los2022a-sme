using System;

namespace Earmarking
{
	/// <summary>
	/// Summary description for NegativeLimitException.
	/// </summary>
	public class NegativeLimitException : Exception
	{
		private string _message = "";

		public NegativeLimitException(string message)
		{
			_message = message;
			//
			// TODO: Add constructor logic here
			//
		}

		public string getMessage() 
		{
			return _message;
		}
	}
}
