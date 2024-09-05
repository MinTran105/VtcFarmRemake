using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireBaseAuthManager : MonoBehaviour
{
    public FirebaseDatabaseManager databaseManager;
    private FirebaseAuth firebaseAuth;
    private GameManager gameManager;
    [Header("SwitchForm")]
    public GameObject loginForm;
    public GameObject registerForm;
    public Button swtLoginForm;
    public Button swtRegisterForm;

    [Header("Register")]
    public InputField emailRegister;
    public InputField passwordRegister;
    public InputField confirmPassRegister;
    public Button registerBtn;
    
    [Header("Login")]
    public InputField emailLogin;
    public InputField passwordLogin;
    public Button loginBtn;
    // Start is called before the first frame update
    void Start()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        registerBtn.onClick.AddListener(CreateAccountWithEmailAndPassword);

        loginBtn.onClick.AddListener(LoginAccountWithEmailAndPassWord);

        swtLoginForm.onClick.AddListener(SwitchForm);

        swtRegisterForm.onClick.AddListener(SwitchForm);

    }

   
    private void CreateAccountWithEmailAndPassword()
    {
        if(passwordRegister.text != confirmPassRegister.text)
        {
            Debug.Log("mat khau khong dung");
            passwordRegister.text = "";
            confirmPassRegister.text = "";
        }else
        {
            string email = emailRegister.text;
            string password = passwordRegister.text;
            firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
            {
                if(task.IsFaulted)
                {
                    Debug.Log("Dang Ky that bai" + task.Exception);
                    return;
                }else
                if (task.IsCanceled)
                {
                    Debug.Log("Dang Ky bi huy");
                    return;
                }else
                if(task.IsCompleted)
                {
                    Debug.Log("Dang Dang Ky");

                    Map map = new Map();
                    Debug.Log("Add map");

                    PlayerInformation playerInfo = new PlayerInformation("", 100, 0,map);
                    Debug.Log("Add PlayerInformation");

                    FirebaseUser user = task.Result.User;
                    Debug.Log("Lay thong tin user");

                    databaseManager.WriteData(user.UserId, playerInfo.ToString());
                    Debug.Log("Write Data");
                    gameManager.GetPlayerInformation();
                    Debug.Log("Dang Ky thanh Cong");

                    LoadingManager.SCENE_NAME = "Play";
                    SceneManager.LoadScene("LoadingScene");
                }
            });
        }
    }
    private void LoginAccountWithEmailAndPassWord()
    {
        string email = emailLogin.text;
        string password = passwordLogin.text;
        firebaseAuth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Dang Nhap that bai" + task.Exception);
                return;
            }
            else
               if (task.IsCanceled)
            {
                Debug.Log("Dang Nhap bi huy");
                return;
            }
            else
               if (task.IsCompleted)
            {
                Debug.Log("Dang Nhap thanh Cong");
                GameManager.firebaseUser = firebaseAuth.CurrentUser;
                gameManager.GetPlayerInformation();
                LoadingManager.SCENE_NAME = "Play";
                SceneManager.LoadScene("LoadingScene");
            }
        });
    }
    public void SwitchForm()
    {
        if(loginForm.activeSelf)
        {
            loginForm.SetActive(false);
            registerForm.SetActive(true);
        }else
        {
            loginForm.SetActive(true);
            registerForm.SetActive(false);
        }
    }
}
