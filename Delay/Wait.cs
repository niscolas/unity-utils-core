using System;
using System.Threading.Tasks;

namespace UnityUtils
{
	public static class Wait
	{
		public static Task Seconds(float seconds)
		{
			return Task.Delay(TimeSpan.FromSeconds(seconds));
		}
	}
}