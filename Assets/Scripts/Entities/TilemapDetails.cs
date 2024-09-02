using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State { Grass, Ground, Farm }
public class TilemapDetails : MonoBehaviour
{

    public int x { get; set; }
    public int y { get; set; }
    public State state { get; set; }

    TilemapDetails() { }

    public TilemapDetails(int x, int y, State state)
    {
        this.x = x;
        this.y = y;
        this.state = state;
    }
}
