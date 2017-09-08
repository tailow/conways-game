using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    #region Variables

    GameManager gameManagerScript;

    int amountOfActiveNeighbors;

    Collider2D[] allNeighborsArray = new Collider2D[9];

    #endregion

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();    
    }

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

    void GetAmountOfActiveNeighbors()
    {
        foreach (Collider2D block in allNeighborsArray)
        {
            if (block.gameObject.GetComponent<Image>().color == Color.black)
            {
                amountOfActiveNeighbors++;
            }
        }

        if (gameObject.GetComponent<Image>().color == Color.black)
        {
            amountOfActiveNeighbors--;
        }
    }

    void CheckActiveNeighbors()
    {
        allNeighborsArray = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(40, 40), 0f);

        GetAmountOfActiveNeighbors();

        if (amountOfActiveNeighbors == 3)
        {
            gameManagerScript.nextActiveBlocksList.Add(gameObject);
        }

        if (amountOfActiveNeighbors == 2 && GetComponent<Image>().color == Color.black)
        {
            gameManagerScript.nextActiveBlocksList.Add(gameObject);
        }

        amountOfActiveNeighbors = 0;
    }

    public void StartGame()
    {
        gameManagerScript.SendMessage("StartGame");
    }

    public void PauseGame()
    {
        gameManagerScript.SendMessage("PauseGame");
    }

    public void StopGame()
    {
        gameManagerScript.SendMessage("StopGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
