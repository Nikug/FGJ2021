using System.Collections;
using System.Collections.Generic;

public class LostChild {
    public enum Size {
        Thin,
        Normal,
        ThiccOhhLordHeComing

    }

    public enum Hat {
        Tophat,
        PropellerHat,
        Cap,
        Beanie,
        FurHat,

    }

    public enum Color {
        Red,
        Yellow,
        Green,
        Blue,
    }

    public enum StolenItem {
        IceCream,
        Triangle,
        TeddyBear,
        Gun,
        Donut
    }

    private Size size;
    private Hat hat;
    private Color color;
    private StolenItem stolenItem;

    public LostChild(Size pSize, Hat pHat, Color pColor, StolenItem pStolenItem) {
        size = pSize;
        hat = pHat;
        color = pColor;
        stolenItem = pStolenItem;
    }

    public Size getSize() {
        return size;
    }

    public Hat getHat() {
        return hat;
    }

    public Color getColor() {
        return color;
    }

    public StolenItem getStolenItem() {
        return stolenItem;
    }
}
