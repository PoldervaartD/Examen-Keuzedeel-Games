using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    [SerializeField] private Text cherriesText;
    public bool canMove = true;

    private bool levelCompleted = false;
        private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted && cherriesText.text == "Afval: 4")
        {
            StartCoroutine(completeLevel());
        }
    }
    
    public IEnumerator completeLevel()
    {
        levelCompleted = true;
        canMove = false;
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}