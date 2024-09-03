using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingComplete : MonoBehaviour
{
    public Button loadingBtn;
    // Start is called before the first frame update
    void Start()
    {
        loadingBtn.onClick.AddListener(PlayScene);
    }

    private void PlayScene()
    {
        SceneManager.LoadScene("Play");
    }
}
