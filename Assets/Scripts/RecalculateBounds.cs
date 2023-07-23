using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecalculateBounds : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.RecalculateBounds();
    }
}
