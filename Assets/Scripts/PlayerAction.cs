using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerAction : MonoBehaviour
{
    private FarmManager farmManager;
    private MapManager mapManager;
    [Header("Tilemap and TileBase")]
    public Tilemap tm_ground;
    public Tilemap tm_grass;
    public Tilemap tm_farm;

    public TileBase tb_ground;
    public TileBase tb_grass;
    public TileBase tb_farm;
    [Header("Inventory")]
    public Sprite farmSprite;
    public ItemBagRSVR inventory;
    // Start is called before the first frame update
    void Start()
    {
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        farmManager = GameObject.Find("FarmManager").GetComponent<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            TileBase currentTbGrass = GetCurrentTile(transform.position,tm_grass);
            TileBase currentTbGround = GetCurrentTile(transform.position,tm_ground);
            if(currentTbGround != null && currentTbGrass == tb_grass)
            {
                tm_grass.SetTile(TransformPosInt(), null);
                mapManager.SaveTilemapChange(TransformPosInt(), State.Ground);
                Debug.Log("Dao");
            }
            
            
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            TileBase currentTbGrass = GetCurrentTile(transform.position, tm_grass);
            TileBase currentTbGround = GetCurrentTile(transform.position, tm_ground);
            TileBase currentTbFarm = GetCurrentTile(transform.position, tm_farm);

            if(currentTbGrass == null && currentTbGround != null && currentTbFarm == null)
            {
                farmManager.Planting(TransformPosInt(),0);
                Debug.Log("Trong");
                mapManager.SaveTilemapChange(TransformPosInt(),State.Farm);
            }
        }
        if(Input.GetKey(KeyCode.C))
        {
            TileBase currentTbFarm = GetCurrentTile(transform.position, tm_farm);
            if(currentTbFarm == tb_farm)
            {
                tm_farm.SetTile(TransformPosInt(), null);
                tm_grass.SetTile(TransformPosInt(), tb_grass);
                inventory.UpdateItem("Wheat", "Can Make Something", farmSprite);
                mapManager.SaveTilemapChange(TransformPosInt(), State.Grass);
            }
        }
    }

    private TileBase GetCurrentTile(Vector3 pos,Tilemap tilemap)
    {
        Vector3Int cellPos = tm_grass.WorldToCell(pos);

        return tilemap.GetTile(cellPos) as TileBase;
    }
    private Vector3Int TransformPosInt()
    {
        return tm_grass.WorldToCell(transform.position);
    }
}
