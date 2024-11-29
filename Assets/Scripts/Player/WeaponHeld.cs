using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHeld : MonoBehaviour
{
    [SerializeField] private Transform handTransform;

    [SerializeField] private List<Weapon> Weapons = new List<Weapon>();

    private Weapon _holdingWeapon;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoldWeapon(int index)
    {
        clearhand();
        if(index>=Weapons.Count) return;
        _holdingWeapon = Instantiate(Weapons[index], handTransform);
    }

    public void clearhand()
    {
        if (_holdingWeapon == null)return;
        Destroy(_holdingWeapon.gameObject);
        _holdingWeapon = null;
    }
}
