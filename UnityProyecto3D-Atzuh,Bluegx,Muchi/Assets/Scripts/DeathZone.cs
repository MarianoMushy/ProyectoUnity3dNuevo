using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public static bool muerte;

    private bool once = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (once)
            {
                muerte = true; 
                once = false;
                StartCoroutine(ReloadScene());
                
            }
        }
    }

    IEnumerator ReloadScene()
    {
        AudioManager.Instance.Play("Death");
        ThirdPersonController.anim.SetTrigger("Die");
        yield return new WaitForSeconds(.1f);
        once = true;
        muerte = false;
    }

}
