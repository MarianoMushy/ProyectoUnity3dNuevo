using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private int levelToLoad;
    public Animator animator;

    void Update()
    {
        if (DeathZone.muerte)
        {
            FadeToNextLevel(); //Para pasar al siguiente nivel
            DeathZone.muerte = false;
        }


        if (MochilaTrigger.MochilaTriggerBool)
        {
            //DeathZone.muerte = true;
            FadeToNextLevelBoss();
            MochilaTrigger.MochilaTriggerBool = false;
            //SceneManager.LoadScene("BossFightTest");
        }

        if (PressurePadPhase2.BossTriggerPhase2Bool)
        {
            //DeathZone.muerte = true;
            FadeToNextLevelBossPhase2();
            PressurePadPhase2.BossTriggerPhase2Bool = false;
            //SceneManager.LoadScene("BossFightTest");
        }


    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void FadeToNextLevelBoss()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void FadeToNextLevelBossPhase2()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }


    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
