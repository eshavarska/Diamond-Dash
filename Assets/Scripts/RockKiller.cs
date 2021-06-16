using UnityEngine;
using TMPro;
using System.Collections;

public class RockKiller : MonoBehaviour
{
    private GameObject gameOverText;

    private void Start()
    {
        gameOverText = GameObject.Find("GameOver");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit player => player died");
            gameOverText.GetComponent<TextMeshProUGUI>().enabled = true;

            other.gameObject.GetComponent<Animator>().SetTrigger("dies");
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(
                        loseGame());
        }
        else if (other.gameObject.tag == "Spider")
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator loseGame()
    {
        yield return new WaitForSeconds(3);
        ScreenManager.GameOver();
    }
}
