using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject HideThebuttons;
    public GameObject HideThebuttons1;
    public GameObject HideThebuttons2;
    public GameObject HideThebuttons4;
    public GameObject HideText;
    public void playGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void quitgame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        HideThebuttons.SetActive(false);
        HideThebuttons1.SetActive(false);
        HideThebuttons2.SetActive(false);
        HideThebuttons4.SetActive(false);
        HideText.SetActive(false);
        HideThebuttons.SetActive(true);
    }
    public void MainMenu()
    {

        HideThebuttons.SetActive(false);
        HideThebuttons1.SetActive(true);
        HideThebuttons2.SetActive(true);
        HideThebuttons4.SetActive(true);
        HideText.SetActive(true);
        HideThebuttons.SetActive(false);
    }
}
