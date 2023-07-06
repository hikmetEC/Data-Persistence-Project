using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text nameText;
    

    private void Start()
    {
        if (dataPersister.Instance.getName())
        {
            nameText.text = dataPersister.Instance.pName+  ": " + dataPersister.Instance.bestScore;
            nameInput.text = dataPersister.Instance.pName;
        }
        else Debug.Log("Please enter a name first!");
    }

    public void Quit() //quiting the game(checks if it's played on editor or not)
    {
#if UNITY_EDITOR
        Application.Quit();
#else
        EditorApplication.ExitPlaymode();
#endif
    }

    public void StartGame() //starting the game
    {
        SceneManager.LoadScene(1);
    }

    
}
