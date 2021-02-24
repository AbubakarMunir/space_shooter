using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Hazard;
    public Vector3 spawnvalue;
    public int hazardcount;
    public float spawnwait;
    public float startwait;
    public float wavewait;
    public UnityEngine.UI.Text scoretext;
    public UnityEngine.UI.Text restarttext;
    public UnityEngine.UI.Text GOtext;

    private bool gameover;
    private bool restart;
    private int score;
    void Start()
    {
        gameover = false;
        restart = false;
        GOtext.text = " ";
        restarttext.text = " ";
        score = 0;
        updateScore();
        StartCoroutine(spawnwaves());
    }

    void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    IEnumerator spawnwaves()
    {
        yield return new WaitForSeconds(startwait);
        while(true)
        {
            for (int i = 0; i < hazardcount; i++)
            {
                Vector3 spawnposition = new Vector3(Random.Range(-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);
                Quaternion spawnrotation = Quaternion.identity;
                Instantiate(Hazard, spawnposition, spawnrotation);
                yield return new WaitForSeconds(spawnwait);
            }
            yield return new WaitForSeconds(wavewait);
            if(gameover)
            {
                restart = true;
                restarttext.text = "Press 'R' to Restart";
                break;
            }
        }
        
        
    }

    public void addscore(int s)
    {
        score +=s;
        updateScore();
    }
    void updateScore()
    {
        scoretext.text= "score: " + score.ToString();
    }

    public void GameOver()
    {
        GOtext.text = "GAME OVER";
        gameover = true;
    }
    
}
