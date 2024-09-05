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
    private float fixedLoadingTime = 3f;

    private void Start()
    {
        StartCoroutine(LoadSceneFixedTime(SCENE_NAME));
    }
    //cho du lieu tai k moi load scene, danh cho game du lieu lon
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.GetComponent<Image>().fillAmount = progress;

            textPercent.text = (progress * 100).ToString("0") + "%";

            yield return null;
        }
    }
    //load scene sau 1 khoang thoi gian, danh cho game du lieu nho
    IEnumerator LoadSceneFixedTime(string sceneName)
    {
        float elapsedTime = 0f;

        while(elapsedTime < fixedLoadingTime)
        {
            float progress = Mathf.Clamp01(elapsedTime / fixedLoadingTime);

            progressBar.GetComponent<Image>().fillAmount = progress;

            textPercent.text = (progress * 100).ToString("0") + "%";

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
