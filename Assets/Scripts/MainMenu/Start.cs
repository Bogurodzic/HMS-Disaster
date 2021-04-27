using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void OnStartClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnInstructionsClicked()
    {
        SceneManager.LoadScene("Instruction");
    }
}
