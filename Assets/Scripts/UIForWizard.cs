using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIForWizard : MonoBehaviour
{
    public FirebaseDatabaseManager databaseManager;
    [Header("UI")]
    public Text nameText;
    public Text goldText;
    public Text diamondText;
    [Header("Create Name Box")]
    public GameObject createNameBox;
    public InputField nameInput;
    public Button comfirm;
    // Start is called before the first frame update
    void Start()
    {
        databaseManager = GameObject.Find("FirebaseDatabaseManager").GetComponent<FirebaseDatabaseManager>();
        comfirm.onClick.AddListener(CreateName);
        if (GameManager.playerInfo.name == "")
        {
            Time.timeScale = 0;
            createNameBox.SetActive(true);
        }else
        {
            createNameBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = "Name: " + GameManager.playerInfo.name;
        goldText.text = "Gold: " + GameManager.playerInfo.gold;
        diamondText.text = "Diamond: " + GameManager.playerInfo.diamond; 
    }
    private void CreateName()
    {
        if(nameInput.text == "")
        {
            Debug.Log("Ten Khong Hop Le");
        }else
        {
            GameManager.playerInfo.name = nameInput.text;
            databaseManager.WriteData(GameManager.firebaseUser.UserId, GameManager.playerInfo.ToString());
            Time.timeScale = 1;
            createNameBox.SetActive(false);
        }
    }
}
