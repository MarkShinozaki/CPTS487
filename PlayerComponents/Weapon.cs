using EGGS.ProjectileComponents;
using EGGS.ScriptInterpreterComponents;
using Microsoft.Xna.Framework;

namespace EGGS.PlayerComponents
{
    public class Weapon
    {
        public float Spread { get; set; }
        public int Damage { get; set; }
        public float FireRate { get; set; }
        public float ProjectileSize { get; set; }
        public float ProjectileSpeed { get; set; }

        internal Weapon()
        {
            LoadScript();
        }

        public void shoot(ProjectileFactory projectileFactory, ReadyPlayerOne player, GameTime gameTime)
        {
            Vector2 pos = player.Position;
            pos.X += 12; // Center projectile
            // Use the properties directly
            projectileFactory.SpawnProjectile(pos, ProjectileSize, ProjectileSpeed, Damage, true, Spread);
        }

        private void LoadScript()
        {
            PGunInterpreter gunInterpreter = new PGunInterpreter("PGun.json");
            gunInterpreter.LoadWeaponConfig(this);
        }
    }
}
