﻿using UnityEngine;
using RPG.Movement;
using System;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        private void Update()
        {
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                if(hit.transform.GetComponent<CombatTarget>() != null)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        GetComponent<Fighter>().Attack();
                    }
                    return true;
                }
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            //draws the ray
            //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
            bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hit);

            if (hasHit)
            {
                if (Input.GetMouseButton(1))
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                    //set navmesh agent's destionation to target's position.
                }
                return true;
            }
            return false;
        }
        private static Ray GetMouseRay()
        {
            // creates a ray going form the camera to the positon of mouse click.
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
