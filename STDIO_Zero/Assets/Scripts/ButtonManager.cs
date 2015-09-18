using UnityEngine;
using Stdio;

public class ButtonManager : MonoBehaviour
{
	public void CheckAnswer()
	{
		GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		if(manager.m_gameState == GameState.PLAYING)
		{
			if(gameObject.name == "BtnRight")
			{
				if (manager.IsRightAnswer())
					manager.GenerateNextCalculation();
				else
				{
					Static.S_Debug("You're wrong!");
					manager.ShowGameOverPopup();
				}
			}
			else
			{
				if (!manager.IsRightAnswer())
					manager.GenerateNextCalculation();
				else
				{
					Static.S_Debug("You're wrong!");
					manager.ShowGameOverPopup();
				}
			}
		}
	}

	public void ChangeToMenuScene()
	{
		Application.LoadLevel("MenuScene");
	}

	public void ChangeToGameScene()
	{
		Application.LoadLevel("GameScene");
	}
}