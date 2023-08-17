using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToCreate;
    [SerializeField] private Transform spawn;
    void Start()
    {
        Instantiate(objectToCreate, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
