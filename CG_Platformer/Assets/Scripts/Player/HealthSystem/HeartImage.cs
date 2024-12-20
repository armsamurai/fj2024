using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartImage : MonoBehaviour
{
    public void ShowHeart()
    {
        GetComponent<Image>().color = Color.white;
    }

    public void HideHeart()
    {
        GetComponent<Image>().color = Color.black;
    }
}
