using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlood : MonoBehaviour
{
    
    [Range(.2f, 1)] public float min_scale = .2f;
    [Range(.2f, 1)] public float max_scale = 1;

    [Range(0, 360)] public float min_rotation = 0;
    [Range(0, 360)] public float max_rotation = 360;

    Projector projector;
    void Awake()
    {
        projector = GetComponent<Projector>();
    }
	
    void Start()
    {
        float randomScale = Random.Range(min_scale, max_scale);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        float randomRotation = Random.Range(min_rotation, max_rotation);
        transform.localRotation=Quaternion.Euler(0, randomRotation, 0);
    }
    
    void Update()
    {
        
    }
}
