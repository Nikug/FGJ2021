using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using TMPro;

public class MiserableParent : MonoBehaviour
{
    private LostChild child = null;
    private int numberOfAttributes = 0;
    private int pointsToGive = 0;
    private int POINTS_PER_ATTRIBUTE = 50;
    public TMP_Text info;
    private System.Random random;
    public GameObject scoreController;
    public ParentSoundHandler sounds;
    private GameController gameController;

    void Start()
    {
        random = new System.Random((int)DateTime.Now.Ticks);
        this.changeChild();
        //scoreController.GetComponent<ScoresController>().updateStatusText("1", 50);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void CreateInfo(LostChild childToFind)
    {
        string childSize;
        if (childToFind.getSize().ToString() == "ThiccOhhLordHeComing")
        {
            childSize = "Thicc";
        }
        else
        {
            childSize = childToFind.getSize().ToString();
        }
        var infoText = childToFind.getColor() + "\n" + childSize + "\n" + childToFind.getHat() + "\n" + childToFind.getStolenItem();

        info.text = infoText;

    }

    private LostChild getRandomLostChildWithNAttributes(int pNumberOfAttributes)
    {
        int numberOfAttributes = pNumberOfAttributes;
        if (numberOfAttributes < 1)
        {
            numberOfAttributes = 1;
        }
        else if (numberOfAttributes > 4)
        {
            numberOfAttributes = 4;
        }

        Array sizeValues = Enum.GetValues(typeof(LostChild.Size));
        Array hatValues = Enum.GetValues(typeof(LostChild.Hat));
        Array colorValues = Enum.GetValues(typeof(LostChild.Color));
        Array stolenItemValues = Enum.GetValues(typeof(LostChild.StolenItem));

        LostChild randomChild = new LostChild(
            (LostChild.Size)sizeValues.GetValue(random.Next(sizeValues.Length)),
            (LostChild.Hat)hatValues.GetValue(random.Next(hatValues.Length)),
            (LostChild.Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (LostChild.StolenItem)stolenItemValues.GetValue(random.Next(stolenItemValues.Length))
        );

        for (int i = 0; i < 4 - numberOfAttributes; i++)
        {
            bool fieldRemoved = false;

            while (fieldRemoved != true)
            {
                int randomInt = random.Next(0, 4);

                switch (randomInt)
                {
                    case 0:
                        if (randomChild.getSize() != null)
                        {
                            randomChild.setSize(null);
                            fieldRemoved = true;
                        }
                        break;
                    case 1:
                        if (randomChild.getHat() != null)
                        {
                            randomChild.setHat(null);
                            fieldRemoved = true;
                        }
                        break;
                    case 2:
                        if (randomChild.getColor() != null)
                        {
                            randomChild.setColor(null);
                            fieldRemoved = true;
                        }
                        break;
                    case 3:
                        if (randomChild.getStolenItem() != null)
                        {
                            randomChild.setStolenItem(null);
                            fieldRemoved = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        /*
        Debug.Log(randomChild.getSize());
        Debug.Log(randomChild.getStolenItem());
        Debug.Log(randomChild.getHat());
        Debug.Log(randomChild.getColor());
        */


        return randomChild;
    }

    private void changeChild()
    {
        numberOfAttributes = random.Next(1, 5);
        child = this.getRandomLostChildWithNAttributes(numberOfAttributes);
        pointsToGive = numberOfAttributes * POINTS_PER_ATTRIBUTE;
        CreateInfo(getChild());
    }

    private LostChild getChild()
    {
        return child;
    }

    private int getPoints()
    {
        return pointsToGive;
    }

    public bool offerChild(LostChild offeredChild, string playerName)
    {
        int matchingAttributes = 0;

        if (child.getSize() != null && child.getSize() == offeredChild.getSize())
        {
            matchingAttributes = matchingAttributes + 1;
        }

        if (child.getHat() != null && child.getHat() == offeredChild.getHat())
        {
            matchingAttributes = matchingAttributes + 1;
        }

        if (child.getColor() != null && child.getColor() == offeredChild.getColor())
        {
            matchingAttributes = matchingAttributes + 1;
        }

        if (child.getStolenItem() != null && child.getStolenItem() == offeredChild.getStolenItem())
        {
            matchingAttributes = matchingAttributes + 1;
        }

        int scoreNeededToPass = random.Next(1, numberOfAttributes + 1);

        if (matchingAttributes >= scoreNeededToPass)
        {
            //Debug.Log("passed");
            sounds.AcceptSound();
            changeChild();

            /* Give player points */
            //Debug.Log("Give player: " + playerName + " " + pointsToGive + " points.");
            gameController.givePoints(playerName, pointsToGive);
            int newScore = gameController.getPlayerScore(playerName);
            //Debug.Log("New points: " + newScore);
            scoreController.GetComponent<ScoresController>().updateStatusText(playerName, newScore);

            return true;
        }

        Debug.Log("failed");
        sounds.RejectSound();
        return false;
    }
}
