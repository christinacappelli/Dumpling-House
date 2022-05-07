using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject dumpling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("GameScene");
        }
        if (Time.frameCount % 850 == 0)
        {
            audioSource.Play();
            Instantiate(dumpling, new Vector3(Mathf.RoundToInt(Random.Range(-7, 6)), Mathf.RoundToInt(Random.Range(-4,3)),0), Quaternion.identity);
            float scale = Random.Range(0.3f, 0.8f);
        }
    }
}
