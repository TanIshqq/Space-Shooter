using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazarCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text resetText;
    public Text gameoverText;
    private bool gameOver;
    private bool restartGame;
    private int score;

    void UpdateScore()
    {

        scoreText.text = "Score : " + score;
    }

    public void AddScore(int newScoreValue){
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver(){
            gameoverText.text = "GAME OVER";
            gameOver = true;
    }
       

    void Start()
	{
        gameOver = false;
        restartGame = false;
        resetText.text = "";
        gameoverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());		
	}

	void Update()
	{
        if(restartGame){
            if(Input.GetKeyDown(KeyCode.R)){
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }


	}


	IEnumerator SpawnWaves() {
        
        yield return new WaitForSeconds(startWait);

        while(true){

            for (int i = 0; i < hazarCount; i++)
            {

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver){
                resetText.text = "Press 'R' to Restart";
                restartGame = true;
                break;
            }
        }

       

        


    }

}
