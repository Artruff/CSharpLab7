using System;
using CSharpLab7.GameManager;
using CSharpLab7.Interfaces;
using CSharpLab7.Cards.Test;
using CSharpLab7.Players;
using System.Collections.Generic;

namespace CSharpLab7
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager.GameManager game = GameManager.GameManager.game;
            IPlayer p1 = new ClassicPlayer(10, 10, 20, null);
            p1.propertys.Add("Name", "p1");
            p1.hand.Add(new Ogr(p1, 5));
            IPlayer p2 = new ClassicPlayer(10, 10, 20, null);
            p2.propertys.Add("Name", "p2");
            p2.hand.Add(new Wizard(p2, 1));
            game.players.Add(p2);
            game.players.Add(p1);

            game.NextPlayer();
            while (game.CheckToWin() == null)
            {
                printData();
                game.MakeMove();
                Console.WriteLine("\n");
            }
            Console.WriteLine("Победил: "+game.CheckToWin().propertys["Name"]);
        }
        static void printData()
        {
            GameManager.GameManager game = GameManager.GameManager.game;
            List<IHaveAdditionalProperty> objs = new List<IHaveAdditionalProperty>(game.players);
            objs.AddRange(new List<IHaveAdditionalProperty>(game.cardInGame));
            foreach (IHaveAdditionalProperty obj in objs)
                Console.WriteLine(obj.propertys["Name"] +" - "+ ((IHaveBasicProperty)obj).healthPoint);
        }
    }
}
