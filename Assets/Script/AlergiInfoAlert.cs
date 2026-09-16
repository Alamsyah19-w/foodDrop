using TMPro;
using UnityEngine;

public class AlergiInfoAlert : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectAlergiUI;
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private ManagePlayer player;
    private CategoryFood category;
    private bool alergiActive=true;
    private void Update()
    {
        changeTextUI();
    }
    private void changeTextUI()
    {
        category=player.DropSpawnner.categories;

        textUI.text="Alergi yang anda miliki adalah "+category.ToString();
        Invoke(nameof(setActiveUI),1f);
    }
    private void setActiveUI()
    {
        gameObjectAlergiUI.SetActive(false);
    }
}
