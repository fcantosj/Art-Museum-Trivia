// This script controls choosing, presenting and randomizing questions & answers

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] public List<QuestionData> questions;
    private QuestionData currentQuestion;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private AnswerButton[] answerButtons;
    [SerializeField] private QuitTrivial quitButton;
    [SerializeField] private int correctAnswerChoice;

    private void Awake()
    {
        // Get all the questions ready
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    public void setUp()
    {
        GetQuestionAssets();
        //Get a new question
        SelectNewQuestion();
        // Set all text and values on screen
        SetQuestionValues();
        // Set all of the answer buttons text and correct answer values
        SetAnswerValues();
    }

    private void GetQuestionAssets()
    {
        string path = "Questions/Meninas";
        Debug.Log("Looking for questions in: Resources/" + path);

        // Get all of the questions from the Resources/Questions/Meninas folder
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>(path));

        Debug.Log("Questions loaded: " + questions.Count);
    }

    private void SelectNewQuestion()
    {
        // Get a random value for which question to choose
        int randomQuestionIndex = Random.Range(0, questions.Count);
        //Set the question to the randon index
        currentQuestion = questions[randomQuestionIndex];
        // Remove this question from the list so it will not be repeared (until the game is restarted)
        questions.RemoveAt(randomQuestionIndex);
    }

    private void SetQuestionValues()
    {
        // Set the question text
        questionText.text = currentQuestion.question;
    }

    private void SetAnswerValues()
    {
        // Randomize the answer button order
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        // Set up the answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Create a temporary boolean to pass to the buttons
            bool isCorrect = false;

            // If it is the correct answer, set the bool to true
            if(i == correctAnswerChoice)
            {
                isCorrect = true;
            }
            showAnswers();
            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerText(answers[i]);
        }
    }

    private List<string> RandomizeAnswers(List<string> originalList)
    {
        bool correctAnswerChosen = false;

        List<string>  newList = new List<string>();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            // Get a random number of the remaining choices
            int random = Random.Range(0, originalList.Count);

            // If the random number is 0, this is the correct answer, MAKE SURE THIS IS ONLY USED ONCE
            if(random == 0 && !correctAnswerChosen)
            {
                correctAnswerChoice = i;
                correctAnswerChosen = true;
            }

            // Add this to the new list
            newList.Add(originalList[random]);
            //Remove this choice from the original list (it has been used)
            originalList.RemoveAt(random);  
        }


        return newList;
    }

    public void EndTrivia()
    {
        questionText.text = "¡Enhorabuena! ¡Has completado el trivial!";
        hideAnswers();
        quitButton.ShowButton();
        GetQuestionAssets();
    }

    public void showQuestion()
    {
        gameObject.SetActive(true);
    }

    public void hideQuestion()
    {
        gameObject.SetActive(false);
    }

    public void showAnswers()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(true);
        }
    }

    public void hideAnswers()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
    }
}
