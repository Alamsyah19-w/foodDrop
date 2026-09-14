using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    [SerializeField] private DropSpawnner dropSpawnner;
    [SerializeField] private getTheFood getTheFood;
    [SerializeField] private MovementPlayer movementPlayer;
    [SerializeField] private GameOver gameOver;

    public GameOver GameOver=>gameOver;
    public getTheFood GetFood=>getTheFood;

    
}
