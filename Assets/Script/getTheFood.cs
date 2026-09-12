using UnityEngine;

public class getTheFood : MonoBehaviour
{
    [SerializeField]private ManagePlayer player;
    [SerializeField] private int score;
    private void Update()
    {
        GameOver();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==6)
        {
            score+=1;
        }
        else
        {
            score-=3;
        }

        Destroy(other.gameObject);
    }
    public int GetScore()
    {
        return score;
    }
    private void GameOver()
    {
        if (score < 0)
        {
            player.GameOver.setGameOver(true);
        }
        else
        {
            Time.timeScale=1f;
        }
    }
}
