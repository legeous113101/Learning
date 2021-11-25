using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LoadScene();
        }       

    }

    public void LoadScene()
    {
        SceneManager.LoadScene("HomeworkScene2");
    }
}
