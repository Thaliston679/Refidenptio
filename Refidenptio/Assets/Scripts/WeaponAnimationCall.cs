using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{
    public class WeaponAnimationCall : MonoBehaviour
    {
        private WeaponAnimationControl _wAnimControl;

        private void Start()
        {
            _wAnimControl = GetComponentInParent<WeaponAnimationControl>();
        }

        public void EndAtk()
        {
            _wAnimControl.atking = false;
        }

        public void Atk()
        {

        }
    }
}
