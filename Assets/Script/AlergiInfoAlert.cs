using TMPro;
using UnityEngine;

public class AlergiInfoAlert : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectAlergiUI;
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private ManagePlayer player;
    private CategoryFood category;
    
    private void Update()
    {
        changeTextUI();
    }
    private void changeTextUI()
    {
        category=player.DropSpawnner.categories;

        textUI.text=$"Alergi yang anda miliki adalah <color=#b50b0b> {category}</color>";
        Invoke(nameof(setActiveUI),1.3f);
    }
    private void setActiveUI()
    {
        gameObjectAlergiUI.SetActive(false);
    }
}
