using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public List<TilemapDetails> tilemapLst { get; set; }

    public Map() { }
    public Map(List<TilemapDetails> tilemapLst)
    {
        this.tilemapLst = tilemapLst;
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
    public int GetLength()
    {
        return tilemapLst.Count;
    }
}
