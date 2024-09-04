using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class FarmManager : MonoBehaviour
{
    public List<TileBase> growPlant;
    [SerializeField] private Tilemap tmFarm;
    [SerializeField] private float growupTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Planting(Vector3Int cellPos,int index)
    {
        StartCoroutine(GrowUpTime(cellPos, index));
    }
    // Update is called once per frame
    private IEnumerator GrowUpTime(Vector3Int cellPos,int index)
    {
        for (int i = index;i<growPlant.Count;i++)
        {
            tmFarm.SetTile(cellPos, growPlant[i]);
            yield return new WaitForSeconds(growupTime);
           
        }
        yield return null;
    }
}
