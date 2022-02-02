using System;
using Xunit;
using BattleShip.Controllers;
using BattleShip.Models;

namespace BattleShip.Tests
{
    public class TrackerTest
    {
        [Fact]
        public void IsBoardCreated()
        {
            var trackerController = new TrackerController();
            trackerController.CreateBoard();
            Random rnd = new Random();
            bool result = trackerController.Board.Cells[rnd.Next(0,10),rnd.Next(0,10)];
            Assert.False(result,"No ship placed on this cell yet");
        }

        [Fact]
        public void IsShipAdded()
        {
            var trackerController = new TrackerController();
            trackerController.CreateBoard();
            var ship = new Ship(5,Ship.HORIZONTAL);
            trackerController.AddShip(1,2,ship);
            bool result = trackerController.Board.Cells[6,2];
            Assert.True(result,"This cell is occupied by a ship");
        }

        [Fact]
        public void IsAttacked()
        {
            var trackerController = new TrackerController();
            trackerController.CreateBoard();
            var ship = new Ship(5,Ship.HORIZONTAL);
            trackerController.AddShip(1,2,ship);
            var result = "Hit" == trackerController.TakeAttack(6,2);
            Assert.True(result,"The ship is hit");
        }

        [Fact]
        public void IsNotAttacked()
        {
            var trackerController = new TrackerController();
            trackerController.CreateBoard();
            var ship = new Ship(5,Ship.HORIZONTAL);
            trackerController.AddShip(1,2,ship);
            var result = "Miss" == trackerController.TakeAttack(6,6);
            Assert.True(result,"The ship is hit");
        }

        [Fact]
        public void HasNotLostGame()
        {
            var trackerController = new TrackerController();
            trackerController.CreateBoard();
            var ship = new Ship(5,Ship.HORIZONTAL);
            trackerController.AddShip(1,2,ship);
            trackerController.TakeAttack(6,2);
            bool result = trackerController.HasThePlayerLostYet();
            Assert.False(result,"The player has not lost the game yet");
        }
                [Fact]
        public void HasLostGame()
        {
            var trackerController = new TrackerController();
            trackerController.CreateBoard();
            var ship = new Ship(5,Ship.HORIZONTAL);
            trackerController.AddShip(1,2,ship);
            for(int i=1;i<7;i++){
                trackerController.TakeAttack(i,2);
            }
            bool result = trackerController.HasThePlayerLostYet();
            Assert.True(result,"The player has lost the game");
        }
    }
}