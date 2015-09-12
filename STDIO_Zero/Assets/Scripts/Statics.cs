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
	}
	
	public enum Effect
	{
		EFFECT_FLASH,
		EFFECT_ROTATE,
		EFFECT_NONE
	}
}