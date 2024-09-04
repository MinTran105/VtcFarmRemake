using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State { Grass, Ground, Farm }
public class TilemapDetails
{

    public int x { get; set; }
    public int y { get; set; }
    public State state { get; set; }

    public DateTime dateTime { get; set; }

    TilemapDetails() { }

    public TilemapDetails(int x, int y, State state, DateTime dateTime)
    {
        this.x = x;
        this.y = y;
        this.state = state;
        this.dateTime = dateTime;
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
