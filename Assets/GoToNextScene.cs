using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(name);
	}
	public void Exit()
	{
		Application.Quit();
	}

}
