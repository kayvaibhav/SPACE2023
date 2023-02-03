using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private GameController gameController;

    [SerializeField] private GameObject popupCanvas;
    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void AsteroidDestroyed()
    {
        //instantiate explosion
        Instantiate(asteroidExplosion, transform.position, transform.rotation);
        if (GameController.currentGameStatus == GameController.GameState.Playing)
        {
            //calculate the score for hitting the asteroid
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);

            int bonusPoints = (int)(distanceFromPlayer);

            int asteroidScore = 10 * bonusPoints;


            //instantiate the score popup
            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();

            //set the text of the popup
            GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, transform.rotation);

            //adjust the scale of the popup
            asteroidPopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10), transform.localScale.y * (distanceFromPlayer / 10), transform.localScale.z * (distanceFromPlayer / 10));
            //update the score
            gameController.UpdatePlayerScore(asteroidScore);
        }

        //destroy asteroid 
        Destroy(this.gameObject);
    }
}
