using UnityEngine;

namespace Stdio
{
	static class Static
	{
		public static void S_Debug(object message)
		{
			if (Debug.isDebugBuild)
				Debug.Log(message);
		}

		public static int s_score;
	}

	public enum GameState
	{
		PLAYING,
		FAILED
	}
}