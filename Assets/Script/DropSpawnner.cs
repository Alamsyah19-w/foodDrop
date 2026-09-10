using System.Collections;
using System.Linq;
using UnityEngine;

public class DropSpawnner : MonoBehaviour
{
    [SerializeField] private GameObject[] FoodObjects;
    [SerializeField]private GameObject[] alergiObjects;
    [SerializeField]private AlergiFoodScritable[]  alergiFoodTheme;
    
    [SerializeField] private float speedDrop=3f;
    
    private GameObject[] safeFood;
    private AlergiFoodScritable AlergiThemeInGame;

    private GameObject spawnFoodObject;
    private GameObject spawnAlergiObject;
    private Vector3 startPosition;
    private Vector3 positionX;
    private string gameObjectLayerMask="ScorePlus";
    private string enemyLayerMask="ScoreMin";
    private bool isPlay=true;

 
    private void Start() {
        
        addThemeEnemy();
        addEnemyObjects();

        safeFood = FoodObjects.Where(f=>!alergiObjects.Contains(f)).ToArray();
        if (safeFood.Length == 0)
        {
            Debug.LogError("Semua FoodObjects overlap dengan tema alergi aktif — tidak ada makanan aman untuk di-spawn!");
            safeFood = FoodObjects; // fallback biar tidak crash
        }

        StartCoroutine(spawnFoodObjects());
        StartCoroutine(spawnAlergiObjects());
        
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

    IEnumerator spawnFoodObjects()
    {
  
        while(isPlay){
            randomXPosition();

            int randomIndex = Random.Range(0, FoodObjects.Length);

            spawnFoodObject = Instantiate(FoodObjects[randomIndex],startPosition,Quaternion.identity);

            spawnFoodObject.layer=LayerMask.NameToLayer(gameObjectLayerMask);

            

            StartCoroutine(DropObject(spawnFoodObject));
  
            yield return new WaitForSeconds(1.5f);
        }


        
    }
    IEnumerator spawnAlergiObjects()
    {
        while(isPlay){
            randomXPosition();
            
            //set random number urut for the food
            int randomIndex = Random.Range(0, alergiObjects.Length);

            spawnAlergiObject = Instantiate(alergiObjects[randomIndex],startPosition,Quaternion.identity);

            //set Layer
            spawnAlergiObject.layer=LayerMask.NameToLayer(enemyLayerMask);
            

            StartCoroutine(DropObject(spawnAlergiObject));
            
  
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator DropObject(GameObject obj)
    {
        while (obj != null)
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
    // private void checklayerScore(GameObject obj)
    // {
    //     if(obj.layer !=6 && obj.layer != 7) return;
    // }
    
}
