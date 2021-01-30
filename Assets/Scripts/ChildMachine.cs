using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ChildMachine : MonoBehaviour
{
    private int childCount;
    private int maxChilds;
    public GameObject spawningBed;
    public ToddlerTulostin spawner;

    public int getChildCount()
    {
        return childCount;
    }

    public int getMaxChilds()
    {
        return maxChilds;
    }

    private void setChildCount(int newChildCount)
    {
        childCount = newChildCount;
    }

    private void setMaxChilds(int newMaxChilds)
    {
        maxChilds = newMaxChilds;
    }

    public LostChild getRandomLostChild()
    {
        System.Random random = new System.Random();
        Array sizeValues = Enum.GetValues(typeof(LostChild.Size));
        Array hatValues = Enum.GetValues(typeof(LostChild.Hat));
        Array colorValues = Enum.GetValues(typeof(LostChild.Color));
        Array stolenItemValues = Enum.GetValues(typeof(LostChild.StolenItem));

        return new LostChild(
            (LostChild.Size)sizeValues.GetValue(random.Next(sizeValues.Length)),
            (LostChild.Hat)hatValues.GetValue(random.Next(hatValues.Length)),
            (LostChild.Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (LostChild.StolenItem)stolenItemValues.GetValue(random.Next(stolenItemValues.Length))
        );
    }
    private LostChild getSpesificLostChild(LostChild.Size pSize, LostChild.Hat pHat, LostChild.Color pColor, LostChild.StolenItem pStolenItem)
    {
        return new LostChild(pSize, pHat, pColor, pStolenItem);
    }

    public ChildMachine(int pMaxChilds)
    {
        childCount = 0;
        maxChilds = pMaxChilds;
    }

    public void decreaseChildCount()
    {
        this.setChildCount(childCount - 1);
    }

    private void spawnLostChild()
    {
        LostChild child = this.getRandomLostChild();
        spawner.spawnChild(child);
        /*
        Debug.Log(child.getSize());
        Debug.Log(child.getStolenItem());
        Debug.Log(child.getHat());
        Debug.Log(child.getColor());
        */

    }

    void Start()
    {
        // Debug.Log(spawningBed.transform.position);
        // this.spawnLostChild();
    }
}
