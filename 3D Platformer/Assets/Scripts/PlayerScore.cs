using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public int coins;
    public int hearts;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI heartText;
    public GameObject characterModel;
    Rigidbody rb;
    Collider col;
    public ParticleSystem deathParticles;
    Vector3 checkPoint;
    void Start()
    {
        col = GetComponent<Collider>();
        coinText.text = coins.ToString("D2");
        heartText.text = hearts.ToString("D2");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject, 0.1f);
            coins++;
            coinText.text = coins.ToString("D2");
        }
        if (other.gameObject.CompareTag("Damage"))
        {
            StartCoroutine(Death());
        }
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            checkPoint = other.transform.position;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            StartCoroutine(Death());
        }
    }
    public IEnumerator Death()
    {
        Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
        hearts--;
        characterModel.SetActive(false);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.freezeRotation = true;
        col.enabled = false;
        yield return new WaitForSeconds(1);
        heartText.text = hearts.ToString("D2");
        if (hearts >= 0)
        {
            Respawn();
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
    public void StartDeath()
    {
        StartCoroutine(Death());
    }
    public void Respawn()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.freezeRotation = true;
        col.enabled = true;
        characterModel.SetActive (true);
        transform.position = checkPoint;
    }
}
