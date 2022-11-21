using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject canvasVideo;

    public GameObject cancionIntro;

    public float contador = 120; //cambiar a 102 o los segundos que dure el video

    bool videoActivo = false;

    public void exit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (videoActivo == true)
        {
            contador -= Time.deltaTime;
        }


        if (contador <= 0)
        {
            SceneManager.LoadScene("Nivel1");
            //videoPlayer.SetActive(false);
            //canvasVideo.SetActive(false);
            //SceneManager.LoadScene("Nivel1");
        }

    }

    public void EmpezarVideo()
    {
        videoActivo = true;
        cancionIntro.SetActive(false);
        videoPlayer.SetActive(true);
        canvasVideo.SetActive(true);
    }
}
