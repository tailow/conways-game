using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    #region Variables

    public GameObject gameManager;

    #endregion

    public void ToggleButtonColor()
    {
        Color currentColor = GetComponent<Image>().color;

        if (currentColor == Color.white)
        {
            GetComponent<Image>().color = Color.black;
        }

        else if (currentColor == Color.black)
        {
            GetComponent<Image>().color = Color.white;
        }

        else
        {
            Debug.Log("Failed to check for current color.");
        }
    }

    public void StartGame()
    {
        gameManager.SendMessage("StartGame");
    }

    public void PauseGame()
    {
        gameManager.SendMessage("PauseGame");
    }

    public void StopGame()
    {
        gameManager.SendMessage("StopGame");
    }
}
