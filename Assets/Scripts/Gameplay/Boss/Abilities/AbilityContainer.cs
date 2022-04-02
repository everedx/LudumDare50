using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject abilityPrefab;

    private IAbility abilityToUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (abilityToUse != null)
        {
            abilityToUse.Use();
            abilityToUse = null;
        }
    }
    
    public void Use()
    {
        abilityToUse = Instantiate(abilityPrefab).GetComponent<IAbility>();
    }
}
