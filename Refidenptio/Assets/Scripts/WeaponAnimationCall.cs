using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{
    public class WeaponAnimationCall : MonoBehaviour
    {
        private WeaponAnimationControl _wAnimControl;
        private WeaponControl _wControl;

        private void Start()
        {
            _wControl = GetComponentInParent<WeaponControl>();
            _wAnimControl = GetComponentInParent<WeaponAnimationControl>();
        }

        public void Atk()
        {
            _wControl.CallShoot();
        }

        public void CanAtk()
        {
            _wAnimControl.atking = false;
        }
    }
}
