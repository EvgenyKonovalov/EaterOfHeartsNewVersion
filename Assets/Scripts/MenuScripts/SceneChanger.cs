using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public int levelToload;
    private Animator anim;
    public Slider slider;
    public GameObject loadingScreen;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToload);
        anim.SetTrigger("Fade");
        StartCoroutine(LoadingScreenOnFade());
        Debug.Log("ahgugaug");
    }
    // Update is called once per frame
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
    IEnumerator LoadingScreenOnFade()
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToload);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yield return null;
        }
    }
}
