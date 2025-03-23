using TMPro;
using UnityEngine;

public class ShieldSystem : MonoBehaviour
{
    [SerializeField] GameObject[] ShieldList;
    private GameObject CurrentShield;
    void Start()
    {
        CurrentShield = Instantiate(ShieldList[Random.Range(0, ShieldList.Length)], this.gameObject.transform.position, this.gameObject.transform.rotation);
        CurrentShield.transform.SetParent(this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        ShieldSpawn();
    }

    void ShieldSpawn()
    {
        if (this.gameObject.transform.childCount == 0)
        {
            CurrentShield = Instantiate(ShieldList[Random.Range(0, ShieldList.Length)], this.gameObject.transform.position, this.gameObject.transform.rotation);
            CurrentShield.transform.SetParent(this.gameObject.transform);
        }
    }
}
