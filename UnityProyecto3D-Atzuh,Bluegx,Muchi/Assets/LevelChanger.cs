using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private int levelToLoad;
    public Animator animator;
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    FadeToNextLevel(); //Para pasar al siguiente nivel
        //}
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
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
