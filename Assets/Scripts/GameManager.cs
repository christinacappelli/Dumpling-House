using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        StartCoroutine(wait());
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}
