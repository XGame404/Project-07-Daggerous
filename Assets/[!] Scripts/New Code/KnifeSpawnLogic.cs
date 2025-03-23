using TMPro;
using UnityEngine;

public class KnifeSpawnLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] KnifePrefabs;
    private GameObject Dagger;

    [SerializeField] private TMP_Text ScoreText;
    public int Score;

    public bool Able2SpawnKnife = true;

    [SerializeField] private GameObject Tap2Start;

    void Start()
    {
        Dagger = Instantiate(KnifePrefabs[GameDataManager.GetSelectedChar()], this.gameObject.transform.position, this.gameObject.transform.rotation);
        Dagger.transform.SetParent(this.gameObject.transform);
    }

    void Update()
    {
        KnifeSpawn();
        FirstClickPerform();
        ScoreText.text = $"{Score}";
        GameDataManager.NewestCoinNumbGathered(Score);
    }

    void KnifeSpawn() 
    {
        if (this.gameObject.transform.childCount == 0 && Able2SpawnKnife == true)
        {
            Dagger = Instantiate(KnifePrefabs[GameDataManager.GetSelectedChar()], this.gameObject.transform.position, this.gameObject.transform.rotation);
            Dagger.transform.SetParent(this.gameObject.transform);
        }

        if (Able2SpawnKnife == false && Dagger) 
        {
            Destroy(Dagger);
        }
    }

    public void FirstClickPerform()
    {
        if (Input.GetMouseButtonDown(0) && Tap2Start.activeSelf == true)
        {
            Tap2Start.SetActive(false);
        }
    }
}
