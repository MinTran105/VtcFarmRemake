using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirebaseDatabaseManager : MonoBehaviour
{
    DatabaseReference dataReference;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        dataReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WriteData(string id,string message)
    {
        dataReference.Child("Users").Child(id).SetValueAsync(message).ContinueWithOnMainThread(task =>
        {
            if(task.IsFaulted)
            {
                Debug.Log("Ghi Du Lieu that bai");
                return;
            }else
            if(task.IsCanceled)
            {
                Debug.Log("Ghi Du Lieu bi huy");
                return;
            }else
            if(task.IsCompleted)
            {
                Debug.Log("Ghi Du Lieu thanh cong");
            }
        });
    }

    public void ReadData(string id)
    {
        dataReference.Child("Users").Child(id).GetValueAsync().ContinueWithOnMainThread(task =>
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
                Debug.Log(snapshot);
                Debug.Log("Doc Du Lieu thanh cong");
            }
        });
    }
}
