using UnityEngine;

public class TreeInteract : MonoBehaviour
{

    public GameObject WoodDrop;
    public int chops;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chops = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Wood()
    {
        chops++;
        if (chops >= 3)
        {
            //make stone pickups.
            Instantiate(WoodDrop, transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
            Debug.Log("woody");
        }
    }
}
