using UnityEngine;

public class getTheFood : MonoBehaviour
{
    [SerializeField] private int score;
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
}
