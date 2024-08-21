using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBall : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(8, 0, 0 * Time.deltaTime);
    }
}
