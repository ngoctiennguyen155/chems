using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
     // Start is called before the first frame update
     public GameObject bladeTrailPreFab;
     private GameObject currentBladeTrail;
     bool isCutting = false;
     Rigidbody2D rb;
     Camera cam;
     void Start()
     {
          cam = Camera.main;
          rb = GetComponent<Rigidbody2D>();
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
          rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
     }
     void StartCutting()
     {
          isCutting = true;
          currentBladeTrail = Instantiate(bladeTrailPreFab, transform);
     }
     void StopCutting()
     {
          isCutting = false;
          currentBladeTrail.transform.SetParent(null);
          Destroy(currentBladeTrail, 2f);
     }
}
