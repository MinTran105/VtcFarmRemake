using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;

using UnityEngine.UI;

public class ItemCellData : MonoBehaviour,ICell
{
    //UI
    public Text nameLabel;
    public Text descriptionLabel;
    public Image imageItem;

    //Model
    private ItemsInformations itemInfor;
    private int _cellIndex;

    public void ConfigureCell(ItemsInformations itemInfor,int cellIndex)
    {
        this.itemInfor = itemInfor;
        this._cellIndex = cellIndex;

        nameLabel.text = itemInfor.name;
        descriptionLabel.text = itemInfor.description;
        imageItem.sprite = itemInfor.sprite;
    }
}
