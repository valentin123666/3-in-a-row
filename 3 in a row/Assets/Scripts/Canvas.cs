using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField]
    private Text textCount;
    [System.NonSerialized]
    public int Count;
    void Update()
    {
        textCount.text = "" + Count;
    }
}
