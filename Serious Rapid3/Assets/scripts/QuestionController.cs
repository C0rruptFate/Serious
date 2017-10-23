using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuestionController : MonoBehaviour {

	public void StartQuestion()
	{
		SceneManager.LoadScene("Game");
	}
}