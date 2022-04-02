using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityContainer : MonoBehaviour
{
    [SerializeField]
    public GameObject abilityPrefab;

    private GameObject boss;
    private IAbility abilityToUse;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Use()
    {
        abilityToUse = Instantiate(abilityPrefab).GetComponent<IAbility>();
        boss.GetComponent<BossBrain>().Attack();
    }
}
