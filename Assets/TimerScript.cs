using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public WatermelonController Player;
    public TextMeshProUGUI Timer;
    public float DefSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DefSize = Timer.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        Timer.text = Mathf.Round(Player.time).ToString();

        if (Player.time < 26 && Player.time > 0)
        {
            Timer.color = Color.darkRed;
            Timer.fontSize += Time.deltaTime*5;
        }
        if (Player.time <= 0)
        {
            Timer.color = Color.white;
            Timer.fontSize = DefSize;

        }
    }


    void CountDown()
    {
    }
}
