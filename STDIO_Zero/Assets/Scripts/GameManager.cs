using UnityEngine;
using Stdio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public	GameObject		m_leftContainer;
	public	GameObject		m_rightContainer;
	public	GameObject		m_operator;

	private GameObject[]	m_lefts;
	private GameObject[]	m_rights;

	public	Sprite[]		m_sprSuits;
	public	Sprite[]		m_sprOperators;

	private int[]			m_calculation;

	public	Text			m_scoreText;

	private float			m_currentTime;
	private float			m_levelTime;
	public	Image			m_progressTimer;

	public	GameState		m_gameState;

	/* Initialize */
	void Start()
	{
		m_lefts = new GameObject[4];
		m_rights = new GameObject[4];

		for(int i = 0; i < 4; i++)
		{
			m_lefts[i] = m_leftContainer.transform.GetChild(i).gameObject;
			m_rights[i] = m_rightContainer.transform.GetChild(i).gameObject;
		}

		m_calculation = new int[3];

		m_levelTime = 1.5f;
		m_currentTime = 0f;

		m_gameState = GameState.PLAYING;

		Static.s_score = -1;
		GenerateNextCalculation();
	}

	/* Update */
	void Update()
	{
		switch(m_gameState)
		{
			case GameState.PLAYING:
				m_currentTime += Time.deltaTime;
				if (m_currentTime >= m_levelTime)
					m_currentTime = 0f;

				m_progressTimer.fillAmount = m_currentTime / m_levelTime;

#if UNITY_EDITOR
				{
					if (Input.GetKeyDown(KeyCode.LeftArrow))
					{
						if (IsRightAnswer())
							GenerateNextCalculation();
						else
						{
							Static.S_Debug("You're wrong!");
							m_gameState = GameState.FAILED;
						}
					}
					else if (Input.GetKeyDown(KeyCode.RightArrow))
					{
						if (!IsRightAnswer())
							GenerateNextCalculation();
						else
						{
							Static.S_Debug("You're wrong!");
							m_gameState = GameState.FAILED;
						}
					}
				}
#endif
				break;

			case GameState.FAILED:
				if (Input.GetKeyDown(KeyCode.Space))
					m_gameState = GameState.PLAYING;
				break;
		}
		
	}

	public void GenerateNextCalculation()
	{
		m_calculation[0] = Random.Range(1, 5);
		m_calculation[1] = Random.Range(1, 5);
		m_calculation[2] = Random.Range(0, 3);

		GetSuitsPosition(m_lefts, m_calculation[0]);
		GetSuitsPosition(m_rights, m_calculation[1]);

		m_operator.GetComponent<SpriteRenderer>().sprite = m_sprOperators[m_calculation[2]];

		Static.s_score++;
		m_scoreText.text = Static.s_score.ToString();

		m_currentTime = 0f;
	}

	internal void GetSuitsPosition(GameObject[] _suits, int _count)
	{
		switch (_count)
		{
			case 1:
				_suits[0].SetActive(true);
				_suits[1].SetActive(false);
				_suits[2].SetActive(false);
				_suits[3].SetActive(false);

				_suits[0].transform.localPosition = Vector3.zero;
				_suits[0].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				break;
			case 2:
				_suits[0].SetActive(true);
				_suits[1].SetActive(true);
				_suits[2].SetActive(false);
				_suits[3].SetActive(false);

				_suits[0].transform.localPosition = new Vector3(-0.6f, 0, 0);
				_suits[0].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				_suits[1].transform.localPosition = new Vector3(0.6f, 0, 0);
				_suits[1].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				break;
			case 3:
				_suits[0].SetActive(true);
				_suits[1].SetActive(true);
				_suits[2].SetActive(true);
				_suits[3].SetActive(false);

				_suits[0].transform.localPosition = new Vector3(-0.6f, -0.5f, 0);
				_suits[0].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				_suits[1].transform.localPosition = new Vector3(0.6f, -0.5f, 0);
				_suits[1].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				_suits[2].transform.localPosition = new Vector3(0, 0.5f, 0);
				_suits[2].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				break;
			case 4:
				_suits[0].SetActive(true);
				_suits[1].SetActive(true);
				_suits[2].SetActive(true);
				_suits[3].SetActive(true);

				_suits[0].transform.localPosition = new Vector3(-0.6f, 0, 0);
				_suits[0].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				_suits[1].transform.localPosition = new Vector3(0.6f, 0, 0);
				_suits[1].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				_suits[2].transform.localPosition = new Vector3(0, 1.0f, 0);
				_suits[2].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				_suits[3].transform.localPosition = new Vector3(0, -1.0f, 0);
				_suits[3].GetComponent<SpriteRenderer>().sprite = m_sprSuits[Random.Range(0, 4)];

				break;
		}
	}

	public bool IsRightAnswer()
	{
		return
				(m_calculation[2] == 0 && m_calculation[0] == m_calculation[1]) ||
				(m_calculation[2] == 1 && m_calculation[0] > m_calculation[1]) ||
				(m_calculation[2] == 2 && m_calculation[0] < m_calculation[1]);
	}
}
