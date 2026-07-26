using JetBrains.Annotations;
using UnityEngine;

public class GrassScript : MonoBehaviour
{

    public GameObject Coin;
    public float coinoffset;
    public bool coined;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScanPlotInitial(transform.right);
        ScanPlotInitial(-transform.right);
        ScanPlotInitial(transform.forward);
        ScanPlotInitial(-transform.forward);
    }

    private void MakeCoin(GameObject parent)
    {
        GameObject coin = Instantiate(Coin, new Vector3(parent.transform.position.x, parent.transform.position.y + coinoffset, parent.transform.position.z), Quaternion.identity);
        coin.GetComponent<CoinScript>().OldPlot = parent;
        parent.GetComponent<GrassScript>().coined = true;
    }

    private void ScanPlotInitial(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, LayerMask.GetMask("Ground"))
            && hit.collider.gameObject.CompareTag("Farm"))
        {
            MakeCoin(gameObject);
        }
    }

    private void ScanPlot(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, LayerMask.GetMask("Ground"))
            && !hit.collider.gameObject.CompareTag("Farm")
            && !hit.collider.gameObject.GetComponent<GrassScript>().coined)
        {
            MakeCoin(hit.collider.gameObject);
        }
    }

    public void ScanNextPlots()
    {
        ScanPlot(Vector3.right);
        ScanPlot(-Vector3.right);
        ScanPlot(Vector3.forward);
        ScanPlot(-Vector3.forward);
    }
}
