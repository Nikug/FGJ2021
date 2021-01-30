using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToddlerPicker : MonoBehaviour
{
    public GameObject topHat;
    public GameObject propellerHat;
    public GameObject cap;
    public GameObject beanie;
    public GameObject furHat;
    public GameObject iceCream;
    public GameObject triangle;
    public GameObject teddyBear;
    public GameObject gun;
    public GameObject donut;
    public Color GetColor(LostChild.Color? color)
    {
        switch (color)
        {
            case LostChild.Color.Red:
                return Color.red;
            case LostChild.Color.Yellow:
                return Color.yellow;
            case LostChild.Color.Green:
                return Color.green;
            case LostChild.Color.Blue:
                return Color.blue;
        }
        return Color.black;
    }

    public float GetSize(LostChild.Size? size)
    {
        switch (size)
        {
            case LostChild.Size.Thin:
                return 0.7f;
            case LostChild.Size.Normal:
                return 1f;
            case LostChild.Size.ThiccOhhLordHeComing:
                return 1.5f;
        }
        return 1f;
    }

    public GameObject GetHat(LostChild.Hat? hat)
    {
        switch (hat)
        {
            case LostChild.Hat.Tophat:
                return topHat;
            case LostChild.Hat.PropellerHat:
                return propellerHat;
            case LostChild.Hat.Cap:
                return cap;
            case LostChild.Hat.Beanie:
                return beanie;
            case LostChild.Hat.FurHat:
                return furHat;
        }
        return topHat;
    }

    public GameObject GetItem(LostChild.StolenItem? item)
    {
        switch (item)
        {
            case LostChild.StolenItem.IceCream:
                return iceCream;
            case LostChild.StolenItem.Triangle:
                return triangle;
            case LostChild.StolenItem.TeddyBear:
                return teddyBear;
            case LostChild.StolenItem.Gun:
                return gun;
            case LostChild.StolenItem.Donut:
                return donut;
        }
        return iceCream;
    }
}
