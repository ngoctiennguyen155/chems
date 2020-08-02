using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
     // Start is called before the first frame update
     public GameObject cubePrefab;
     public float speedForce = 7f;
     Rigidbody2D rb;
     void Start()
     {
          rb = GetComponent<Rigidbody2D>();
          rb.AddForce(transform.up * speedForce, ForceMode2D.Impulse);
     }

     // Update is called once per frame
     void Update()
     {

     }
     void OnTriggerEnter2D(Collider2D col)
     {
          if (col.tag == "blade")
          {
               Vector3 direction = (col.transform.position - transform.position).normalized;
               Quaternion rotation = Quaternion.LookRotation(direction);
               Instantiate(cubePrefab, transform.position, rotation);
               Destroy(gameObject);
          }
     }
}
