using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;

public class ItemBagRSVR : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField] RecyclableScrollRect recyclableScrollRect;
    [SerializeField] int dataLenght;
    [SerializeField] GameObject inventoryGobj;

    private List<ItemsInformations> items = new List<ItemsInformations>();

    private void Awake()
    {
        recyclableScrollRect.DataSource = this;
    }

    public int GetItemCount()
    {
        return items.Count;
    }

    public void SetCell(ICell cell, int index)
    {
        var item = cell as ItemCellData;
        item.ConfigureCell(items[index], index);
    }
    private void GetListItem(List<ItemsInformations> list)
    {
        this.items = list;
    }
    private void Start()
    {
        List<ItemsInformations> list = new List<ItemsInformations>();
        for (int i = 0; i < 20; i++)
        {
            ItemsInformations item = new ItemsInformations();
            item.name = "Name " + i;
            item.description = "Des: " + i;
            list.Add(item);
        }
        Debug.Log(list.ToString());
        GetListItem(list);
        recyclableScrollRect.ReloadData();
    }
}