using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TMP_Text))]
public class DeathTimer : MonoBehaviour
{
    TMP_Text timer;
    float time;
    public float startTime = 200;

    // Update is called once per frame
    void Start()
    {
        ResetTime();
        timer = GetComponent<TMP_Text>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timer.text = Mathf.Round(time).ToString();

        if (time < 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    public void ResetTime()
    {
        time = startTime;
    }
}
