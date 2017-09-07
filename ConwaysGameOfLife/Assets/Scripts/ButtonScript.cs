using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

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
}
