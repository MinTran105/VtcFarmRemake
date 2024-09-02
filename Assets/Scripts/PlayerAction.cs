using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerAction : MonoBehaviour
{
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
            }
            Debug.Log("Dao"); 
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            TileBase currentTbGrass = GetCurrentTile(transform.position, tm_grass);
            TileBase currentTbGround = GetCurrentTile(transform.position, tm_ground);
            TileBase currentTbFarm = GetCurrentTile(transform.position, tm_farm);

            if(currentTbGrass == null && currentTbGround != null && currentTbFarm == null)
            {
                tm_farm.SetTile(TransformPosInt(),tb_farm);
                Debug.Log("Trong");
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
