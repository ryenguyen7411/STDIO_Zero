using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject m_leftContainer;
	public GameObject m_rightContainer;
	public GameObject m_operator;

	private GameObject[] m_lefts;
	private GameObject[] m_rights;

	public Sprite[] m_sprSuits;
	public Sprite[] m_sprOperators;

	private int[] m_calculation;

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
		GenerateNextCalculation();
	}

	void Update()
	{

	}

	public void GenerateNextCalculation()
	{
		m_calculation[0] = Random.Range(1, 5);
		m_calculation[1] = Random.Range(1, 5);
		m_calculation[2] = Random.Range(1, 4);

		GetSuitsPosition(m_lefts, m_calculation[0]);
		GetSuitsPosition(m_rights, m_calculation[1]);

		m_operator.GetComponent<SpriteRenderer>().sprite = m_sprOperators[m_calculation[2] - 1];
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
				(m_calculation[2] == 1 && m_calculation[0] == m_calculation[1]) ||
				(m_calculation[2] == 2 && m_calculation[0] > m_calculation[1]) ||
				(m_calculation[2] == 3 && m_calculation[0] < m_calculation[1]);
	}
}
