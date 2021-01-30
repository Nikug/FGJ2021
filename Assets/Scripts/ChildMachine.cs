using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ChildMachine : MonoBehaviour {
    private LostChild getRandomLostChild() {
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
    private LostChild getSpesificLostChild(LostChild.Size pSize, LostChild.Hat pHat, LostChild.Color pColor, LostChild.StolenItem pStolenItem) {
        return new LostChild(pSize, pHat, pColor, pStolenItem);
    }
}
