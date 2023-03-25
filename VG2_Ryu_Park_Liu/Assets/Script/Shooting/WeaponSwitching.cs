using UnityEngine;
using UnityEngine.InputSystem;


namespace DinoGame{
    public class WeaponSwitching : MonoBehaviour
    {
        public int currentWeapon = 0;
        public static WeaponSwitching instance;
        public bool rifle;
        public bool sniper;
        void Awake()
        {
            instance = this;
            rifle = false;
            sniper = false;
        }
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

            if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && rifle)
            {
                currentWeapon = 1;
            }

            if(Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && sniper)
            {
                currentWeapon = 2;
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