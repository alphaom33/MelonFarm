using UnityEngine;

public class AudioSingularity : MonoBehaviour
{
    static bool made;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (made)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            made = true;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position;
    }
}
