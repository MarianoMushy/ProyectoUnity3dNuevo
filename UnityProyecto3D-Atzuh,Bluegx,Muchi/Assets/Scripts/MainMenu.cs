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
            contador = 12;
            SceneManager.LoadScene("Blocking");
        }
    }

    public void EmpezarVideo()
    {
        GameManager.instance.lastCheckpointPos.x = -21;
        GameManager.instance.lastCheckpointPos.y = 5;
        GameManager.instance.lastCheckpointPos.z = 3;
        videoActivo = true;
        cancionIntro.SetActive(false);
        videoPlayer.SetActive(true);
        canvasVideo.SetActive(true);
    }
}
