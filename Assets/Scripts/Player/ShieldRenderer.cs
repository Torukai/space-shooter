using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRenderer : MonoBehaviour
{
	public float maxShield;
	public int currentShield;
    public GameObject shield;
    public bool isAlive = true;
	public float recovery;

	private void Start()
	{
		maxShield = gameObject.GetComponent<Player>().shield;
		recovery = gameObject.GetComponent<Player>().shieldRecoverySpeed;
        StartCoroutine(ShieldRecovery());
    }

	void Update()
    {
        if (GetComponent<Player>().shield <= 0)
		{
            var a = GetComponent<Player>().transform.Find("Shield");
            a.gameObject.SetActive(false);
		} 
        else if (GetComponent<Player>().shield >=0 && !shield.activeSelf)
		{
            var a = GetComponent<Player>().transform.Find("Shield");
            a.gameObject.SetActive(true);
        }
    }

    IEnumerator ShieldRecovery()
    {
        while (isAlive)
        {
            if (gameObject.GetComponent<Player>().shield < maxShield)
			{
                gameObject.GetComponent<Player>().shield += recovery;
                //Debug.Log("+ 1");
            }
            yield return new WaitForSeconds(1);
        }
    }
}
