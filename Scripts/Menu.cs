using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuSound;
    public void PlayGame()
    {
        Instantiate(menuSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("GameStart");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
