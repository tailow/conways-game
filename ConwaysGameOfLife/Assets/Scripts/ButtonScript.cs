using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

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
        allNeighborsArray = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(gameManagerScript.blockSize.x * 1.1f, gameManagerScript.blockSize.y * 1.1f), 0f);

        GetAmountOfActiveNeighbors();

        if ((amountOfActiveNeighbors == gameManagerScript.amountToSpawn) && GetComponent<Image>().color == Color.white)
        {
            gameManagerScript.nextActiveBlocksList.Add(gameObject);
        }

        if ((amountOfActiveNeighbors <= gameManagerScript.maxNeighbors && amountOfActiveNeighbors >= gameManagerScript.minNeighbors) && GetComponent<Image>().color == Color.black)
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
