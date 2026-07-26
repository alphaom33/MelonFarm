using System.Reflection.PortableExecutable;
using UnityEngine;

public class FarmgrassScript : MonoBehaviour
{

    public GameObject Rake;
    public float rakeoffset;
    public bool Plotable;
    public bool Dirt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScanPlotInitial(transform.right);
        ScanPlotInitial(-transform.right);
        ScanPlotInitial(transform.forward);
        ScanPlotInitial(-transform.forward);
        Dirt = false;
    }

    private void MakeRake(GameObject parent)
    {
        GameObject rake = Instantiate(Rake, new Vector3(parent.transform.position.x, parent.transform.position.y + rakeoffset, parent.transform.position.z), Quaternion.identity);
        rake.GetComponent<PlotScript>().OldPlot = parent;
        parent.GetComponent<FarmgrassScript>().Plotable = true;
    }

    private void ScanPlotInitial(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, LayerMask.GetMask("Ground"))
            && hit.collider.gameObject.GetComponent<FarmPlot>() != null)
        {
            MakeRake(gameObject);
        }
    }

    private void ScanPlot(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, LayerMask.GetMask("Ground"))
            && hit.collider.gameObject.GetComponent<FarmPlot>() == null
            && !hit.collider.gameObject.GetComponent<FarmgrassScript>().Plotable)

        {

            MakeRake(hit.collider.gameObject);
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
