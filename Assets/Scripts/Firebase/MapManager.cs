using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using Newtonsoft.Json;
using Firebase.Extensions;
using System;

public class MapManager : MonoBehaviour
{
    public Tilemap tmGrass;
    public Tilemap tmFarm;
    public Tilemap tmGround;
    public TileBase tbGrass;
    public TileBase tbFarm;
    private Map map;
    private FirebaseDatabaseManager databaseMng;
    private FirebaseUser user;
    private DatabaseReference reference;
    private GameManager gameMng;
    private FarmManager farmMng;
    private void Awake()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        gameMng = GameObject.Find("GameManager").GetComponent<GameManager>();

        databaseMng = GameObject.Find("FirebaseDatabaseManager").GetComponent<FirebaseDatabaseManager>();

        farmMng = GameObject.Find("FarmManager").GetComponent<FarmManager>();

        user = GameManager.firebaseUser;

    }
    public void  WriteAllTileMap()
    {
        map = new Map();
        List<TilemapDetails> list = new List<TilemapDetails>();

        for(int x = tmGrass.cellBounds.min.x;x <= tmGrass.cellBounds.max.x;x++)
        {
            for(int y = tmGrass.cellBounds.min.y; y <= tmGrass.cellBounds.max.y;y++)
            {
                TilemapDetails tilemapDetails = new TilemapDetails(x, y, State.Grass,DateTime.Now);
                list.Add(tilemapDetails);
            }
        }
        map.tilemapLst = list;
        GameManager.playerInfo.map = map;
        databaseMng.WriteData(user.UserId, GameManager.playerInfo.ToString());
      
        Debug.Log("Tai len du lieu ban do thanh cong");
        
    }

    //public void LoadMapForUser()
    //{
    //    reference.Child("Users").Child(user.UserId).Child("Map").GetValueAsync().ContinueWithOnMainThread(task =>
    //    {
    //        if(task.IsFaulted)
    //        {
    //            Debug.Log("Lay thong tin ban do that bai");
    //            return;
    //        }else
    //        if(task.IsCanceled)
    //        {
    //            Debug.Log("Lay thong tin ban do bi huy");
    //            return;
    //        }else
    //        if(task.IsCompleted)
    //        {
    //            DataSnapshot snapshot = task.Result;

    //            map = JsonConvert.DeserializeObject<Map>(snapshot.Value.ToString());
    //            MapToUI();
    //            Debug.Log("Lay thong tin ban do thanh cong");
    //            Debug.Log(map.ToString());
    //        }
    //    });
    //}

    public void LoadMapForUser()
    {
        map = GameManager.playerInfo.map;
        MapToUI();
    }
    private void TilemapDetailsToTilebase(TilemapDetails tilemapDetails)
    {
        Vector3Int cellPos = new Vector3Int(tilemapDetails.x, tilemapDetails.y);

        TileBase checkGround = tmGround.GetTile(cellPos);

        if(tilemapDetails.state == State.Grass && checkGround != null)
        {
            tmGrass.SetTile(cellPos, tbGrass);
        }if(tilemapDetails.state == State.Ground && checkGround != null)
        {
            tmGrass.SetTile(cellPos, null);
            tmFarm.SetTile(cellPos, null);
        }
        if(tilemapDetails.state == State.Farm && checkGround != null)
        {
            tmGrass.SetTile(cellPos, null);
            double elapsedTime = DateTime.Now.Subtract(tilemapDetails.dateTime).TotalSeconds;
            if(elapsedTime >90)
            {
                farmMng.Planting(cellPos, 3);
            }else
            if(elapsedTime > 60)
            {
                farmMng.Planting(cellPos, 2);
            }else
            if(elapsedTime > 30)
            {
                farmMng.Planting(cellPos, 1);
            }else
            {
                farmMng.Planting(cellPos, 0);
            }
        }
    }

    private void MapToUI()
    {
        for(int i = 0; i < map.GetLength(); i++)
        {
            TilemapDetailsToTilebase(map.tilemapLst[i]);
        }
    }

    private void Start()
    {
       if(GameManager.playerInfo.map.tilemapLst == null)
        {
            WriteAllTileMap();
        }else
        {
            LoadMapForUser();
        }
    }
    public void SaveTilemapChange(Vector3Int cellPos, State state)
    {
        for (int i = 0; i < map.GetLength(); i++)
        {
            if (map.tilemapLst[i].x == cellPos.x && map.tilemapLst[i].y == cellPos.y)
            {
                map.tilemapLst[i].state = state;
                GameManager.playerInfo.map = map;
                GameManager.playerInfo.map.tilemapLst[i].dateTime = DateTime.Now;
                databaseMng.WriteData(user.UserId, GameManager.playerInfo.ToString());
                break;
            }
        }
    }

}
