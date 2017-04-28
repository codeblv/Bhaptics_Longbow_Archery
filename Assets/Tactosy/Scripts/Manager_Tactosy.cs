using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Tactosy.Common;
using Tactosy.Common.Sender;

namespace Tactosy.Unity
{
    public class Manager_Tactosy : MonoBehaviour
    {
        [Serializable]
        public class SignalMapping
        {
            public string Key;
            public string Path;
        }

        [SerializeField]
        private GameObject leftHandModel, rightHandMoadel;

        [SerializeField]
        public bool visualizeFeedbacks;

        [Tooltip("Tactosy File Prefix")]
        [SerializeField]
        private string PathPrefix = "Assets/Tactosy/Feedbacks/";

        [Tooltip("Tactosy Feedback Mapping Infos")]
        [SerializeField]
        internal List<SignalMapping> FeedbackMappings;

        public TactosyPlayer TactosyPlayer;
        private ITimer timer;
        private bool isHandLeft = true;

        #region Unity Method

        void OnEnable()
        {
            InitializeFeedbacks();
            InitPlayer();
        }

        void OnDisable()
        {
            TactosyPlayer.Stop();
        }

        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                byte[] bytes =
                {
                    0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0,
                    0, 0, 100, 100, 0,
                    0, 0, 0, 0, 0
                };
                TactosyPlayer.SendSignal("Fireball", 0.2f);
            }
        }

        //-------------------------------------------------
        void SetHandLeft()
        {
            isHandLeft = true;
        }

        void SetHandRight()
        {
            isHandLeft = false;
        }

        // Haptic Feedback 1: Arrow Release
        void ArrowRelease()
        {
            TactosyPlayer.SendSignal("ArrowRelease");
        }

        // Haptic Feedback 2: String draw haptic for right hand
        void RightHandDraw(float ratio)
        {
            if (isHandLeft)
            {
                List<Point> pathPoints = new List<Point>
                {
                    new Point(ratio, ratio, 0.5f + (ratio/2))
                };
                TactosyPlayer.SendSignal("RightHandDraw", PositionType.Right, pathPoints, 20);
            }
            else
            {
                List<Point> pathPoints = new List<Point>
                {
                    new Point(1.0f-ratio, ratio, 0.5f + (ratio/2))
                };
                TactosyPlayer.SendSignal("RightHandDraw", PositionType.Left, pathPoints, 20);
            }
        }

        // Haptic Feedback 3: String draw haptic for left hand
        void LeftHandDraw(float ratio)
        {
            List<Point> pathPoints = new List<Point>
            {
                new Point(0.0f, (1f - ratio)/3f, ratio),
                new Point(0.2f, (1f - ratio)/3f, ratio),
                new Point(0.4f, (1f - ratio)/3f, ratio),
                new Point(0.6f, (1f - ratio)/3f, ratio),
                new Point(0.8f, (1f - ratio)/3f, ratio),
                new Point(1.0f, (1f - ratio)/3f, ratio)
            };
            if (isHandLeft)
            {
                TactosyPlayer.SendSignal("LeftHandDraw", PositionType.Left, pathPoints, 20);
            }
            else
            {
                TactosyPlayer.SendSignal("LeftHandDraw", PositionType.Right, pathPoints, 20);
            }
        }

        // Haptic Feedback Definition for Feedback 4 & 5
        private void GrabHaptic1()
        {
            List<Point> pathPoints = new List<Point>
            {
                new Point(0.0f, 0.0f, 1),
                new Point(1.0f, 0.0f, 1),
                new Point(0.0f, 1.0f, 1),
                new Point(1.0f, 1.0f, 1)
            };
            if (isHandLeft)
            {
                TactosyPlayer.SendSignal("BowPickUp", PositionType.Left, pathPoints, 100);
            }
            else
            {
                TactosyPlayer.SendSignal("BowPickUp", PositionType.Right, pathPoints, 100);
            }
        }
        private void GrabHaptic2()
        {
            List<Point> pathPoints = new List<Point>
            {
                new Point(0.25f, 0.25f, 1),
                new Point(0.75f, 0.25f, 1),
                new Point(0.25f, 0.75f, 1),
                new Point(0.75f, 0.75f, 1)
            };
            if (isHandLeft)
            {
                TactosyPlayer.SendSignal("BowPickUp", PositionType.Left, pathPoints, 100);
            }
            else
            {
                TactosyPlayer.SendSignal("BowPickUp", PositionType.Right, pathPoints, 100);
            }
        }
        private void GrabHaptic3()
        {
            List<Point> pathPoints = new List<Point>
            {
                new Point(0.45f, 0.45f, 1),
                new Point(0.55f, 0.45f, 1),
                new Point(0.45f, 0.55f, 1),
                new Point(0.55f, 0.55f, 1)
            };
            if (isHandLeft)
            {
                TactosyPlayer.SendSignal("BowPickUp", PositionType.Left, pathPoints, 100);
            }
            else
            {
                TactosyPlayer.SendSignal("BowPickUp", PositionType.Right, pathPoints, 100);
            }
        }

        // Haptic Feedback 4: Pickup a bow from the back
        public void PickUpBow()
        {
            GrabHaptic1();
            Invoke("GrabHaptic2", 0.1f);
            Invoke("GrabHaptic3", 0.2f);
        }

        // Haptic Feedback 5: Drop the bow
        public void DropBow()
        {
            GrabHaptic3();
            Invoke("GrabHaptic2", 0.1f);
            Invoke("GrabHaptic1", 0.2f);
        }

        // Haptic Feedback 6: Nock Haptic
        public void NockHaptic()
        {
            if (isHandLeft)
            {
                List<Point> leftPathPoints = new List<Point>
                {
                    new Point(1f, 0f, 1),
                    new Point(0.8f, 0f, 1),
                    new Point(0.6f, 0f, 1)
                };

                List<Point> rightPathPoints = new List<Point>
                {
                    new Point(0f, 0f, 1),
                    new Point(0f, 0.2f, 1),
                    new Point(0f, 0.4f, 1)
                };
                TactosyPlayer.SendSignal("NockHaptic1", PositionType.Left, leftPathPoints, 100);
                TactosyPlayer.SendSignal("NockHaptic2", PositionType.Right, rightPathPoints, 100);
            }
            else
            {
                List<Point> leftPathPoints = new List<Point>
                {
                    new Point(1f, 0f, 1),
                    new Point(1f, 0.2f, 1),
                    new Point(1f, 0.4f, 1)
                };

                List<Point> rightPathPoints = new List<Point>
                {
                    new Point(0f, 0f, 1),
                    new Point(0.8f, 0f, 1),
                    new Point(0.6f, 0f, 1)
                };
                TactosyPlayer.SendSignal("NockHaptic1", PositionType.Left, leftPathPoints, 100);
                TactosyPlayer.SendSignal("NockHaptic2", PositionType.Right, rightPathPoints, 100);
            }
        }

        void OnApplicationPause(bool pauseState)
        {
            if (pauseState)
            {
                OnDisable();
            }
            else
            {
                OnEnable();
            }
        }

        #endregion

        void InitializeFeedbacks()
        {
            if (leftHandModel != null && rightHandMoadel != null)
            {
                leftHandModel.gameObject.SetActive(visualizeFeedbacks);
                rightHandMoadel.gameObject.SetActive(visualizeFeedbacks);

                TactosyPlayerOnValueChanged(new TactosyFeedback(PositionType.All, new byte[20], FeedbackMode.DOT_MODE));
            }
        }

        private void UpdateFeedbacks(GameObject handModel, TactosyFeedback tactosyFeedback)
        {
            if (handModel == null)
            {
                return;
            }

            var container = handModel.transform.GetChild(1);

            for (int i = 0; i < container.childCount; i++)
            {
                var scale = tactosyFeedback.Values[i] / 200f;
                if (container.transform.GetChild(i) != null)
                {
                    container.transform.GetChild(i).localScale = new Vector3(scale, .02f, scale);
                }
            }
        }

        private void InitPlayer()
        {
            // Setup Tactosy Player
            var sender = new WebSocketSender();
            timer = GetComponent<UnityTimer>();            
            TactosyPlayer = new TactosyPlayer(sender, timer);
            TactosyPlayer.ValueChanged += TactosyPlayerOnValueChanged;

            foreach (var feedbackMapping in FeedbackMappings)
            {
                try
                {
                    string filePath = Path.Combine(PathPrefix, feedbackMapping.Path);

                    string json;
                    if (Application.platform == RuntimePlatform.Android)
                    {
                        WWW www = new WWW(filePath);

                        while (!www.isDone)
                        {
                        }

                        json = www.text;
                    }
                    else
                    {
                        json = File.ReadAllText(filePath);
                    }
                    TactosyPlayer.RegisterFeedback(feedbackMapping.Key, new FeedbackSignal(json));
                }
                catch (Exception e)
                {
                    Debug.LogError("failed to read feedback file " + Path.Combine(PathPrefix, feedbackMapping.Path) + " : " + e.Message);
                }
            }

            TactosyPlayer.Start();
        }

        private void TactosyPlayerOnValueChanged(TactosyFeedback feedback)
        {
            if (feedback.Position == PositionType.Left)
            {
                UpdateFeedbacks(leftHandModel, feedback);
            }
            else if (feedback.Position == PositionType.Right)
            {
                UpdateFeedbacks(rightHandMoadel, feedback);
            }
            else if (feedback.Position == PositionType.All)
            {
                UpdateFeedbacks(leftHandModel, feedback);
                UpdateFeedbacks(rightHandMoadel, feedback);
            }
        }

        public void Play(string key)
        {
            if (TactosyPlayer == null)
            {
                Debug.LogError("Tactosy player is not initialized.");
                return;
            }
            TactosyPlayer.SendSignal(key);
        }
        

        public void TurnOff()
        {
            if (TactosyPlayer == null)
            {
                Debug.LogError("Tactosy player is not initialized.");
                return;
            }

            TactosyPlayer.TurnOff();
        }
    }
}

