using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class TerrainPopulator : MonoBehaviour
{
    [SerializeField]
    private bool populate;

    [SerializeField]
    private bool destroy;

    [SerializeField] 
    private GameObject populationArea;

    [SerializeField]
    private TemplateObject[] templateObjects;


    void Awake()
    {
        //Destroy
        if (destroy)
        {
            Transform[] t = GetComponentsInChildren<Transform>();

            foreach (Transform eachTransform in t)
            {
                if (eachTransform.gameObject != this.gameObject)
                {
                    DestroyImmediate(eachTransform.gameObject);
                }
            }
        }

        //Exit
        if (!populate) return;

        //Calculate Area
        Vector3 center = populationArea.GetComponent<Renderer>().bounds.center;
        float xMin = center.x - populationArea.GetComponent<Renderer>().bounds.size.x / 2;
        float xMax = center.x + populationArea.GetComponent<Renderer>().bounds.size.x / 2;
        float zMin = center.z - populationArea.GetComponent<Renderer>().bounds.size.z / 2;
        float zMax = center.z + populationArea.GetComponent<Renderer>().bounds.size.z / 2;

        for (int i = 0; i<templateObjects.Length; i++)
        {
            for (int j=0;j<templateObjects[i].NumberOfItems;j++)
            {
                //Calculate position
                float x = Random.Range(xMin, xMax);
                float z = Random.Range(zMin, zMax);
                Vector3 vOrigen = new Vector3(x, populationArea.transform.position.y, z);
                Physics.Raycast(vOrigen, Vector3.down, out RaycastHit hitInfo);

                //Apply Y offset
                float y = hitInfo.point.y + templateObjects[i].YOffset;

                //Calculate rotation
                float xRotation = templateObjects[i].RandomXRotation ? Random.Range(0, 360) : 0;
                float yRotation = templateObjects[i].RandomYRotation ? Random.Range(0, 360) : 0;
                float zRotation = templateObjects[i].RandomZRotation ? Random.Range(0, 360) : 0;
                Vector3 rotation = new Vector3(xRotation, yRotation, zRotation);

                //Instantiate Object
                GameObject newObject = Instantiate(templateObjects[i].Prefab, new Vector3(x, y, z), Quaternion.Euler(rotation), transform);
                float scale = Random.Range(templateObjects[i].MinScale, templateObjects[i].MaxScale);
                newObject.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }

    
}
