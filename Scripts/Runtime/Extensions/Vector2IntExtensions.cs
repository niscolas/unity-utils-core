using UnityEngine;

namespace niscolas.UnityExtensions
{
	public static class Vector2IntExtensions
	{
		public static int Random(this Vector2Int self)
		{
			if (self.x == self.y)
			{
				return self.x;
			}
			
			return UnityEngine.Random.Range(self.x, self.y + 1);
		}
	}
}