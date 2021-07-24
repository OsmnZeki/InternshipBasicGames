using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban3D
{
    public class ReplaceCommand : ICommand
{
        IMoveableObjects moveableObjects;
        MyGridXZ placedGrid;
        MyGridXZ currentGrid;
        public ReplaceCommand(IMoveableObjects obj,MyGridXZ placedGrid,MyGridXZ currentGrid)
        {
            moveableObjects = obj;
            this.placedGrid = placedGrid;
            this.currentGrid = currentGrid;
        }

        public void Execute()
        {
            moveableObjects.NextMoveOnGridSystem(placedGrid);
        }

        public void Undo()
        {
            moveableObjects.UndoTheMove(currentGrid);
        }
    }

}

