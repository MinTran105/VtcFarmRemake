using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;
using Unity.VisualScripting;

public class ItemBagRSVR : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField] RecyclableScrollRect recyclableScrollRect;
    [SerializeField] int dataLenght;
    [SerializeField] private Vector3 hidePos;
    [SerializeField] private Vector3 showPos;
    private bool isShow = false;
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

    public void UpdateItem(string name,string des, Sprite sprite)
    {
        
        for(int i = 0;i < items.Count;i++)
        {
            if(items[i].name == name)
            {
                items[i].total++;
                break;
            }else
            {
                ItemsInformations item = new ItemsInformations(name, des, 1, sprite);
                int temp  = items.FindIndex(0,1,itemCell => itemCell.total == 0);
                items[temp] = item;
            }
        }
        recyclableScrollRect.ReloadData();
        Debug.Log("Nhat Thanh Cong");
    }
    private void Start()
    {
        List<ItemsInformations> list = new List<ItemsInformations>();
        for (int i = 0; i < 20; i++)
        {
            ItemsInformations item = new ItemsInformations(" "," ",0,null);
            list.Add(item);
        }
        GetListItem(list);
        recyclableScrollRect.ReloadData();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isShow = !isShow;
        }
        ShowController();
    }
    private void ShowController()
    {
        if(!isShow)
        {
            recyclableScrollRect.transform.position = hidePos;
        }else
        {
            recyclableScrollRect.transform.position = showPos;
        }
    }
}