using UnityEngine;

public class StoneInteract : MonoBehaviour
{
    public GameObject StoneDrop;
    public int hits;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stone()
    {
      hits++;
        if (hits >= 3)
        {
            //make stone pickups.
            Instantiate(StoneDrop, transform.position, Quaternion.identity);
           
            Destroy(this.gameObject);
            Debug.Log("rocking");
          
        }
        
        
    }
}
