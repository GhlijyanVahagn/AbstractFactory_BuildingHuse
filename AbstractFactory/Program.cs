using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var sniper =new  Hero(new SniperHero());
            sniper.Move();
            sniper.Hit();

            var SwordSoldier = new Hero(new SwordHero());
            SwordSoldier.Move();
            SwordSoldier.Hit();

            Console.Read();
        }
    }
    abstract class Weapon
    {
       public abstract void Hit();
    }
    abstract class MoveMent
    {
        public abstract void Move();
    }

    class Sniper:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Shoot from sniper");
        }
    }
    class Sword:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("hiting  from Sword");

        }
    }
    class FastRuner:MoveMent
    {
        public override void Move()
        {
            Console.WriteLine("running fast fast");
        }

    }
    class Walker : MoveMent
    {
        public override void Move()
        {
            Console.WriteLine("just walking...");
        }
    }

    abstract class HeroFactory
    {
        public abstract Weapon CreateWeapon();
        public abstract MoveMent CreateMoveMent();

    }

    class SniperHero : HeroFactory
    {
        public override MoveMent CreateMoveMent()
        {
            return new Walker();
        }

        public override Weapon CreateWeapon()
        {
            return new Sniper();
        }
    }
    class SwordHero:HeroFactory
    {
        public override MoveMent CreateMoveMent()
        {
            return new FastRuner();
        }
        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
     class Hero
    {
        private Weapon weapon;
        private MoveMent movement;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMoveMent();
        }

        public void Move()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
