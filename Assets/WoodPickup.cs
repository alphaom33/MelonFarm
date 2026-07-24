using UnityEngine;

public class WoodPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<WatermelonController>() != null)
        {
            Debug.Log("pickup");
            other.gameObject.GetComponentInChildren<Inventory>().Wood++;
            Destroy(this.gameObject);

        }

    }
}
