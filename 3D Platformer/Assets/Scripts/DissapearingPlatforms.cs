using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingPlatforms : MonoBehaviour
{
    MeshRenderer mr;
    Collider col;
    PlayerMovement pm;
    void Start()
    {
        gameObject.layer = 3;
        mr = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        GameObject playerMovementObject = GameObject.Find("Player");
        pm = playerMovementObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && pm.isGrounded)
        {
            StartCoroutine(Dissappear());
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && pm.isGrounded)
        {
           StopCoroutine(Dissappear());
        }
    }
    IEnumerator Dissappear()
    {
        yield return new WaitForSeconds(1);
        Shake();
        yield return new WaitForSeconds(2);
        mr.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(2);
        mr.enabled = true;
        col.enabled = true;
    }
    public void Shake()
    {
        Camera.main.GetComponent<ScreenShake>().Shake();
    }
}
