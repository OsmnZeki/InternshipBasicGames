using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban3D
{
    public class TurretShotCommand : ICommand
    {
        public ITurret shotCommand;

        public TurretShotCommand(ITurret shotCommand)
        {
            this.shotCommand = shotCommand;
        }

        public void Execute()
        {
            shotCommand.ShootTheBullet();
        }

        public void Undo()
        {
            shotCommand.RemoveTheBullet();
        }
    }
}

