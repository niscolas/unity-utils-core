using UnityEngine;

namespace UnityUtils
{
	public static class Logger
	{
		public static void WarnIsMissing(string whoIsMissing, string whatIsMissing)
		{
			string message = $"{whoIsMissing} is missing {whatIsMissing}";
			Debug.LogWarning(message);
		}
	}
}