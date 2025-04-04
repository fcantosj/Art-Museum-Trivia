using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoom : MonoBehaviour
{
    [SerializeField] 
    private PlayButton playButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            playButton.ShowButton();
            Debug.Log("Entered Room");
        }
        playButton.ShowButton();
        Debug.Log("Entered Room");
    }

    private void OnTriggerExit(Collider other)
    {
        playButton.HideButton();
    }
}
