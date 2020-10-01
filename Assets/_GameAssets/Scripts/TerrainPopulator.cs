using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPopulator : MonoBehaviour
{
    public GameObject prefab1;
    [Range(0,1000)]
    public int numberOfItems1;
    [Range(0.5f, 2)]
    public float minScale;
    [Range(0.5f, 2)]
    public float maxScale;
    public GameObject populationArea;
    public bool randomRotation;
    [Range(-100,100)]
    public float yOffset=0;
    void Start()
    {
        Vector3 centro = populationArea.GetComponent<Renderer>().bounds.center;
        float xMin = centro.x - populationArea.GetComponent<Renderer>().bounds.size.x / 2;
        float xMax = centro.x + populationArea.GetComponent<Renderer>().bounds.size.x / 2;
        float zMin = centro.z - populationArea.GetComponent<Renderer>().bounds.size.z / 2;
        float zMax = centro.z + populationArea.GetComponent<Renderer>().bounds.size.z / 2;

        for (int i = 0; i<numberOfItems1; i++)
        {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);
            Vector3 vOrigen = new Vector3(x, populationArea.transform.position.y, z);
            Physics.Raycast(vOrigen, Vector3.down, out RaycastHit hitInfo);
            float y = hitInfo.point.y + yOffset;

            Quaternion rotation = Quaternion.identity;
            if (randomRotation)
            {
                rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            }
                

            GameObject newObject = Instantiate(prefab1, new Vector3(x, y, z), rotation);
            float scale = Random.Range(minScale, maxScale);
            newObject.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
