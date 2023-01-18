using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    public static WaterManager instance;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    [SerializeField] private GameObject water;
    [SerializeField] public float waterDecrease;

    //private Vector3 resetPosition = new Vector3(29.25f, 4.79f, -23.4f);

    private void Awake()
    {
        instance = this;
        water = this.gameObject;
        meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
    public void SinkWater()
    {
        water.transform.position = water.transform.position - new Vector3(0, waterDecrease, 0);
    }
   
}
