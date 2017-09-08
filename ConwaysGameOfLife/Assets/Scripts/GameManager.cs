using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Variables

    int topBarSize = 150;

    Vector2 blockSize;
    Vector2 amountOfBlocks;

    public GameObject blockPrefab;

    GameObject[,] blockArray;

    List<Vector2> activeBlocksList = new List<Vector2>();

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

    void CheckAllActiveBlocks()
    {
        activeBlocksList.Clear();

        for (int y = 0; y < amountOfBlocks.y; y++)
        {
            for (int x = 0; x < amountOfBlocks.x; x++)
            {
                if (blockArray[x, y].GetComponent<Image>().color == Color.black)
                {
                    activeBlocksList.Add(new Vector2(x, y));
                }
            }
        }
    }

    void CheckAllNeighbors()
    {
        foreach (Vector2 block in activeBlocksList)
        {
            CheckAmountOfActiveNeighbors(block);

            // Decide what happens to this block
        }
    }

    
    int CheckAmountOfActiveNeighbors(Vector2 currentPos)
    {
        int amount = 0;

        // Check all neighbors
        // Decide what happens to them

        return amount;
    }
    

    IEnumerator StartGameCoroutine()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            //CheckAllActiveBlocks();

            //CheckAllNeighbors();

            yield return new WaitForSeconds(0.5f);
        }      
    }

    void GenerateBlocks()
    {
        int blockNumberX = 0;
        int blockNumberY = 0;

        for (int y = 15; y < Screen.height - topBarSize; y += (int)blockSize.y)
        {     
            for (int x = 15; x < Screen.width; x += (int)blockSize.x)
            {
                var blockObj = Instantiate(blockPrefab, new Vector2(x, y), Quaternion.identity);

                blockObj.transform.SetParent(GameObject.Find("Blocks").transform);
                blockArray[blockNumberX, blockNumberY] = blockObj;

                blockNumberX++;
            }

            blockNumberY++;
            blockNumberX = 0;
        }
    }
}
