using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Linq;

public class PlanterList : MonoBehaviour
{
    GameObject seedCard;
    public TMP_Text seedName;
    public TMP_Text seedBuff;

    InputAction navigate;
    InputAction confirm;
    public float scrollSpeed = 5f;
    public float lerpAmount;
    public GameObject seedCardPrefab;
    Seed[] seeds;
    int offset;

    void Start()
    {
        navigate = InputSystem.actions.FindAction("Navigate");
        confirm = InputSystem.actions.FindAction("Submit");
    } 

    void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 7; i++)
        {
            seedCard = Instantiate(seedCardPrefab, transform);
            seedCard.transform.localPosition = new Vector3((i - 3) * lerpAmount, 0, 0);
        }

        seeds = GameObject.FindWithTag("Inventory").GetComponent<Inventory>().GetSeeds();
        ApplySeeds();
    }

    private int WrapIndex(int index, int length)
    {
        return (index % length + length) % length;
    }

    private void ApplySeeds()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int idx = WrapIndex(i + offset, seeds.Length);
            Seed seed = seeds[idx];
            Transform child = transform.GetChild(i);
            child.GetComponent<SeedCard>().SetSeed(seed);
        }
        Seed selected = transform.GetChild(3).GetComponent<SeedCard>().seed;
        seedName.text = selected.name;
        seedBuff.text = selected.buff;
    }

    public void Update()
    {
        if (navigate.triggered && navigate.ReadValue<Vector2>().x != 0)
        {
            StartCoroutine(DoNavigate(navigate.ReadValue<Vector2>().x));
        }

        if (confirm.triggered)
        {
            Seed seed = GetComponentInChildren<SeedCard>().seed;
            GetComponentInParent<PlanterUI>().SetSeed(seed);
            seed.number--;
        }
    }

    IEnumerator DoNavigate(float direction)
    {
        Vector3[] initialPositions = (from Transform child in transform select child.localPosition).ToArray();
        for (float t = 0; t < 1; t += Time.deltaTime * scrollSpeed)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localPosition = new Vector3(Mathf.Lerp(initialPositions[i].x, initialPositions[i].x + direction * lerpAmount, t), 0, 0);
            }
            yield return new WaitForEndOfFrame();
        }

        offset -= (int)direction;
        ApplySeeds();

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = initialPositions[i];
        }
    }
}
