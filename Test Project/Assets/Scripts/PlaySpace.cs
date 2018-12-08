using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpace : MonoBehaviour {
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
            Destroy(other.gameObject);
    }
}
