using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject canvasVideo;
    public GameObject cancionIntro;

    [SerializeField] private float contador; //cambiar a 102 o los segundos que dure el video
   public bool videoActivo = false;

    private void Awake()
    {
        //DontDestroyOnLoad(this);

        videoActivo = false;
        cancionIntro.SetActive(true);
        videoPlayer.SetActive(false);
        canvasVideo.SetActive(false);
    }

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
            videoActivo=false;
            contador = 6;
            SceneManager.LoadScene("Blocking");
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
