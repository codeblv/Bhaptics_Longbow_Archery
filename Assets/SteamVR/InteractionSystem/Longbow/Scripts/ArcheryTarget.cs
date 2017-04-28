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
        public Transform targetCenter;
		public Transform baseTransform;
		public Transform fallenDownTransform;
		public float fallTime = 0.5f;
        
        private Player player;
		const float targetRadius = 0.25f;
        private bool onceOnly = true;
        private bool targetEnabled = true;

        //-------------------------------------------------
        void Start() {
            GameObject playerObj = GameObject.Find("Player");
            if(playerObj != null)
            {
                player = playerObj.GetComponent<Player>();
            }
        }
        
        //-------------------------------------------------
        private void ApplyDamage()
		{
			OnDamageTaken();
		}


		//-------------------------------------------------
		private void FireExposure()
		{
			OnDamageTaken();
		}

        //-------------------------------------------------
    	private void OnDamageTaken()
		{
            if ( targetEnabled )
			{
				StartCoroutine( this.FallDown() );

				if ( onceOnly )
				{
					targetEnabled = false;
				}
			}
        }

		//-------------------------------------------------
		private IEnumerator FallDown()
		{
            targetEnabled = false;
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
            player.ScoreIncrease(5);
            player.SendMessage("NumHitIncrease");
            onTakeDamage.Invoke();
            gameObject.GetComponentInChildren<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Destroy(gameObject, 3.0f);
		}
	}
}
