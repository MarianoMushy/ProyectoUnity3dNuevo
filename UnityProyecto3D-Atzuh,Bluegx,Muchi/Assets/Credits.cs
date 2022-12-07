using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject CreditsvideoPlayer;
    public GameObject CreditscanvasVideo;
    public GameObject cancionIntro;

    [SerializeField] private float contadorCredits; //cambiar a 102 o los segundos que dure el video
    public bool videoActivoCredits = false;


    private void Awake()
    {
        videoActivoCredits = false;
        CreditsvideoPlayer.SetActive(false);
        CreditscanvasVideo.SetActive(false);

    }

    public void exit()
    {
        Application.Quit();
    }

    void Update()
    {
      
        if (videoActivoCredits == true)
        {
            contadorCredits -= Time.deltaTime;
        }

        if (contadorCredits <= 0)
        {
            videoActivoCredits = false;
            contadorCredits = 24;
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void EmpezarVideoCredits()
    {
        videoActivoCredits = true;
        cancionIntro.SetActive(false);
        CreditsvideoPlayer.SetActive(true);
        CreditscanvasVideo.SetActive(true);
    }


}
