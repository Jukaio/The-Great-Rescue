using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yea : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject fadeIn;
    public GameObject Image;
    public GameObject Image2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endgame());
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator endgame()
    {
        yield return new WaitForSeconds(2f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        Image.SetActive(false);
        fadeIn.SetActive(false);
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
        yield return new WaitForSeconds(6f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(4, LoadSceneMode.Additive);



    }
}
