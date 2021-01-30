using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ChildMachine : MonoBehaviour
{
    private static ChildMachine _instance = null;

    private int childCount;
    private int maxChilds;
    public GameObject spawningBed;
    public ToddlerTulostin spawner;
    private System.Random random;

    public static ChildMachine Instance {
        get {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private static int getChildCount()
    {
        return Instance.childCount;
    }

    private static int getMaxChilds()
    {
        return Instance.maxChilds;
    }

    private static void setChildCount(int newChildCount)
    {
        Instance.childCount = newChildCount;
    }

    private static void setMaxChilds(int newMaxChilds)
    {
        Instance.maxChilds = newMaxChilds;
    }

    private static LostChild getRandomLostChild()
    {
        Array sizeValues = Enum.GetValues(typeof(LostChild.Size));
        Array hatValues = Enum.GetValues(typeof(LostChild.Hat));
        Array colorValues = Enum.GetValues(typeof(LostChild.Color));
        Array stolenItemValues = Enum.GetValues(typeof(LostChild.StolenItem));

        return new LostChild(
            (LostChild.Size)sizeValues.GetValue(Instance.random.Next(sizeValues.Length)),
            (LostChild.Hat)hatValues.GetValue(Instance.random.Next(hatValues.Length)),
            (LostChild.Color)colorValues.GetValue(Instance.random.Next(colorValues.Length)),
            (LostChild.StolenItem)stolenItemValues.GetValue(Instance.random.Next(stolenItemValues.Length))
        );
    }

    private static LostChild getSpesificLostChild(LostChild.Size pSize, LostChild.Hat pHat, LostChild.Color pColor, LostChild.StolenItem pStolenItem)
    {
        return new LostChild(pSize, pHat, pColor, pStolenItem);
    }

    public static void deleteChild()
    {
        setChildCount(Instance.childCount - 1);
        spawnLostChild();
    }

    private static void spawnLostChild()
    {
        LostChild child = getRandomLostChild();
        Instance.spawner.spawnChild(child);
        /*
        Debug.Log(child.getSize());
        Debug.Log(child.getStolenItem());
        Debug.Log(child.getHat());
        Debug.Log(child.getColor());
        */
        
        Instance.childCount = Instance.childCount + 1;
    }

    void Start()
    {
        random = new System.Random();
        for (int i = 0; i < 2; i++) {
            spawnLostChild();
        }
    }
}
