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
    public List<GameObject> nextActiveBlocksList = new List<GameObject>();

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
        StopCoroutine("StartGameCoroutine");
    }

    void StopGame()
    {
        StopCoroutine("StartGameCoroutine");

        InactivateBlocks();
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

    void InactivateBlocks()
    {
        for (int y = 0; y < amountOfBlocks.y; y++)
        {
            for (int x = 0; x < amountOfBlocks.x; x++)
            {
                if (blockArray[x, y].GetComponent<Image>().color == Color.black)
                {
                    blockArray[x, y].GetComponent<Image>().color = Color.white;
                }
            }
        }
    }

    void ActivateNextBlocks()
    {
        foreach (GameObject block in nextActiveBlocksList)
        {
            block.GetComponent<Image>().color = Color.black;
        }
    }

    void AddAllNextBlocks()
    {
        foreach (GameObject block in blockArray)
        {
            block.SendMessage("CheckActiveNeighbors");
        }
    }

    IEnumerator StartGameCoroutine()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            // Clear next active blocks list
            nextActiveBlocksList.Clear();

            // Add next active blocks to Vector2 list
            AddAllNextBlocks();

            // Set all blocks to inactive
            InactivateBlocks();

            // Set listed blocks active
            ActivateNextBlocks();

            // Clear current active blocks list
            activeBlocksList.Clear();

            // List current active blocks
            CheckAllActiveBlocks();

            yield return new WaitForSeconds(0.1f);
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
