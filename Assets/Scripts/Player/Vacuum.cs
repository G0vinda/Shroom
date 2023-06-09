using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Vacuum : MonoBehaviour
    {
        public float baseSpeed;
        public AnimationCurve speedOverDistance;
        [FormerlySerializedAs("targetPosition")] public Transform targetTransform;

        private MeshCollider m_collider;
        private List<Collider> m_capturedBeans;
        private float totalDistance = 6.5f;

        void Awake()
        {
            m_capturedBeans = new List<Collider>();
            m_collider = GetComponent<MeshCollider>();
            gameObject.SetActive(false);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Bean.Bean>(out _) && !m_capturedBeans.Contains(other))
            {
                m_capturedBeans.Add(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            m_capturedBeans.Remove(other);
        }

        public void RemoveBean(Bean.Bean bean)
        {
            var beanCollider = bean.gameObject.GetComponent<Collider>();
            if (m_capturedBeans.Contains(beanCollider))
            {
                m_capturedBeans.Remove(beanCollider);
            }
        }
        
        void Update()
        {
            foreach (var capturedBean in m_capturedBeans)
            {
                if(capturedBean == null)
                    continue;
                
                var beanTransform = capturedBean.transform;
                var beanPosition = beanTransform.position;
                var targetPosition = targetTransform.position;
                
                var a = Math.Abs(Vector3.Distance(beanPosition, targetPosition)) / totalDistance;
                var speedMultiplier = speedOverDistance.Evaluate(1.0f - a);
                
                var newPos = Vector3.MoveTowards(
                    beanPosition, targetPosition, baseSpeed * 
                                                  speedMultiplier * Time.deltaTime);
                beanTransform.position = new Vector3(newPos.x, beanPosition.y, newPos.z);
            }
        }
    }
}