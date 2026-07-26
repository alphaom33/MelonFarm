using UnityEngine;

public class WoodPickup : MonoBehaviour
{


    public Vector3 rotateamount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateamount * Time.deltaTime);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<WatermelonController>() != null)
        {
            other.gameObject.GetComponentInChildren<Inventory>().Wood++;
            Destroy(gameObject);

        }

    }
}
