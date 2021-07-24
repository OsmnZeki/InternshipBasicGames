using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban3D
{
    public class WaitingCommand : ICommand
    {
        IMoveableObjects moveableObjects;

        public WaitingCommand(IMoveableObjects obj)
        {
            moveableObjects = obj;
        }

        public void Execute()
        {
            moveableObjects.Waiting();
        }

        public void Undo()
        {
            moveableObjects.Waiting();
        }
    }
}

