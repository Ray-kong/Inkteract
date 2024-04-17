using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
