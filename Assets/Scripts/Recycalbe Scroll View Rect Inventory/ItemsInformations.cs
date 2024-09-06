using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemsInformations
{
    //UI
    public string name { get; set; }
    public string description { get; set; }
    public Sprite sprite { get; set; }
    public int total {  get; set; }
    public ItemsInformations() { }

    public ItemsInformations(string name, string description, int total, Sprite sprite)
    {
        this.name = name;
        this.description = description;
        this.total = total;
        this.sprite = sprite;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
