using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class LoadScene : CharacterCreator
{

    public void SceneLoader(int SceneIndex)
    {
        Debug.Log(i);
        if (i == 1 || SceneIndex==0 || SceneIndex == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneIndex);
           
        }
    }
}
