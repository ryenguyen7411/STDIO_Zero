using UnityEngine;
using System.Collections;

public class EffectsController : MonoBehaviour
{
	private float m_lastTime;
	private float m_flashTime;

	void Start()
	{
		m_flashTime = 0.1f;
	}

	void Update()
	{
		m_lastTime += Time.deltaTime;
	}

	public void DoRotateEffect(GameObject suit)
	{
		Vector3 newAngle = suit.transform.eulerAngles;
		newAngle.z += 5.0f;
		suit.transform.eulerAngles = newAngle;
	}

	public void DoFlashEffect(GameObject suit)
	{
		if (m_lastTime >= m_flashTime)
		{
			if (!suit.activeInHierarchy)
				suit.SetActive (true);
			else
				suit.SetActive (false);

			m_lastTime = 0;
		}
	}
}