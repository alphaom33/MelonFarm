using System.Data;
using UnityEngine;

public class FarmController : MonoBehaviour
{
    public GameObject farmTile;
    public int rows;
    public int cols;
    public float tileSize;

    public Seed[] seeds;

    void MakeFarm()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3 position = new(i * tileSize, 0, j * tileSize);
                Instantiate(farmTile, transform).transform.localPosition = position;
            }
        }
    }

    // Update is called once per frame
    void Start()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        MakeFarm();
    }

    public Seed[] GetSeeds() => seeds;
}
