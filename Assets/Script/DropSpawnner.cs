using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropSpawnner : MonoBehaviour
{
    [SerializeField] private GameObject[] FoodObjects;
    [SerializeField] private GameObject[] alergiObjects;
    [SerializeField] private AlergiFoodScritable[]  alergiFoodTheme;
    
    [SerializeField] private float speedDrop=3f;
    [SerializeField] private float destroyYThreshold = -6f;
    
    private List <GameObject> safeFood =new List<GameObject>();
    private AlergiFoodScritable AlergiThemeInGame;

    
    private GameObject spawnObjects;
    private GameObject objectToSpawn;

    private Vector3 startPosition;
    private Vector3 positionX;
    private int objectLayer;
    private int foodLayer=6;
    private int alergiLayer=7;
    private bool isPlay=true;

    public CategoryFood categories=>AlergiThemeInGame.category;

 
    private void Start() {
        addThemeEnemy();
        addEnemyObjects();

        filterFood();
        StartCoroutine(spawnFoodObjects());
        
    }
    private void addThemeEnemy()
    {
        int randomIndex = Random.Range(0, alergiFoodTheme.Length);

        AlergiThemeInGame = alergiFoodTheme[randomIndex];
        
    }
    private void addEnemyObjects()
    {
        alergiObjects= new GameObject[AlergiThemeInGame.prefabs.Length];
        for(int i = 0; i < AlergiThemeInGame.prefabs.Length; i++)
        {
            alergiObjects[i]=AlergiThemeInGame.prefabs[i];
        }
    }
    private  void filterFood()
    {
        foreach (GameObject food in FoodObjects)
        {
            if (!alergiObjects.Contains(food))
            {
                safeFood.Add(food);
            }
        }
    }
    IEnumerator spawnFoodObjects()
    {
        while(isPlay){

            randomXPosition();
    
            bool spawnAlergi = Random.value < 0.3f;

            if (spawnAlergi)
            {
                int randomIndex = Random.Range(0, alergiObjects.Length);
                objectToSpawn= alergiObjects[randomIndex];
                objectLayer=alergiLayer;
            }
            else
            {
                int randomIndex= Random.Range(0,safeFood.Count);
                objectToSpawn=safeFood[randomIndex];
                objectLayer=foodLayer;
            }

            spawnObjects = Instantiate(objectToSpawn,startPosition,Quaternion.identity);
            spawnObjects.layer=objectLayer;

            StartCoroutine(DropObject(spawnObjects));
        

            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator DropObject(GameObject obj)
    {
        while (obj != null && obj.transform.position.y > destroyYThreshold)
        {
            obj.transform.position += Vector3.down * speedDrop * Time.deltaTime;

            yield return null;
        }
    }

    private void randomXPosition()
    {
        positionX.x=Random.Range(-4.3f, 5.3f);
        startPosition= new Vector3(positionX.x ,7,transform.position.z);
    }
    
}
