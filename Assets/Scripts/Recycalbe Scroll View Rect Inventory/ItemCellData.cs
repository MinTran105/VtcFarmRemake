using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;

using UnityEngine.UI;

public class ItemCellData : MonoBehaviour,ICell
{
    //UI
    public Text nameLabel;
    public Text total;
    public Image imageItem;

    //Model
    private ItemsInformations itemInfor;
    private int _cellIndex;

    public void ConfigureCell(ItemsInformations itemInfor,int cellIndex)
    {
        this.itemInfor = itemInfor;
        this._cellIndex = cellIndex;

        nameLabel.text = itemInfor.name;
        imageItem.sprite = itemInfor.sprite;
        if(itemInfor.total == 0)
        {
            total.text = "";
        }else
        {
            total.text = itemInfor.total.ToString();
        }
    }
}
