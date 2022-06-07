using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gamekit2D
{
    public class InputDisplayUI : MonoBehaviour
    {
        PlayerInput _input;

        private void OnEnable()
        {
            TextMeshProUGUI textUI = GetComponent<TextMeshProUGUI>();
            if (_input == null)   //PlayerInput.Instance == null
            {
                textUI.SetText("## ERROR ## No PlayerInput detected");
                return;
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} - Move Horizontal\n", _input.actions["Move"].ReadValue<Vector2>().x.ToString());
            builder.AppendFormat("{0} - Move Vertical\n", _input.actions["Move"].ReadValue<Vector2>().y.ToString());
            builder.AppendFormat("{0} - Jump\n", _input.actions["Jump"].ToString());
            builder.AppendFormat("{0} - Fire range weapon\n", _input.actions["RangedAttack"].ToString());
            builder.AppendFormat("{0} - Melee Attack\n", _input.actions["MeleeAttack"].ToString());
            builder.AppendFormat("{0} - Pause Menu\n", _input.actions["Pause"].ToString());

            //builder.AppendFormat("{0} - Move Left\n", PlayerInput.Instance.Horizontal.negative.ToString());
            //builder.AppendFormat("{0} - Move Right\n", PlayerInput.Instance.Horizontal.positive.ToString());
            //builder.AppendFormat("{0} - Look Up\n", PlayerInput.Instance.Vertical.positive.ToString());
            //builder.AppendFormat("{0} - Crouch\n", PlayerInput.Instance.Vertical.negative.ToString());
            //builder.AppendFormat("{0} - Jump\n", PlayerInput.Instance.Jump.key.ToString());
            //builder.AppendFormat("{0} - Fire range weapon\n", PlayerInput.Instance.RangedAttack.key.ToString());
            //builder.AppendFormat("{0} - Melee Attack\n", PlayerInput.Instance.MeleeAttack.key.ToString());
            //builder.AppendFormat("{0} - Pause Menu\n", PlayerInput.Instance.Pause.key.ToString());

            textUI.SetText(builder);
        }
    }
}