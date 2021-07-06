using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundShape : MonoBehaviour
{
    [SerializeField]
    public Mesh man;//0
    [SerializeField]
    public Mesh cat;//1
    [SerializeField]
    public Mesh ok;//2
    [SerializeField]
    public Mesh ng;//3
    [SerializeField]
    public Mesh quetion;//4
    [SerializeField]
    public Mesh snow;//5
    [SerializeField]
    public Mesh star;//6
    [SerializeField]
    public GameObject manPrefab;
    [SerializeField]
    public int test;

    public int nowMeshNum;
    MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        nowMeshNum = 0;
        meshFilter = manPrefab.GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (test != nowMeshNum)
        {
            ChangeMesh(test);
            Debug.Log("Change mesh");
        }
    }

    void ChangeMesh(int value)
    {
        if (value != nowMeshNum)
        {
            nowMeshNum = value;
            if (value == 0)
            {
                meshFilter.mesh = man;
            }
            else if (value == 1)
            {
                meshFilter.mesh = cat;
            }
            else if (value == 2)
            {
                meshFilter.mesh = ok;
            }
            else if (value == 3)
            {
                meshFilter.mesh = ng;
            }
            else if (value == 4)
            {
                meshFilter.mesh = quetion;
            }
            else if (value == 5)
            {
                meshFilter.mesh = snow;
            }
            else if (value == 6)
            {
                meshFilter.mesh = star;
            }
        }
    }
}
