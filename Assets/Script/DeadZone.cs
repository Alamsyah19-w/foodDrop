using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private ManagePlayer player;
    [SerializeField] private int minScore=1;
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.layer==6)
        {
            player.GetFood.SetScore(minScore);
        }
        
    }
}
