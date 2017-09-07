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

    List<GameObject> activeBlocksList = new List<GameObject>();

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

        foreach (GameObject block in blockArray)
        {
            if (block.GetComponent<Image>().color == Color.black)
            {
                activeBlocksList.Add(block);
            }
        }
    }

    IEnumerator StartGameCoroutine()
    {
        CheckAllActiveBlocks();

        for (int i = 0; i < Mathf.Infinity; i++)
        {
            //Debug.Log(i);

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
