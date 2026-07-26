using UnityEngine;

public class PlotScript : MonoBehaviour
{
    public Vector3 rotateamount;
    public GameObject OldPlot;
    public GameObject Newplot;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateamount * Time.deltaTime);
    }

    public void Buy()
    {
        Inventory playerinv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

        if (playerinv.Stone >= 1)
        {
            playerinv.Stone--;

            OldPlot.GetComponent<FarmgrassScript>().ScanNextPlots();
            Destroy(OldPlot);
            Destroy(gameObject);

            GameObject obj = Instantiate(Newplot, OldPlot.transform.position, Newplot.transform.rotation);

            obj.SetActive(true);
            obj.transform.parent = null;
        }
    }
}
