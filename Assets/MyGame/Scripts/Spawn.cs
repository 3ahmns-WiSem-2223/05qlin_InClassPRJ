using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject targetPrefab;
    private GameObject target;
    private bool wait;

    public float spawnWaitMin;
    public float spawnWaitMax;

    public float waitForClickMin;
    public float waitForClickMax;

    private Vector2 returnVector;

    private void RandomPoint()
    {
        returnVector = UnityEngine.Random.insideUnitCircle * 4;
        target.transform.position = returnVector; 
    }
    public void SpawnTarget()
    {
        GameObject target = Instantiate(targetPrefab) as GameObject;
        target.transform.position = returnVector;
    }
    private void Update()
    {
        if (!wait)
        {
            StartCoroutine(RandomWait());
        }
    }

    public IEnumerator RandomWait()
    {
        wait = true;
        yield return new WaitForSeconds(Random.Range(spawnWaitMin, spawnWaitMax));
        target = Instantiate(targetPrefab) as GameObject;
        RandomPoint();
        yield return new WaitForSeconds(Random.Range(waitForClickMin, waitForClickMax));
        target.SetActive(false);
        wait = false;
    }
}
