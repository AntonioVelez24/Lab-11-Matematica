using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    [SerializeField] private GameObject highPipePrefab;
    [SerializeField] private GameObject lowPipePrefab;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
