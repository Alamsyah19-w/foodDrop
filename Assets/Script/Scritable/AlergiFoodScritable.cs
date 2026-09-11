using UnityEngine;

public enum CategoryFood
{
    Mashroom,
    Spice,
    Sweet,
    Chocolate
}
[CreateAssetMenu(menuName = "AlergiFoodScritable")]
public class AlergiFoodScritable : ScriptableObject
{
    public GameObject[] prefabs;
    public CategoryFood category;
}

