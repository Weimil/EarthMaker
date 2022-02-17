using Level.WorldStuff;
using LoadManagement;
using UnityEngine;

public class EarthMaker : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<World>();
        gameObject.AddComponent<LoadServer>();
    }

    private void Start()
    {
        GameObject.FindWithTag("Player").AddComponent<LoadClient>().Init(GetComponent<LoadServer>());
    }
}