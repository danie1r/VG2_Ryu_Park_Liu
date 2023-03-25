using UnityEngine;
using UnityEngine.InputSystem;


namespace DinoGame{
    public class WeaponSwitching : MonoBehaviour
    {
        public int currentWeapon = 0;
        // Start is called before the first frame update
        void Start()
        {
            SelectWeapon();
        }

        // Update is called once per frame
        void Update()
        {
            int previousWeapon = currentWeapon;

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = 0;
            }

            if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                currentWeapon = 1;
            }

            if(previousWeapon != currentWeapon)
            {
                SelectWeapon();
            }
        }

        void SelectWeapon()
        {
            int i = 0;
            foreach(Transform weapon in transform)
            {
                if(i == currentWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
                i++;
            }
        }
    }
}