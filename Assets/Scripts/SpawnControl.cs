using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject highPipePrefab;
    [SerializeField] private GameObject lowPipePrefab;
    private bool spawnObstacles = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTubesCoroutine());
    }
    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator SpawnTubesCoroutine()
    {
        while (spawnObstacles == true)
        {
            SpawnPipes();
            yield return new WaitForSeconds(2f);
        }
    }
    private void SpawnPipes()
    {
        float position = Random.Range(9, 20);
        Vector3 highObstaclePosition = new Vector3(transform.position.x, position, transform.position.z);
        Vector3 lowObstaclePosition = new Vector3(transform.position.x, position - 25, transform.position.z);
        Instantiate(highPipePrefab, highObstaclePosition, Quaternion.identity);
        Instantiate(lowPipePrefab, lowObstaclePosition, Quaternion.identity);
    }
}