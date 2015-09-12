﻿using UnityEngine;
using Stdio;

public class ButtonManager : MonoBehaviour
{
	public void CheckAnswer()
	{
		GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		if(gameObject.name == "BtnRight")
		{
			if (manager.IsRightAnswer())
				manager.GenerateNextCalculation();
			else
				Static.S_Debug("You're wrong!");
		}
		else
		{
			if (!manager.IsRightAnswer())
				manager.GenerateNextCalculation();
			else
				Static.S_Debug("You're wrong!");
		}
	}
}