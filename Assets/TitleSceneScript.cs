using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    public AudioSource chirp;

    public void PlayNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayChirp()
    {
        chirp.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
