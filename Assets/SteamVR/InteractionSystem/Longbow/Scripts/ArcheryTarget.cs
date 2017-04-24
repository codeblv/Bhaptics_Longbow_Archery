//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Target that sends events when hit by an arrow
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class ArcheryTarget : MonoBehaviour
	{
		public UnityEvent onTakeDamage;

		public bool onceOnly = false;
		public Transform targetCenter;

		public Transform baseTransform;
		public Transform fallenDownTransform;
		public float fallTime = 0.5f;
        public Player player;

		const float targetRadius = 0.25f;

		private bool targetEnabled = true;
        private float transNum;


        //-------------------------------------------------
        void Start() {
            GameObject playerObj = GameObject.Find("Player");
            if(playerObj != null)
            {
                player = playerObj.GetComponent<Player>();
            }
            transNum = 0.0f;
        }
        //-------------------------------------------------
        private void ApplyDamage()
		{
			OnDamageTaken();
            Debug.Log("ApplyDamage Occured");
		}


		//-------------------------------------------------
		private void FireExposure()
		{
			OnDamageTaken();
		}

        //-------------------------------------------------
        private void DestroyTarget()
        {
            Destroy(gameObject);
        }


		//-------------------------------------------------
		private void OnDamageTaken()
		{
            if ( targetEnabled )
			{
				onTakeDamage.Invoke();
				StartCoroutine( this.FallDown() );

				if ( onceOnly )
				{
					targetEnabled = false;
				}
			}
        }

        //-------------------------------------------------
        /*
        private IEnumerator BecomeTransparent()
        {
            for (transNum = 0.0f; transNum <= 1;; transNum += 0.05f){
                GameObject.renderer.material.ChangeAlpha(transNum);
                yield return null;
            }
        }
        */

		//-------------------------------------------------
		private IEnumerator FallDown()
		{
            if ( baseTransform )
			{
				Quaternion startingRot = baseTransform.rotation;

				float startTime = Time.time;
				float rotLerp = 0f;

				while ( rotLerp < 1 )
				{
					rotLerp = Util.RemapNumberClamped( Time.time, startTime, startTime + fallTime, 0f, 1f );
					baseTransform.rotation = Quaternion.Lerp( startingRot, fallenDownTransform.rotation, rotLerp );
					yield return null;
				}
			}
            /* Need to add score giving system */
            player.ScoreIncrease(3);
            //StartCoroutine("BecomeTransparent");
            Invoke("DestroyTarget", 3);
            yield return null;
		}
	}
}
