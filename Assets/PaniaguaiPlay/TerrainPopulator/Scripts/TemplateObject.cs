using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PaniaguaIPLay/Terrain Populator/Template Object", order = 1)]
public class TemplateObject : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    [Range(0, 1000)]
    private int numberOfItems;

    [SerializeField]
    [Range(0, 100)]
    private float minScale;

    [SerializeField]
    [Range(0f, 100)]
    private float maxScale;

    [SerializeField]
    [Range(-100, 100)]
    private float yOffset = 0;

    [SerializeField]
    private bool randomXRotation;

    [SerializeField]
    private bool randomYRotation;

    [SerializeField]
    private bool randomZRotation;

    public GameObject Prefab { get => prefab; set => prefab = value; }
    public int NumberOfItems { get => numberOfItems; set => numberOfItems = value; }
    public float MinScale { get => minScale; set => minScale = value; }
    public float MaxScale { get => maxScale; set => maxScale = value; }
    public float YOffset { get => yOffset; set => yOffset = value; }
    public bool RandomXRotation { get => randomXRotation; set => randomXRotation = value; }
    public bool RandomYRotation { get => randomYRotation; set => randomYRotation = value; }
    public bool RandomZRotation { get => randomZRotation; set => randomZRotation = value; }
}
