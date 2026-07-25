using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Vector3 rotateamount;
    public GameObject OldPlot;
    public GameObject Newplot;
    public Inventory playerinv;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateamount * Time.deltaTime);

    }

    public void Buy()
    {
        if (playerinv != null)
        {
            if (playerinv.Money >= playerinv.PlotCost)
            {
                //DO NOT TOUCH THIS PART WITHOUT IT IT BREAKS
                GameObject obj = Instantiate(Newplot, OldPlot.transform.position, Newplot.transform.rotation);
                //DO NOT TOUCH THIS PART WITHOUT IT IT BREAKS
                obj.SetActive(true);
                obj.transform.parent = null;
                playerinv.Money -= playerinv.PlotCost;

               OldPlot.GetComponent<GrassScript>().ScanNextPlots();

                Destroy(OldPlot);
                Destroy(this.gameObject);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<Inventory>() != null) 
        {
            {
                Debug.Log("I see Inv");
                playerinv = other.gameObject.GetComponentInChildren<Inventory>();
                
                
                

            }

        }
    }
}
