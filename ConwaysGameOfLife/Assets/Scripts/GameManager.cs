using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Variables

    Vector2 blockSize;
    Vector2 amountOfBlocks;

    public GameObject blockPrefab;
    GameObject[,] blockArray;

    #endregion

    void Start()
    {
        blockSize = new Vector2(30, 30);
        amountOfBlocks = new Vector2(Screen.width/blockSize.x, Screen.height/blockSize.y);

        blockArray = new GameObject[(int)amountOfBlocks.x, (int)amountOfBlocks.y];

        GenerateBlocks();
    }

    void GenerateBlocks()
    {
        for (int y = 15; y < Screen.height; y += (int)blockSize.y)
        {
            for (int x = 15; x < Screen.width; x += (int)blockSize.x)
            {
                var blockObj = Instantiate(blockPrefab, new Vector2(x, y), Quaternion.identity);

                blockObj.transform.SetParent(GameObject.Find("Blocks").transform);

            }
        }
    }
}
