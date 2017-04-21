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
        private Player player;

		const float targetRadius = 0.25f;

		private bool targetEnabled = true;


        //
        void Start() {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if(playerObj != null)
            {
                player = playerObj.GetComponent<Player>();
            }
        }
        //-------------------------------------------------
        private void ApplyDamage()
		{
            // Hit Point++;
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
            // Score Point Calculation needed
            Debug.Log("OnDamageTaken Occured");

            if ( targetEnabled )
			{
				onTakeDamage.Invoke();
				StartCoroutine( this.FallDown() );

				if ( onceOnly )
				{
					targetEnabled = false;
				}
			}
            // After 0.5s weeble BANG!
        }


		//-------------------------------------------------
		private IEnumerator FallDown()
		{
            Debug.Log("FallDown Occured");

            if ( baseTransform )
			{
				Quaternion startingRot = baseTransform.rotation;

				float startTime = Time.time;
				float rotLerp = 0f;

				while ( rotLerp < 1 )
				{
                    Debug.Log("RotLerp");
					rotLerp = Util.RemapNumberClamped( Time.time, startTime, startTime + fallTime, 0f, 1f );
					baseTransform.rotation = Quaternion.Lerp( startingRot, fallenDownTransform.rotation, rotLerp );
					yield return null;
				}
			}
            player.ScoreIncrease(1);
            // Give Score ++ 
            Invoke("DestroyTarget", 3);
            yield return null;
		}
	}
}
