using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation
{
    public string name { get; set; }
    public int gold { get; set; }
    public int diamond { get; set; }
    public Map map { get; set; }

    public PlayerInformation() { }

    public PlayerInformation(string name, int gold, int diamond, Map map)
    {
        this.name = name;
        this.gold = gold;
        this.diamond = diamond;
        this.map = map;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
