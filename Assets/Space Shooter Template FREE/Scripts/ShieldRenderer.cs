using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRenderer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Player>().shield <= 0)
		{
            var a = GetComponent<Player>().transform.Find("Shield");
            a.gameObject.SetActive(false);
            
		}
    }
}
