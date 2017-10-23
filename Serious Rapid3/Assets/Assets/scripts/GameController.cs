using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text questionText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;

	private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundAactive;
	private float timeRemaining;
	private int questionIndex;
	private int playScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		dataController = FindObjectOfType<DataController> ();
		currentRoundData = dataController.GetCurrentRoundData ();
		questionPool = currentRoundData.questions;
		timeRemaining = currentRoundData.timeLimitInSeconds;

		playScore = 0;
		questionIndex = 0;

		ShowQuestion ();
		isRoundAactive = true;
	}

	private void ShowQuestion()
	{
		RemoveAanswerButtons ();
		QuestionData questionData = questionPool [questionIndex];
		questionText.text = questionData.questionText;

		for (int i = 0; i < questionData.answers.Length; i++) 
		{
			GameObject answerButtonGameObjetc = answerButtonObjectPool.GetObject ();
			answerButtonGameObjetc.transform.SetParent (answerButtonParent);

			AnswerButton answerButton = answerButtonGameObjetc.GetComponent<AnswerButton> ();
			answerButton.Setup (questionData.answers [i]);
		}

	}

	private void RemoveAanswerButtons()
	{
		while (answerButtonGameObjects.Count > 0) 
		{
			answerButtonObjectPool.ReturnObject (answerButtonGameObjects [0]);
			answerButtonGameObjects.RemoveAt (0);
		}
			
	}


	// Update is called once per frame
	void Update () {
		
	}
}
