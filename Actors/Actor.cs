using System;
using DungeonCrawlerGame.Map;
using DungeonCrawlerGame.Objects;

namespace DungeonCrawlerGame.Actors
{
    public class Actor : GameObject
    {
        public int HP { get; set; }
        public int MaxHP { get; set; }

        public int SP { get; set; }
        public int MaxSP { get; set; }

        public int Damage { get; set; }
        public bool Defense { get; set; }
        public bool Attacking { get; set; }

        public float DefenseMaxCooldown { get; set; }
        public float DefenseCooldown { get; set; }

        public bool TakingDamage { get; set; }

        public void Move(Direction direction)
        {

            switch (direction)
            {
                case Direction.Up:
                    if (GameMap.isEmpty(X, Y - 1))
                        Y--;
                    break;
                case Direction.Down:
                    if (GameMap.isEmpty(X, Y + 1))
                        Y++;
                    break;
                case Direction.Left:
                    if (GameMap.isEmpty(X - 1, Y))
                        X--;
                    break;
                case Direction.Right:
                    if (GameMap.isEmpty(X + 1, Y))
                        X++;
                    break;
            }
        }

        public void Attack(Actor target)
        {
            if (this.HP > 0 && this.SP > 0)
            {
                target.TakeDamage(this, Damage);
                this.SP -= Damage;
            }
        }

        public void TakeDamage(Actor attacker, int amount)
        {
            if (Defense) 
            {
                this.SP -= amount * 2;
                if (this.SP < 0)
                    this.SP = 0;

                if (this.SP <= 0)
                {
                    this.Defense = false;
                }
            }

            if (!Defense)
            {
                this.TakingDamage = true;
                this.HP -= amount;
                if (this.HP <= 0)
                {
                    Texture = (int)Resources.Texture.Dead;
                    Solid = false;
                    // attacker.HP = attacker.MaxHP;
                    this.TakingDamage = false;
                }   
            }

        }

        public bool IsNearby(GameObject obj)
        {
           return Math.Abs(X - obj.X) <= 1 && Math.Abs(Y - obj.Y) <= 1; 
        }
    }
}