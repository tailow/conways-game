using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Variables

    public Vector2 blockSize;
    public int amountOfBlocksX = 16;
    public int amountOfBlocksY = 9;

    public int minNeighbors = 2;
    public int maxNeighbors = 5;
    public int amountToSpawn = 3;

    public float tickTime = 0.1f;

    public GameObject blockPrefab;

    List<GameObject> blockList = new List<GameObject>();

    public List<GameObject> nextActiveBlocksList = new List<GameObject>();

    #endregion

    void Start()
    {
        blockSize = new Vector2(Screen.width / amountOfBlocksX, Screen.height / amountOfBlocksY);        

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

        nextActiveBlocksList.Clear();
    }

    void InactivateBlocks()
    {
        foreach (GameObject block in blockList)
        {
            if (block.GetComponent<Image>().color == Color.black)
            {
                block.GetComponent<Image>().color = Color.white;
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
        foreach (GameObject block in blockList)
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

            // Add next active blocks to list
            AddAllNextBlocks();

            // Set all blocks to inactive
            InactivateBlocks();

            // Set listed blocks active
            ActivateNextBlocks();

            yield return new WaitForSeconds(tickTime);
        }      
    }

    void GenerateBlocks()
    {
        for (int y = (int)(blockSize.y / 2); y < Screen.height; y += (int)blockSize.y)
        {     
            for (int x = (int)(blockSize.x / 2); x < Screen.width; x += (int)blockSize.x)
            {
                var blockObj = Instantiate(blockPrefab, new Vector2(x, y), Quaternion.identity);

                blockObj.transform.SetParent(GameObject.Find("Blocks").transform);
                blockObj.GetComponent<RectTransform>().localScale = blockSize;

                blockList.Add(blockObj);
            }
        }
    }
}
