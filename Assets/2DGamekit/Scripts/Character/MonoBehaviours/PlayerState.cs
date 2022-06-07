using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gamekit2D
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerState : MonoBehaviour, IDataPersister
    {
        PlayerInput _input;
        public bool HaveControl { get { return m_HaveControl; } }
        public bool MeleeAttack = false;
        public bool RangedAttack = false;

        [HideInInspector]
        public DataSettings dataSettings;

        protected bool m_HaveControl = true;

        protected bool m_DebugMenuIsOpen = false;

        void Awake()
        {
            TryGetComponent(out _input);
        }

        public void DisableMeleeAttacking()
        {
            MeleeAttack = false;
            _input.actions["MeleeAttack"].Disable();
        }

        public void EnableMeleeAttacking()
        {
            MeleeAttack = true;
            _input.actions["MeleeAttack"].Enable();
        }

        public void DisableRangedAttacking()
        {
            RangedAttack = false;
            _input.actions["RangedAttack"].Disable();
        }

        public void EnableRangedAttacking()
        {
            RangedAttack = true;
            _input.actions["RangedAttack"].Enable();
        }

        public DataSettings GetDataSettings()
        {
            return dataSettings;
        }

        public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
        {
            dataSettings.dataTag = dataTag;
            dataSettings.persistenceType = persistenceType;
        }

        public Data SaveData()
        {
            return new Data<bool, bool>(MeleeAttack, RangedAttack);
        }

        public void LoadData(Data data)
        {
            Data<bool, bool> playerInputData = (Data<bool, bool>)data;

            if (playerInputData.value0)
                EnableMeleeAttacking();
            else
                DisableMeleeAttacking();

            if (playerInputData.value1)
                EnableRangedAttacking();
            else
                DisableRangedAttacking();
        }

        void OnGUI()
        {
            if (m_DebugMenuIsOpen)
            {
                const float height = 100;

                GUILayout.BeginArea(new Rect(30, Screen.height - height, 200, height));

                GUILayout.BeginVertical("box");
                GUILayout.Label("Press F12 to close");

                bool meleeAttackEnabled = GUILayout.Toggle(MeleeAttack, "Enable Melee Attack");
                bool rangeAttackEnabled = GUILayout.Toggle(RangedAttack, "Enable Range Attack");

                if (meleeAttackEnabled != MeleeAttack)
                {
                    if (meleeAttackEnabled)
                        EnableMeleeAttacking();
                    else
                        DisableMeleeAttacking();
                }

                if (rangeAttackEnabled != RangedAttack)
                {
                    if (rangeAttackEnabled)
                        EnableRangedAttacking();
                    else
                        DisableRangedAttacking();
                }
                GUILayout.EndVertical();
                GUILayout.EndArea();
            }
        }
    }
}

