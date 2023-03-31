using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject[] prefabs;
    //private GameObject prefab1;
    //private GameObject prefab2;
    public List<GameObject> instPrefab;
    public int nSegmentos = 2;
    public int prefabNum = 0;
    void Start()
    {
        instPrefab = new List<GameObject>();
        DontDestroyOnLoad(this.gameObject);
        BuildWorld();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            BuildWorld();
        }
    }
    private void BuildWorld()
    {
        ///Generacion de mundo usando carga de escenas
        //SceneManager.LoadScene(Random.Range(1, 5), LoadSceneMode.Single);
        //SceneManager.LoadScene(Random.Range(1, 5), LoadSceneMode.Additive);

        //Generacion de mundo usando prefabs
        //Destroy(prefab1);
        //Destroy(prefab2);
        /*prefab1 = null;
        prefab2 = null;*/
        for (int i = 0; i <= nSegmentos; i++)
        {
            instPrefab.Add(prefabs[UnityEngine.Random.Range(0, prefabs.Length)]);
        }

        foreach(GameObject prefab in instPrefab)
        {
            if (prefabNum == 0)
            {
                Instantiate(prefab,
                        Vector3.zero,
                        Quaternion.identity);
                prefabNum++;
            }else
            {
                Instantiate(prefab,
                        Vector3.right * 20 * prefabNum,
                        Quaternion.identity);
                prefabNum++;
            }
                
        }
        /*prefab1 = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)],
                    Vector3.zero,
                    Quaternion.identity);
        prefab2 = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)],
                    Vector3.right *20f,
                    Quaternion.identity);*/
    }
}
