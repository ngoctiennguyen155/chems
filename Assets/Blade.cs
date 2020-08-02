using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
     // Start is called before the first frame update
     public GameObject bladeTrailPreFab;
     private GameObject currentBladeTrail;
     float minCutting = 0.001f;
     Vector2 previousPosition, newPosition;
     bool isCutting = false;
     Rigidbody2D rb;
     Camera cam;
     CircleCollider2D circleCollider;
     void Start()
     {
          cam = Camera.main;
          rb = GetComponent<Rigidbody2D>();
          circleCollider = GetComponent<CircleCollider2D>();
     }

     // Update is called once per frame
     void Update()
     {
          if (Input.GetMouseButtonDown(0))
          {
               StartCutting();
          }
          else if (Input.GetMouseButtonUp(0))
          {
               StopCutting();
          }
          if (isCutting)
          {
               UpdateCutting();
          }
     }
     void UpdateCutting()
     {
          newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
          rb.position = newPosition;
          float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
          if (velocity > minCutting)
          {
               circleCollider.enabled = true;
          }
          else
          {
               circleCollider.enabled = false;
          }
          previousPosition = newPosition;
     }
     void StartCutting()
     {
          isCutting = true;
          currentBladeTrail = Instantiate(bladeTrailPreFab, transform);
          circleCollider.enabled = false;
     }
     void StopCutting()
     {
          isCutting = false;
          currentBladeTrail.transform.SetParent(null);
          Destroy(currentBladeTrail, 2f);
          circleCollider.enabled = false;
     }
}
