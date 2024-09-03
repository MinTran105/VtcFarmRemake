using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static FirebaseUser firebaseUser;
    public static PlayerInformation playerInfo;
    private DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        firebaseUser = FirebaseAuth.DefaultInstance.CurrentUser;
        if(playerInfo != null)
        {
            Debug.Log(playerInfo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetPlayerInformation()
    {
        reference.Child("Users").Child(firebaseUser.UserId).GetValueAsync().ContinueWithOnMainThread(task =>
        {

            if (task.IsFaulted)
            {
                Debug.Log("Doc Du Lieu that bai");
                return;
            }
            else
            if (task.IsCanceled)
            {
                Debug.Log("Doc Du Lieu bi huy");
                return;
            }
            else
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                playerInfo = JsonConvert.DeserializeObject<PlayerInformation>(snapshot.Value.ToString());
                Debug.Log("Lay Thong Tin PlayerInformation thanh cong");
            }
        });
    }
}
