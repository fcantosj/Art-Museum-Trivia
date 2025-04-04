// This script is for the buttons the answers will go on

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private QuestionSetup questionSetup;

    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public async void OnClick()
    {
        HideButton();
        await AiQuestion.GetQuestionsAsync(); // Await the async version of GetQuestions
        await JSONtoSO.GeneratePhrasesAsync(); // Await the async version of GeneratePhrases
        questionSetup.setUp();
        questionSetup.showQuestion();
        questionSetup.showAnswers();
    }

    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }
}
