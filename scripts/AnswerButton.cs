// This script is for the buttons the answers will go on

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;

    // To make it ask a new question after the first question
    [SerializeField] private QuestionSetup questionSetup;

    public void ShowQuiz()
    {
        showAnswers();
    }

    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if(isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
            // Get the next question if there are more in the list
            if (questionSetup.questions.Count > 0)
            {
                // Generate a new question
                questionSetup.setUp();
            }
            else
            {
                // If there are no more questions, end the game
                Debug.Log("No more questions");
                questionSetup.EndTrivia();
            }
        }
        else
        {
            Debug.Log("WRONG ANSWER");
            gameObject.SetActive(false);
        }
        
    }

    public void showAnswers()
    {
        gameObject.SetActive(true);
    }
}
