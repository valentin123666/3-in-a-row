using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batton : MonoBehaviour
{

    private GameObject Click;
    private AudioSource source;

    private void Start()
    {
        Click = GameObject.FindWithTag("Click");
        if(Click!=null)
        source = Click.GetComponent<AudioSource>();
    }

    public void ButtonExit()
    {
        source.Play();
        Application.Quit();

    }

    public void StartBottom()
    {
        source.Play();
        Application.LoadLevel("Level");
    }
    public void Restart()
    {
        source.Play();
        Application.LoadLevel("Level");
    }
    public void Menu()
    {
        source.Play();
        Application.LoadLevel("Menu");
    }
}
