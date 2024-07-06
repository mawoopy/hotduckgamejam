using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsBackButton : MonoBehaviour
{
    public void BackButtonCredits()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
