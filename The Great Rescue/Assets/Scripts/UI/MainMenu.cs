using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Credits;
    public UIFader FadeOut;





    // Start is called before the first frame update
    public void PlayGame()
    {
        FadeOut.gameObject.SetActive(true);
        StartCoroutine(waitAndPlayGame(FadeOut.fadeTime));

    }

    public void UnloadHighscore()
    {
        SceneManager.UnloadSceneAsync(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadHighScoreFromMenu()
    {
        //FadeOut.gameObject.SetActive(true);
        //StartCoroutine(waitAndLoadHighscore(FadeOut.fadeTime));
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }

    public void OpenCredit()
    {
        if(Credits != null)
            Credits.SetActive(true);
    }

    public void CloseCredit()
    {
        if (Credits != null)
            Credits.SetActive(false);
    }
    
    IEnumerator waitAndPlayGame(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator waitAndLoadHighscore(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }
}
