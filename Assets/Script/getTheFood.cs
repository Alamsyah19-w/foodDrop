using UnityEngine;

public class getTheFood : MonoBehaviour
{
    [SerializeField] private int Score;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==6)
        {
            Score+=1;
        }
        else
        {
            Score-=3;
        }

        Destroy(other.gameObject);
    }
}
