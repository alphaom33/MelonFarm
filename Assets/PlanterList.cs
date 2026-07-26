using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

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
    List<Seed> seeds;
    int offset;
    public FarmPlot plot;
    public Seed uprootSeed;

    Vector3[] initialPositions = new Vector3[7];

    void Start()
    {
        navigate = InputSystem.actions.FindAction("Navigate");
        confirm = InputSystem.actions.FindAction("Submit");
    } 

    void OnEnable()
    {
        offset = 0;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        lerpAmount = GetComponent<RectTransform>().rect.width / 5;

        for (int i = 0; i < 7; i++)
        {
            seedCard = Instantiate(seedCardPrefab, transform);
            seedCard.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lerpAmount);
            initialPositions[i] = new Vector3((i - 3) * lerpAmount, 0, 0);
            seedCard.transform.localPosition = initialPositions[i];
        }

        seeds = GameObject.FindWithTag("Inventory").GetComponent<Inventory>().GetSeeds().ToList();
        if (plot.plant != null)
        {
            seeds.Add(uprootSeed);
        }
        ApplySeeds();
        StartCoroutine(Why());
    }

    IEnumerator Why()
    {
        yield return new WaitForEndOfFrame();
        ApplySeeds();
    }

    private int WrapIndex(int index, int length)
    {
        return (index % length + length) % length;
    }

    private void EnableChildren(Transform transform, bool yes)
    {
        transform.GetChild(1).gameObject.SetActive(yes);
    }

    private void ApplySeeds()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int idx = WrapIndex(i + offset, seeds.Count);
            Transform child = transform.GetChild(i);
            child.GetComponent<SeedCard>().SetSeed(seeds[idx]);
            EnableChildren(child, false);
        }
        Seed selected = transform.GetChild(3).GetComponent<SeedCard>().seed;
        EnableChildren(transform.GetChild(3), true);
        seedName.text = selected.name;
        seedBuff.text = selected.buff;
    }

    public void Update()
    {
        if (navigate.triggered && navigate.ReadValue<Vector2>().x != 0)
        {
            DoNavigate(navigate.ReadValue<Vector2>().x);
        }

        if (confirm.triggered)
        {
            Seed seed = transform.GetChild(3).GetComponent<SeedCard>().seed;

            if (plot.plant != null)
            {
                Inventory playerinv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                playerinv.AddPlant(plot.plant);
                plot.plant.seed.number += plot.plant.seedAmount; 

                Destroy(plot.plant.gameObject);
                plot.plant = null;
            }

            if (seed != uprootSeed) 
            {
                GetComponentInParent<PlanterUI>().SetSeed(seed);
                seed.number--;
            } 
            else
            {
                GetComponentInParent<PlanterUI>().CloseUI();
            }
        }
    }

    IEnumerator doNavigate;
    float direction;

    void DoNavigate(float direction) {
        if (doNavigate != null)
        {
            StopCoroutine(doNavigate);
            offset += (int)this.direction;
            ApplySeeds();
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).position = initialPositions[i];
            }
        }
        doNavigate = DoNavigate();
        StartCoroutine(doNavigate);

        IEnumerator DoNavigate()
        {
            this.direction = direction;
            for (float t = 0; t < 1; t += Time.deltaTime * scrollSpeed)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).localPosition = new Vector3(Mathf.Lerp(initialPositions[i].x, initialPositions[i].x - direction * lerpAmount, t), 0, 0);
                }
                yield return new WaitForEndOfFrame();
            }

            offset += (int)direction;
            ApplySeeds();

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localPosition = initialPositions[i];
            }

            doNavigate = null;
        }
    }

}