using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTrivial : MonoBehaviour
{
    [SerializeField] private QuestionSetup questionSetup;
    [SerializeField] private PlayButton playButton;

    public void Awake()
    {
        HideButton();
    }

    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        questionSetup.hideQuestion();
        questionSetup.hideAnswers();
        HideButton();
        playButton.ShowButton();
    }
}
