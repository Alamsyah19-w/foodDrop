using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] getTheFood scoreValue;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text=scoreValue.GetScore().ToString();
        
    }

}
