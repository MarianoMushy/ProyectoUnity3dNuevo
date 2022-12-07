using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pressurepad : MonoBehaviour
{
    public GameObject PlatFormController;
    public GameObject PlatForm;
    public GameObject exp;

    public static bool BossTriggerPhase2Bool = false;


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Cube") 
        {
            Transform box = other.GetComponent<Transform>();

            box.GetComponent<Rigidbody>().isKinematic = true;
            box.GetComponent<Renderer>().material.color = Color.green;
            Destroy(box.gameObject, 1f);

            GameObject _exp = Instantiate(exp, PlatForm.transform.position, PlatForm.transform.rotation);
            Destroy(PlatFormController,1);


            BossTriggerPhase2Bool = true;
            StartCoroutine("bossFight");

        }
    }

    IEnumerator bossFight()
    {
        yield return new WaitForSeconds(.9f);
        SceneManager.LoadScene("BossFightTest2");
        GameManager.instance.lastCheckpointPos.x = 18;
        GameManager.instance.lastCheckpointPos.y = 1;
        GameManager.instance.lastCheckpointPos.z = -23.5f;
    }


}
