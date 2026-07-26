using UnityEngine;

public class TimerAdd : MonoBehaviour
{
    public Vector3 rotateamount;
    public int UpgradeAmmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateamount * Time.deltaTime);
    }


    public void BuyTime()
    {
        Inventory playerinv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        if (playerinv.Stone >= 1)
        {
            playerinv.Wood--;
            playerinv.GetComponentInParent<WatermelonController>().seconds += UpgradeAmmount;

            
        }

    }
}
