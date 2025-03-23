using TMPro;
using UnityEngine;

public class ShieldLogic : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 100f;
    public int KnifesShieldCanHold;
    public int CurrentKnifeLeft;
    [SerializeField] private TMP_Text KnifeNumb;
    [SerializeField] private GameObject[] Spikes;
    [SerializeField] private GameObject ExplodeEffect;
    private bool IsExploded = false;
    private AudioSource audioSource;
    [SerializeField] private AudioClip ExplodeSound;
    private KnifeSpawnLogic knifeSpawner;

    private void Awake()
    {
        knifeSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<KnifeSpawnLogic>();
    }
    void Start()
    {
        KnifesShieldCanHold = Random.Range(8, 13);
        CurrentKnifeLeft = KnifesShieldCanHold;
        audioSource = this.gameObject.AddComponent<AudioSource>();

        if (knifeSpawner) 
        {
            knifeSpawner.Able2SpawnKnife = true;
        }

        foreach (GameObject spike in Spikes)
        {
            spike.SetActive(Random.Range(0, 2) == 1);
        }

        if (Random.Range(0, 2) == 1)
        {
            MoveSpeed *= -1;
        }

        MoveSpeed *= Random.Range(1f, 1.5f);
    }

    void Update()
    {
        RotateFunction();
        UpdateKnifeCount();
        CheckShieldDestruction();
    }

    private void RotateFunction()
    {
        transform.Rotate(new Vector3(0, 0, MoveSpeed * Time.deltaTime), Space.Self);
    }

    private void UpdateKnifeCount()
    {
        KnifeLogic[] knivesInShield = GetComponentsInChildren<KnifeLogic>();
        CurrentKnifeLeft = KnifesShieldCanHold - knivesInShield.Length;
        KnifeNumb.text = CurrentKnifeLeft.ToString();
    }

    private void CheckShieldDestruction()
    {
        if (CurrentKnifeLeft == 0 && !IsExploded)
        {
            if (knifeSpawner)
            {
                knifeSpawner.Able2SpawnKnife = false;
            }

            transform.localScale = Vector3.zero;
            GameObject explosion = Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(ExplodeSound);
            Destroy(explosion, 1.5f);
            IsExploded = true;
            Destroy(gameObject, 1.75f);
        }
    }
}