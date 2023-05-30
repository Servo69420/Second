using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    Collider coli;
    // Start is called before the first frame update
    void Start()
    {
        coli = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
          SceneManager.LoadScene("level1");
       }
    }

