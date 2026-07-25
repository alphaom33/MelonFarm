using JetBrains.Annotations;
using UnityEngine;

public class GrassScript : MonoBehaviour
{

    public GameObject Coin;
    public float coinoffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (Physics.Raycast(transform.position, transform.right, out RaycastHit Righttile))
        {
            if (Righttile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Right");
               GameObject rightplot = Instantiate(Coin, new Vector3(transform.position.x, transform.position.y + coinoffset, transform.position.z), Quaternion.identity);
                rightplot.GetComponent<CoinScript>().OldPlot = this.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, -transform.right, out RaycastHit Lefttile))
        {
            if (Lefttile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Left");
                GameObject leftplot = Instantiate(Coin, new Vector3(transform.position.x, transform.position.y + coinoffset, transform.position.z), Quaternion.identity);
                leftplot.GetComponent<CoinScript>().OldPlot = this.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit Fronttile))
        {
            if (Fronttile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Forward");
                GameObject forwardplot = Instantiate(Coin, new Vector3(transform.position.x, transform.position.y + coinoffset, transform.position.z), Quaternion.identity);
                forwardplot.GetComponent<CoinScript>().OldPlot = this.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit Backtile))
        {
            if (Backtile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Backwards");
                GameObject backplot = Instantiate(Coin, new Vector3(transform.position.x, transform.position.y + coinoffset, transform.position.z), Quaternion.identity);
                backplot.GetComponent<CoinScript>().OldPlot = this.gameObject;
            }
        }

      
     

    }
    public void ScanNextPlots()
    {
        if (Physics.Raycast(transform.position, transform.right, out RaycastHit Righttile))
        {
            if (!Righttile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Right");
                GameObject rightplot = Instantiate(Coin, new Vector3(Righttile.transform.position.x, Righttile.transform.position.y + coinoffset, Righttile.transform.position.z), Quaternion.identity);
                rightplot.GetComponent<CoinScript>().OldPlot = Righttile.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, -transform.right, out RaycastHit Lefttile))
        {
            if (!Lefttile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Left");
                GameObject leftplot = Instantiate(Coin, new Vector3(Lefttile.transform.position.x, Lefttile.transform.position.y + coinoffset, Lefttile.transform.position.z), Quaternion.identity);
                leftplot.GetComponent<CoinScript>().OldPlot = Lefttile.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit Fronttile))
        {
            if (!Fronttile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Forward");
                GameObject forwardplot = Instantiate(Coin, new Vector3(Fronttile.transform.position.x, Fronttile.transform.position.y + coinoffset, Fronttile.transform.position.z), Quaternion.identity);
                forwardplot.GetComponent<CoinScript>().OldPlot = Fronttile.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit Backtile))
        {
            if (!Backtile.collider.gameObject.CompareTag("Farm"))
            {
                Debug.Log("Backwards");
                GameObject backplot = Instantiate(Coin, new Vector3(Backtile.transform.position.x, Backtile.transform.position.y + coinoffset, Backtile.transform.position.z), Quaternion.identity);
                backplot.GetComponent<CoinScript>().OldPlot = Backtile.collider.gameObject;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, transform.right * 5f, Color.red);
        Debug.DrawRay(transform.position, -transform.right * 5f, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
        Debug.DrawRay(transform.position, -transform.forward * 5f, Color.red);
    }
}
