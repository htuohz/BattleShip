using BattleShip.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BattleShip.Controllers
{
    public class TrackerController:Controller
    {
        public Board Board;
        public TrackerController()
        {
            
        }

        public void CreateBoard(){
            this.Board = new Board();
        }

        /// <summary>
        /// A ship has been instantiated before add it.
        /// </summary>
        /// <param name="X">Position X </param>
        /// <param name="Y">Position Y</param>
        /// <param name="ship"></param>
        public void AddShip(int X, int Y, Ship
         ship){
            if(this.Board == null){
                throw new NullReferenceException("The board hasn't been created yet.");
            }
            if(X<0 || X>Board.BOARD_SIZE-1 || Y<0 || Y>Board.BOARD_SIZE-1 ){
                throw new ArgumentOutOfRangeException("Invalid arguments");
            }           
            if (ship.Orientation == Ship.VERTICAL){
                for(int i = Y; i<Y+ship.Size;i++){
                    if(this.Board.Cells[X,i]==true){
                        throw new ArgumentException("Ships can't overlay");
                    }
                }
                for(int i = Y; i<Y+ship.Size;i++){
                    this.Board.Cells[X,i]=true;
                }
            }
            else if(ship.Orientation == Ship.HORIZONTAL){
                for(int i = X; i<X+ship.Size;i++){
                    if(this.Board.Cells[i,Y]==true){
                        throw new ArgumentException("Ships can't overlay"); 
                    }
                }
                for(int i = Y; i<Y+ship.Size;i++){
                    this.Board.Cells[i,Y]=true;
                }
            }
        }

        public string TakeAttack(int X, int Y){
            if(this.Board == null ){
                throw new NullReferenceException("The board hasn't been created yet.");
            }
            if(X<0 || X>Board.BOARD_SIZE-1 || Y<0 || Y>Board.BOARD_SIZE-1){
                throw new ArgumentException("Invalid arguments");
            }
            if(this.Board.Cells[X,Y]==true){
                this.Board.Cells[X,Y] = false;
                return "Hit";
            }
            return "Miss";
        }

        public bool HasThePlayerLostYet(){
            if(this.Board == null){
                throw new NullReferenceException("The board hasn't been created yet.");
            }
            for(int i=0;i<Board.BOARD_SIZE;i++){
                for(int j=0;j<Board.BOARD_SIZE;j++){
                    if(this.Board.Cells[i,j]==true){
                        return false;
                    }
                }
            }
            return true;
        }
    }
}