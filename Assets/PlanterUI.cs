using UnityEngine;

public class PlanterUI : MonoBehaviour
{
    public void OpenUI()
    {
        gameObject.SetActive(true);
        transform.LookAt(Camera.main.transform);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
