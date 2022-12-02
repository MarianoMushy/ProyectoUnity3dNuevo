using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MochilaTrigger : MonoBehaviour
{
    public static bool MochilaTriggerBool = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MochilaTriggerBool = true;
            StartCoroutine("bossFight");
            
        }
    }

    IEnumerator bossFight()
    {
        yield return new WaitForSeconds(.9f);
        SceneManager.LoadScene("BossFightTest");
        GameManager.instance.lastCheckpointPos.x = 18;
        GameManager.instance.lastCheckpointPos.y = 1;
        GameManager.instance.lastCheckpointPos.z = -23.5f;
    }
}
