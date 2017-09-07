using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Variables

    int topBarSize = 150;

    Vector2 blockSize;
    Vector2 amountOfBlocks;

    public GameObject blockPrefab;
    GameObject[,] blockArray;

    #endregion

    void Start()
    {
        blockSize = new Vector2(30, 30);
        amountOfBlocks = new Vector2((Screen.width) / blockSize.x, (Screen.height - topBarSize) / blockSize.y);

        blockArray = new GameObject[(int)amountOfBlocks.x, (int)amountOfBlocks.y];

        GenerateBlocks();
    }

    void StartGame()
    {
        StartCoroutine("StartGameCoroutine");
    }

    void PauseGame()
    {
        Debug.Log("Pause");

        StopCoroutine("StartGameCoroutine");
    }

    void StopGame()
    {
        Debug.Log("Stop");

        StopCoroutine("StartGameCoroutine");
    }

    IEnumerator StartGameCoroutine()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            Debug.Log(i);

            yield return new WaitForSeconds(0.5f);
        }      
    }

    void GenerateBlocks()
    {
        for (int y = 15; y < Screen.height - topBarSize; y += (int)blockSize.y)
        {
            for (int x = 15; x < Screen.width; x += (int)blockSize.x)
            {
                var blockObj = Instantiate(blockPrefab, new Vector2(x, y), Quaternion.identity);

                blockObj.transform.SetParent(GameObject.Find("Blocks").transform);

            }
        }
    }
}
