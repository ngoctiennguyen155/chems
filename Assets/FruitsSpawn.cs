using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawn : MonoBehaviour
{
     // Start is called before the first frame update
     public GameObject fruitPrefab;
     public Transform[] spawnPoints;
     public float minDelay = .1f;
     public float maxDelay = 1f;
     void Start()
     {
          StartCoroutine(SpawnFruits());
     }

     // Update is called once per frame
     void Update()
     {

     }
     IEnumerator SpawnFruits()
     {
          while (true)
          {
               float delay = Random.Range(minDelay, maxDelay);
               yield return new WaitForSeconds(delay);

               int spawnIndex = Random.Range(0, spawnPoints.Length);
               Transform spawnPoint = spawnPoints[spawnIndex];

               GameObject spanwertemp = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
               Destroy(spanwertemp, 5f);
          }
     }
}
