using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class WeaponAnimationControl : MonoBehaviour
    {
        public bool right = false;
        public bool left = false;
        public bool center = true;
        public bool atk = false;
        public bool atking = false;

        public Animator animWP;
        public Animator animWS;

        private void Update()
        {
            right = animWP.GetBool("Right");
            left = animWP.GetBool("Left");
            if (!animWP.GetBool("Left") && !animWP.GetBool("Right"))
            {
                center = true;
            }
            if (animWP.GetBool("Left") || animWP.GetBool("Right"))
            {
                center = false;
            }
            atk = animWP.GetBool("Atk");
            Animations();
        }

        void Animations()
        {
            if (center)
            {
                animWS.SetBool("Right", false);
                animWS.SetBool("Left", false);
                animWP.SetBool("Atk", false);
            }
            else
            {
                if (right)
                {
                    animWS.SetBool("Right", true);
                    if (atk)
                    {
                        if (!atking)
                        {
                            atking = true;
                            animWS.SetTrigger("Atk");
                            animWP.SetBool("Atk", false);
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    animWS.SetBool("Left", true);
                    if (atk)
                    {
                        if (!atking)
                        {
                            atking = true;
                            animWS.SetTrigger("Atk");
                            animWP.SetBool("Atk", false);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        /*void AnimationsLogica()
        {
            if (center)
            {
                Debug.Log("No centro, Desliga Right e Left");
            }
            else
            {
                if (right)
                {
                    Debug.Log("Na direita");
                    if (atk)
                    {
                        Debug.Log("Na direita e podendo atacar");
                        if (!atking)
                        {
                            Debug.Log("Na direita e atacar enquanto n estiver atacando");
                        }
                    }
                    else
                    {
                        Debug.Log("Na direita e enquanto não atacar");
                    }
                }
                else
                {
                    Debug.Log("Na esquerda");
                    if (atk)
                    {
                        Debug.Log("Na esqueda e podendoi atacar");
                        if (!atking)
                        {
                            Debug.Log("Na esquerda e atacar enquanto n estiver atacando");
                        }
                    }
                    else
                    {
                        Debug.Log("Na esquerda e enquanto não atacar");
                    }
                }
            }
        }*/
    }
}
