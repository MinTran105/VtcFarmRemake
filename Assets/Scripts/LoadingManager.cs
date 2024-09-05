using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static string SCENE_NAME = "Play";
    public GameObject progressBar;
    public Text textPercent;
    private float fixedLoandingTime = 3f;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync(SCENE_NAME));
    }
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.GetComponent<Image>().fillAmount = progress;

            textPercent.text = (progress * 100).ToString("0");

            yield return null;
        }


    }
}
