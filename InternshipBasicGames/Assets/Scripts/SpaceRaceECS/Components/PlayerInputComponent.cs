using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceRaceECS
{
    public struct PlayerInputComponent
    {
        public float moveInput;
        public enum PlayerType { Player1, Player2 }
        public PlayerType playerType;
    }

}
