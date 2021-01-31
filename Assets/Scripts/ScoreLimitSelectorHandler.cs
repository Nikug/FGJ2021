using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLimitSelectorHandler : MonoBehaviour
{
    public int scoreInterval;
    public int minScoreLimit = 50;
    public int maxScoreLimit = 100000;
    public int defaultScoreLimit = 600;
    private GameController controller;
    private int scoreLimit;
    public float intervalWaitTime;
    private float t;
    public TextMeshPro text;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        scoreLimit = defaultScoreLimit;
        t = 0;
    }

    void Update()
    {
        if (t < 0)
        {
            var value = Input.GetAxis("JoystickAxis3");
            if (value != 0f)
            {
                if (value > 0)
                {
                    scoreLimit += scoreInterval;
                }
                else if (value < 0)
                {
                    scoreLimit -= scoreInterval;
                }
                scoreLimit = Mathf.Clamp(scoreLimit, minScoreLimit, maxScoreLimit);
                t = intervalWaitTime;
                text.text = "Score limit: " + scoreLimit.ToString();

                controller.maxScore = scoreLimit;
            }
        }
        else
        {
            t -= Time.deltaTime;
        }

    }
}
