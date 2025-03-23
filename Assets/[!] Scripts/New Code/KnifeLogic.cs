using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeLogic : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 50f;
    private bool IsTouchedTarget;
    private bool ShouldMove = false;
    private AudioSource _audioSource;

    [SerializeField] private GameObject LaunchEffect;
    [SerializeField] private GameObject KinfeEffect;
    [SerializeField] private GameObject ExplodeEffect;
    
    [SerializeField] private AudioClip KnifeLaunch;
    [SerializeField] private AudioClip HitSound;

    [SerializeField] private KnifeSpawnLogic KnifeSpawner;
    
    private bool Scored;

    private void Start()
    {
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        KnifeSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<KnifeSpawnLogic>();
    }
    void Update()
    {
        if (!IsTouchedTarget && Input.GetMouseButtonDown(0))
        {
            if (ShouldMove == false) 
            {
                _audioSource.PlayOneShot(KnifeLaunch, Random.Range(0.65f, 1f));
            }
            ShouldMove = true;
            
        }

        if (ShouldMove && !IsTouchedTarget)
        {
            MoveUpFunction();
        }
    }

    private void MoveUpFunction()
    {
        transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsTouchedTarget && other.CompareTag("Shield"))
        {
            IsTouchedTarget = true;
            
            if (IsTouchedTarget == true && KnifeSpawner != null) 
            {
                KnifeSpawner.Score++;
            }

            ShouldMove = false; 
            transform.SetParent(other.transform);
            
            LaunchEffect.SetActive(false);
            KinfeEffect.SetActive(false);
            
            GameObject Effect = Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
            Effect.transform.SetParent(transform);
            _audioSource.PlayOneShot(HitSound, Random.Range(0.65f, 1f));
            Destroy(Effect, 3);
        }
        if (!IsTouchedTarget && other.CompareTag("Knife"))
        {
            SceneManager.LoadScene("Result");
        }
    }
}