using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class AnimatorHandler : MonoBehaviour
    {
        public Animator anim;
        int vertical;
        int horizontal;
        public bool canRotate;

        public void Initialize()
        {
            anim = GetComponent<Animator>();
            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizantal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizantalMovement)
        {
            #region Vertical

            float v = 0;

            if (verticalMovement > 0 && verticalMovement < 0.55f)
            {
                v = 0.5f;
            }
            else if(verticalMovement > 0.55f)
            {
                v = 1;
            }
            else if(verticalMovement < 0 && verticalMovement > -0.55f)
            {
                v = -0.5f;
            }
            else if (verticalMovement < -0.55f)
            {
                v = -1;
            }
            else
            {
                v = 0;
            }

            #endregion

            #region Horizontal

            float h = 0;

            if (horizantalMovement > 0f && horizantalMovement < 0.55f)
            {
                h = 0.5f;
            }
            else if (horizantalMovement > 0.55f)
            {
                h = 1;
            }
            else if (horizantalMovement < 0 && horizantalMovement > -0.55f)
            {
                h = -0.5f;
            }
            else if (horizantalMovement < -0.55f)
            {
                h = -1;
            }
            else
            {
                h = 0;
            }

            #endregion

            anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            anim.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
        }

        public void CanRotate()
        {
            canRotate = true;
        }

        public void StopRotation()
        {
            canRotate = false;
        }
    }
}
